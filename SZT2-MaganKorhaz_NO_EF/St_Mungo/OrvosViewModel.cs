
using St_Mungo.StMungo_WCF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFTeszt01
{
    class OrvosViewModel : INotifyPropertyChanged
    {
        static OrvosViewModel vm;
        StMungoServiceClient smc;
        //----------------------------Listboxhoz szükséges selected itemek----------------------
        People selectedPeopleBeteg;
        Betegek selectedBeteg;
        Kortortenet_fej selectedKorlapFej;
        ObservableCollection<Kortortenet_tetel> selectedKorlapTetel;
        Kortortenet_tetel selectedKezeles;

        Lazlap betegLazlapja;
        ObservableCollection<KiadottGyogyszer> betegGyogyszerei;
        //------------------------------------------------------------------------------------

        //-----------------------------Összes szükséges lekért adat a táblákból----------------
        People orvos;
        ObservableCollection<People> betegek;
        ObservableCollection<Betegek> betegTabla;
        ObservableCollection<Kortortenet_fej> kortortenetFej;
        ObservableCollection<Kortortenet_tetel> kortortenetTetel;
        ObservableCollection<Lazlap> lazlapok;
        ObservableCollection<KiadottGyogyszer> gyogyszerek;
        //MungoSystem ms;
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


        public Kortortenet_tetel SelectedKezeles
        {
            get { return selectedKezeles; }
            set { selectedKezeles = value; }
        }

        public ObservableCollection<Lazlap> Lazlapok
        {
            get
            {
                return lazlapok;
            }

            set
            {
                lazlapok = value;
            }
        }

        public ObservableCollection<KiadottGyogyszer> Gyogyszerek
        {
            get
            {
                return gyogyszerek;
            }

            set
            {
                gyogyszerek = value;
            }
        }

        public Lazlap BetegLazlapja
        {
            get
            {
                return betegLazlapja;
            }

            set
            {
                betegLazlapja = value;
            }
        }

        public ObservableCollection<KiadottGyogyszer> BetegGyogyszerei
        {
            get
            {
                return betegGyogyszerei;
            }

            set
            {
                betegGyogyszerei = value;
                OnPropChanged("betegekGyogyszerei");
            }
        }

        //------------------------------------------------------------------------------------
        public void MungoSystemInitial(StMungoServiceClient smc) {
            this.smc = smc;
            this.betegTabla = new ObservableCollection<Betegek>(smc.mungoSystem().Betegek);
            this.kortortenetFej = new ObservableCollection<Kortortenet_fej>(smc.mungoSystem().Kortortenet_fej);
            this.kortortenetTetel = new ObservableCollection<Kortortenet_tetel>(smc.mungoSystem().Kortortenet_tetel);
            this.betegek = new ObservableCollection<People>(smc.People_getLocal().Where(ppl => ppl.Deleted == 0 && ppl.Group == 1));
            //ms.People.Local.Where(ppl =>ppl.Deleted == 0 && ppl.Group == 1)
            this.lazlapok = new ObservableCollection<Lazlap>(smc.mungoSystem().Lazlap);
            this.gyogyszerek = new ObservableCollection<KiadottGyogyszer>(smc.mungoSystem().KiadottGyogyszer);
            pID = smc.mungoSystem().People.Max(p => p.PeopleID);
            bID = smc.mungoSystem().Betegek.Max(p => p.BetegID);
            kfID = smc.mungoSystem().Kortortenet_fej.Max(p => p.KortortenetFejID);
            ktID = smc.mungoSystem().Kortortenet_tetel.Max(p => p.KortortenetTetelID);
            OnPropChanged("betegek");
        }
        public static OrvosViewModel Get() {
            if (vm == null)
                vm = new OrvosViewModel();
            return vm;
        }

        public void Mentes() {
            smc.mungoSystemSave();
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
                selectedBeteg = BetegTabla.Where(b => b.Deleted == 0 && b.PeopleID == selectedPeopleBeteg.PeopleID).First();
                selectedKorlapFej = KortortenetFej.Where(k => k.Deleted == 0 && k.BetegID == selectedBeteg.BetegID).First();
                SelectedKorlapTetel = new ObservableCollection<Kortortenet_tetel>(KortortenetTetel.Where(kt => kt.Deleted == 0 && kt.KortortenetFejID == selectedKorlapFej.KortortenetFejID));
                OnPropChanged("selectedKorlapTetel");
                
            }
            catch { }
        }
        public void Ujbeteg(People beteg, string taj) {
            ++pID;
            //ms.People.Local.Add(beteg);
            smc.People_getLocal().Add(beteg);
            smc.Betegek_getLocal().Add(new Betegek() { TAJ = taj, Deleted = 0, PeopleID = pID });
            //ms.Betegek.Local.Add(new Betegek() {TAJ=taj, Deleted=0 , PeopleID=pID});
            
            Mentes();

            smc.People_getLoad();
            //ms.People.Load();
            smc.Betegek_getLoad();
            //ms.Betegek.Load();
            MungoSystemInitial(smc);
        }

        public void KezelesModositas(Kortortenet_tetel kt) {
            Kortortenet_tetel kt2 = smc.mungoSystem().Kortortenet_tetel.Where(x => x.Deleted == 0 && x.KortortenetTetelID == kt.KortortenetTetelID).First();

            kt2.Datum = kt.Datum;
            kt2.Kezeles = kt.Kezeles;
            kt2.Orvos = kt.Orvos;
           
            Mentes();
            MungoSystemInitial(smc);
            SelectionChanged();
        }
        public void KezelesLetrehozas(Kortortenet_tetel kt) {
            kt.KortortenetFejID = selectedKorlapFej.KortortenetFejID;
            smc.mungoSystem().Kortortenet_tetel.Add(kt);

            Mentes();
            MungoSystemInitial(smc);
            SelectionChanged();
        }

        public void SelectedBetegLazlapja() {
            if (selectedBeteg != null)
            {
                try
                {
                    betegLazlapja = lazlapok.Where(x => x.Deleted == 0 && x.BetegID == selectedBeteg.BetegID).First();
                }
                catch
                {
                    betegLazlapja = new Lazlap() { BetegID = selectedBeteg.BetegID, Deleted = 0, OrvosID = orvos.PeopleID, OrvosMegjegyzes = "Nincs megjegyzés.", ApoloMegjegyzes = "Nincs megjegyzés." };
                }
                finally { OnPropChanged("betegLazlapja"); }
            }
        }
        public void SelectedBetegGyogyszerei() {
            if (betegLazlapja != null)
            {
                try
                {
                    betegGyogyszerei = new ObservableCollection<KiadottGyogyszer>(smc.mungoSystem().KiadottGyogyszer.Where(x => x.Deleted == 0 && betegLazlapja.LazlapID == x.ForrasID));
                }
                catch
                {
                    betegGyogyszerei = new ObservableCollection<KiadottGyogyszer>();
                }
                {
                    OnPropChanged("betegGyogyszerei");
                }
            }
        }
        public void SelectedBetegLazlapMentes() {
            if (betegLazlapja != null) {                 
                try
                {
                    Lazlap l = smc.mungoSystem().Lazlap.Where(x => x.Deleted == 0 && x.BetegID == selectedBeteg.BetegID).First();

                    l.ApoloMegjegyzes = betegLazlapja.ApoloMegjegyzes;
                    l.OrvosMegjegyzes = betegLazlapja.OrvosMegjegyzes;

                }
                catch {
                    smc.mungoSystem().Lazlap.Add(new Lazlap() { ApoloMegjegyzes = betegLazlapja.ApoloMegjegyzes, OrvosMegjegyzes = betegLazlapja.OrvosMegjegyzes, BetegID = selectedBeteg.BetegID, OrvosID = orvos.PeopleID, Deleted = 0, Statusz = 7});
                }
                finally
                {   
                    foreach (var i in betegGyogyszerei)
                    {
                        KiadottGyogyszer kgy = i;
                        try {
                            KiadottGyogyszer tmp = smc.mungoSystem().KiadottGyogyszer.Where(x => x.Deleted == 0 && x.ForrasID == betegLazlapja.LazlapID && x.GyogyszerID == kgy.GyogyszerID).First();
                        }
                        catch { smc.mungoSystem().KiadottGyogyszer.Add(i); }                            
                    }
                    Mentes();
                    MungoSystemInitial(smc);
                    BetegGyogyszerei = new ObservableCollection<KiadottGyogyszer>();

                }
            }
        }
        public void SelectedGyogyszerTorles(KiadottGyogyszer del) {
            foreach (var i in smc.mungoSystem().KiadottGyogyszer)
            {
                KiadottGyogyszer ki = i;
                if (ki.GyogyszerID == del.GyogyszerID)
                    ki.Deleted = 1;
            }
            betegGyogyszerei = new ObservableCollection<KiadottGyogyszer>(smc.mungoSystem().KiadottGyogyszer.Where(x => x.Deleted == 0 && betegLazlapja.LazlapID == x.ForrasID));
            OnPropChanged("betegGyogyszerei");
        }

        public int LetezoGyogyszerVizsgalat(string nev) {
            try {
                return GyogyszerID(nev);
            }
            catch { return 0; }            
        }

        public string GyogyszerNev(int id) {
            Gyogyszer gy = smc.mungoSystem().Gyogyszer.Where(x => x.Deleted == 0 && x.GyogyszerID == id).First();
            return gy.Megnevezes;
        }
        public int GyogyszerID(string nev)
        {
            Gyogyszer gy = smc.mungoSystem().Gyogyszer.Where(x => x.Deleted == 0 && x.Megnevezes == nev).First();
            return gy.GyogyszerID;
        }
        public KiadottGyogyszer GyogyszerNevToKiadott(string nev) {
            nev = nev.Substring(0, nev.IndexOf("\t"));
            Gyogyszer gy = smc.mungoSystem().Gyogyszer.Where(x => x.Deleted == 0 && x.Megnevezes == nev).First();
            return smc.mungoSystem().KiadottGyogyszer.Where(x => x.Deleted == 0 && x.GyogyszerID == gy.GyogyszerID).First();
        }

    }
}
