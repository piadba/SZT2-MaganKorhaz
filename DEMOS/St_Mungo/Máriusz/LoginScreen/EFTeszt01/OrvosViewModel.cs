using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFTeszt01
{
    class OrvosViewModel : INotifyPropertyChanged
    {
        static OrvosViewModel vm;

        //----------------------------Listboxhoz szükséges selected itemek----------------------
        People selectedPeopleBeteg;
        Betegek selectedBeteg;
        Kortortenet_fej selectedKorlapFej;
        ObservableCollection<Kortortenet_tetel> selectedKorlapTetel;
        //------------------------------------------------------------------------------------

        //-----------------------------Összes szükséges lekért adat a táblákból----------------
        People orvos;
        ObservableCollection<People> betegek;
        ObservableCollection<Betegek> betegTabla;
        ObservableCollection<Kortortenet_fej> kortortenetFej;
        ObservableCollection<Kortortenet_tetel> kortortenetTetel;
        MungoSystem ms;
        //------------------------------------------------------------------------------------


        //------------------------ujbeteg-------------------------------------------------------
        People tmpUjBeteg;
        string tmpUjBetegTaj;
        int pID, bID, kfID, ktID;
        //------------------------------------------------------------------------------------



        //-----------------------------Propertyk----------------
        public People Orvos
        {
            get
            {
                return orvos;
            }

            set
            {
                orvos = value;
            }
        }

        public ObservableCollection<People> Betegek
        {
            get
            {
                return betegek;
            }

            set
            {
                betegek = value;
                OnPropChanged("Betegek");
            }
        }

        public ObservableCollection<Betegek> BetegTabla
        {
            get
            {
                return betegTabla;
            }

            set
            {
                betegTabla = value;
            }
        }

        public ObservableCollection<Kortortenet_fej> KortortenetFej
        {
            get
            {
                return kortortenetFej;
            }

            set
            {
                kortortenetFej = value;
            }
        }

        public ObservableCollection<Kortortenet_tetel> KortortenetTetel
        {
            get
            {
                return kortortenetTetel;
            }

            set
            {
                kortortenetTetel = value;
            }
        }

        public People SelectedBeteg
        {
            get
            {
                return selectedPeopleBeteg;
            }

            set
            {
                selectedPeopleBeteg = value;
                SelectionChanged();
            }
        }

        public ObservableCollection<Kortortenet_tetel> SelectedKorlapTetel
        {
            get
            {
                return selectedKorlapTetel;
            }

            set
            {
                selectedKorlapTetel = value;
            }
        }
        

        //------------------------------------------------------------------------------------
        public void MungoSystemInitial(MungoSystem ms) {
            this.ms = ms;
            this.betegTabla = new ObservableCollection<Betegek>(ms.Betegek);
            this.kortortenetFej = new ObservableCollection<Kortortenet_fej>(ms.Kortortenet_fej);
            this.kortortenetTetel = new ObservableCollection<Kortortenet_tetel>(ms.Kortortenet_tetel);
            this.betegek = new ObservableCollection<People>(ms.People.Local.Where(ppl => ppl.Group == 2));
            pID = ms.People.Max(p => p.PeopleID);
            bID = ms.Betegek.Max(p => p.BetegID);
            kfID = ms.Kortortenet_fej.Max(p => p.KortortenetFejID);
            ktID = ms.Kortortenet_tetel.Max(p => p.KortortenetTetelID);
            OnPropChanged("betegek");
        }
        public static OrvosViewModel Get() {
            if (vm == null)
                vm = new OrvosViewModel();
            return vm;
        }

        public void Mentes() {
            ms.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropChanged([CallerMemberName] string s = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
        void SelectionChanged() {          
            try
            {
                selectedBeteg = BetegTabla.Where(b => b.PeopleID == selectedPeopleBeteg.PeopleID).First();
                selectedKorlapFej = KortortenetFej.Where(k => k.BetegID == selectedBeteg.BetegID).First();
                SelectedKorlapTetel = new ObservableCollection<Kortortenet_tetel>(KortortenetTetel.Where(kt => kt.KortortenetFejID == selectedKorlapFej.KortortenetFejID));
                OnPropChanged("selectedKorlapTetel");
            }
            catch { }
        }
        public void Ujbeteg(People beteg, string taj) {
            ++pID;
            ms.People.Local.Add(beteg);
            ms.Betegek.Local.Add(new Betegek() {TAJ=taj, Deleted=0 , PeopleID=pID});
            
            Mentes();
            ms.People.Load();
            ms.Betegek.Load();
            MungoSystemInitial(this.ms);
        }

    }
}
