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
        Kortortenet_tetel selectedKezeles;
        //KiadottGyogyszer selectedGyogyszer;
        ObservableCollection<OrvosAsszisztensGyogyszerKapcsolat> kiad_gyogy;

        Lazlap betegLazlapja;
        ObservableCollection<KiadottGyogyszer> betegGyogyszerei;

        ObservableCollection<KiadottGyogyszer> orvosBetegGyogyszerei;
        //------------------------------------------------------------------------------------

        //-----------------------------Összes szükséges lekért adat a táblákból----------------
        People orvos;
        ObservableCollection<People> betegek;
        ObservableCollection<Betegek> betegTabla;
        ObservableCollection<Kortortenet_fej> kortortenetFej;
        ObservableCollection<Kortortenet_tetel> kortortenetTetel;
        ObservableCollection<Lazlap> lazlapok;
        ObservableCollection<Gyogyszer> gyogyszerek;
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

        public ObservableCollection<Gyogyszer> Gyogyszerek
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
        public ObservableCollection<KiadottGyogyszer> OrvosBetegGyogyszerei
        {
            get
            {
                return orvosBetegGyogyszerei;
            }
            set {
                orvosBetegGyogyszerei = value;
                OnPropChanged("orvosBetegGyogyszerei");
            }
        }

        internal ObservableCollection<OrvosAsszisztensGyogyszerKapcsolat> Kiad_gyogy
        {
            get
            {
                return kiad_gyogy;
            }

            set
            {
                kiad_gyogy = value;
            }
        }


        //------------------------------------------------------------------------------------
        public void MungoSystemInitial(MungoSystem ms) {
            this.ms = ms;
            this.betegTabla = new ObservableCollection<Betegek>(ms.Betegek);
            this.kortortenetFej = new ObservableCollection<Kortortenet_fej>(ms.Kortortenet_fej);
            this.kortortenetTetel = new ObservableCollection<Kortortenet_tetel>(ms.Kortortenet_tetel);
            this.betegek = new ObservableCollection<People>(ms.People.Local.Where(ppl =>ppl.Deleted == 0 && ppl.Group == 1));
            this.lazlapok = new ObservableCollection<Lazlap>(ms.Lazlap);
            this.gyogyszerek = new ObservableCollection<Gyogyszer>(ms.Gyogyszer);
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

            selectedBeteg = BetegTabla.Where(b => b.Deleted == 0 && b.PeopleID == selectedPeopleBeteg.PeopleID).First();
            try
            {
                selectedKorlapFej = KortortenetFej.Where(k => k.Deleted == 0 && k.BetegID == selectedBeteg.BetegID).First();
                SelectedKorlapTetel = new ObservableCollection<Kortortenet_tetel>(KortortenetTetel.Where(kt => kt.Deleted == 0 && kt.KortortenetFejID == selectedKorlapFej.KortortenetFejID));
                OnPropChanged("selectedKorlapTetel");
                
            }
            catch {
                //ms.Kortortenet_fej.Add(new Kortortenet_fej() { BetegID = selectedBeteg.BetegID, Deleted = 0 });

                //Mentes();
                //MungoSystemInitial(ms);
                    selectedKorlapFej = KortortenetFej.Where(k => k.Deleted == 0 && k.BetegID == selectedBeteg.BetegID).First();
                OnPropChanged("selectedKorlapTetel");
            }
        }
        public void Ujbeteg(People beteg, string taj) {
            ++pID;
            ms.People.Local.Add(beteg);
            ms.Betegek.Local.Add(new Betegek() {TAJ=taj, Deleted=0 , PeopleID=pID});
            //ms.Kortortenet_fej.Local.Add(new Kortortenet_fej() { Deleted = 0, BetegID = ms.Betegek.Where(x => x.Deleted == 0 && x.PeopleID == pID).First().BetegID });

            Mentes();
            ms.People.Load();
            ms.Betegek.Load();
            ms.Kortortenet_fej.Local.Add(new Kortortenet_fej() { Deleted = 0, BetegID = ms.Betegek.Where(x => x.Deleted == 0 && x.PeopleID == pID).First().BetegID });
            Mentes();
            ms.Kortortenet_fej.Load();
            MungoSystemInitial(this.ms);
            kortortenetFej = ms.Kortortenet_fej.Local;
              }

        public void KezelesModositas(Kortortenet_tetel kt) {
            Kortortenet_tetel kt2 = ms.Kortortenet_tetel.Where(x => x.Deleted == 0 && x.KortortenetTetelID == kt.KortortenetTetelID).First();

            kt2.Datum = kt.Datum;
            kt2.Kezeles = kt.Kezeles;
            kt2.Orvos = kt.Orvos;
           
            Mentes();
            MungoSystemInitial(this.ms);
            SelectionChanged();
        }
        public void KezelesLetrehozas(Kortortenet_tetel kt) {
            kt.KortortenetFejID = selectedKorlapFej.KortortenetFejID;
            ms.Kortortenet_tetel.Add(kt);

            Mentes();
            MungoSystemInitial(this.ms);
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
                    betegGyogyszerei = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && betegLazlapja.LazlapID == x.ForrasID));
                }
                catch
                {
                    betegGyogyszerei = new ObservableCollection<KiadottGyogyszer>();
                }
                finally
                {
                    OnPropChanged("betegGyogyszerei");
                }
            }
        }
        public void SelectedBetegLazlapMentes() {
            if (betegLazlapja != null) {                 
                try
                {
                    Lazlap l = ms.Lazlap.Where(x => x.Deleted == 0 && x.BetegID == selectedBeteg.BetegID).First();

                    l.ApoloMegjegyzes = betegLazlapja.ApoloMegjegyzes;
                    l.OrvosMegjegyzes = betegLazlapja.OrvosMegjegyzes;

                }
                catch {
                    ms.Lazlap.Add(new Lazlap() { ApoloMegjegyzes = betegLazlapja.ApoloMegjegyzes, OrvosMegjegyzes = betegLazlapja.OrvosMegjegyzes, BetegID = selectedBeteg.BetegID, OrvosID = orvos.PeopleID, Deleted = 0, Statusz = 7});
                }
                finally
                {   
                    foreach (var i in betegGyogyszerei)
                    {
                        KiadottGyogyszer kgy = i;
                        try {
                            KiadottGyogyszer tmp = ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && x.ForrasID == betegLazlapja.LazlapID && x.GyogyszerID == kgy.GyogyszerID).First();
                        }
                        catch { ms.KiadottGyogyszer.Add(i); }                            
                    }
                    Mentes();
                    MungoSystemInitial(this.ms);
                    BetegGyogyszerei = new ObservableCollection<KiadottGyogyszer>();
                    OnPropChanged("betegGyogyszerei");
                }
            }
        }
        public void SelectedGyogyszerTorles(KiadottGyogyszer del) {
            //ms.KiadottGyogyszer.Where(x => x.KiadottGyogyszer1 == del.KiadottGyogyszer1).Single().Deleted = 1;
            KiadottGyogyszer ki1 = ms.KiadottGyogyszer.Local.Where(x => x.Deleted == 0 && x.KiadottGyogyszer1 == del.KiadottGyogyszer1).First();
            ki1.Deleted = 1;
            //foreach (var i in ms.KiadottGyogyszer)
            //{
            //    KiadottGyogyszer ki = i;
            //    if (ki.KiadottGyogyszer1 == del.KiadottGyogyszer1)
            //        ki.Deleted = 1;
            //}
            Gyogyszer gy = ms.Gyogyszer.Local.Where(x => x.Deleted == 0 && x.GyogyszerID == del.GyogyszerID).First();
            gy.Mennyiseg += del.Mennyiseg;

            Mentes();
            betegGyogyszerei = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && betegLazlapja.LazlapID == x.ForrasID && x.Statusz == 11));
            OnPropChanged("betegGyogyszerei");
        }

        public int LetezoGyogyszerVizsgalat(string nev) {
            try {
                return GyogyszerID(nev);
            }
            catch { return 0; }            
        }

        public string GyogyszerNev(int id) {
            Gyogyszer gy = ms.Gyogyszer.Where(x => x.Deleted == 0 && x.GyogyszerID == id).First();
            return gy.Megnevezes;
        }
        public int GyogyszerID(string nev)
        {
            Gyogyszer gy = ms.Gyogyszer.Where(x => x.Deleted == 0 && x.Megnevezes == nev).First();
            return gy.GyogyszerID;
        }
        public IgenyMainWindow IgenyNyito() {
            IgenyMainWindow imw = new IgenyMainWindow(orvos, ms);
            return imw;
        }

        public void GyogyszerBeszurasTortent() {
            foreach (var i in betegGyogyszerei)
            {
                KiadottGyogyszer kgy = i;
                try
                {
                    KiadottGyogyszer tmp = ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && x.ForrasID == betegLazlapja.LazlapID && x.KiadottGyogyszer1 == kgy.KiadottGyogyszer1).First();
                }
                catch { ms.KiadottGyogyszer.Add(i); }

                //ms.KiadottGyogyszer.Add(i); 
            }
            Mentes();
            OnPropChanged("betegGyogyszerei");
        }
        public bool GyogyszerMennyisegMod(int mennyiseg, int id)
        {
            try
            {
                Gyogyszer gyogy = ms.Gyogyszer.Where(x => x.Deleted == 0 && x.GyogyszerID == id && x.Mennyiseg >= mennyiseg).First();
                gyogy.Mennyiseg -= mennyiseg;

                Mentes();


                return true;
            }
            catch
            {
                return false;
            }
        }

        public string OrvosID2Name(int id) {
            string nev = ms.People.Where(x => x.Deleted == 0 && x.PeopleID == id).First().Name;
            return nev;
        }
        public int OrvosName2Id(string name)
        {
            int id = ms.People.Where(x => x.Deleted == 0 && x.Name == name).First().PeopleID;
            return id;
        }

        public void OrvosGyogyszerKiadas() {
            try
            {
                ms.KiadottGyogyszer.Load();
                Betegek beteg = ms.Betegek.Local.Where(y => y.Deleted == 0 && SelectedBeteg.PeopleID == y.PeopleID).First();
                Lazlap laz = ms.Lazlap.Local.Where(x => x.Deleted == 0 && x.BetegID == beteg.BetegID).First();
                OrvosBetegGyogyszerei = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Local.Where(x => x.Deleted == 0 && x.Statusz == 10 && x.ForrasID == laz.LazlapID));
                
            }
            catch { }
        }
        public void OrvosGyogyszerBeszuras(KiadottGyogyszer kgy) {
            Betegek beteg = ms.Betegek.Local.Where(y => y.Deleted == 0 && SelectedBeteg.PeopleID == y.PeopleID).First();
            Lazlap laz = ms.Lazlap.Local.Where(x => x.Deleted == 0 && x.BetegID == beteg.BetegID).First();
            kgy.ForrasID = laz.LazlapID;
            ms.KiadottGyogyszer.Local.Add(kgy);
            Mentes();
            ms.KiadottGyogyszer.Load();
            OrvosGyogyszerKiadas();
        }
        public void OrvosGyogyszerTorles(KiadottGyogyszer kgy) {
            try
            {
                KiadottGyogyszer del = ms.KiadottGyogyszer.Local.Where(x => x.Deleted == 0 && x.KiadottGyogyszer1 == kgy.KiadottGyogyszer1).First();
                del.Deleted = 1;
                Gyogyszer gy = ms.Gyogyszer.Local.Where(x=> x.Deleted == 0 && x.GyogyszerID == kgy.GyogyszerID).First();
                gy.Mennyiseg += kgy.Mennyiseg;
                Mentes();
                ms.KiadottGyogyszer.Load();
                OrvosGyogyszerKiadas();
            }
            catch { }
        }

    }
}
