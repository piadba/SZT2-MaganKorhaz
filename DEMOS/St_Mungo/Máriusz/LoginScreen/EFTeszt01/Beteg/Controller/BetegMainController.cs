using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EFTeszt01.Models;

namespace EFTeszt01.Controllers
{
    public enum ViewTypes { Idopont, Adatok }

    public class BetegMainController : Bindable
    {

        public BetegAdatok betegAdatok { get; private set; }
        public UserControl view { get; private set; }
        public IdopontCreator idopontCreator { get; private set; }
        public static DBController dbController;
        public BetegMainController(MungoSystem db, People people)
        {
            dbController = new DBController(db);

            betegAdatok = dbController.getBetegAdatok(people.PeopleID);
            betegAdatok.Kortortenet = dbController.getKortortenetekByBetegId(betegAdatok.betegekElem.BetegID);
            betegAdatok.idopontok = dbController.getAllIdopont();
            var p = dbController.getPossibleIdopont(betegAdatok.BetegID);
            betegAdatok.changed();
            idopontCreator = new IdopontCreator(betegAdatok.BetegID);
            SetView(ViewTypes.Idopont);
        }
        public void SetView(ViewTypes viewType)
        {
            switch (viewType)
            {
                case ViewTypes.Idopont:
                    view = new Idopont_View(this);
                    break;
                case ViewTypes.Adatok:
                    view = new AdatMod_View(this);
                    break;
                default:
                    break;
            }
            OnPropertyChanged("view");
        }
        public void DeleteIdopont()
        {
            var a = idopontCreator.removeIdopont();
            if (a != null)
            {
                dbController.IdopontSaveChanges(a);
            }
        }
        public void SaveIdopont()
        {
            var a = idopontCreator.createIdopont();
            if (a != null)
            {
                dbController.IdopontSaveChanges(a);
            }
        }
        public void SaveChanges()
        {
            dbController.Beteg_SaveChanges(betegAdatok);
        }
    }
    public class IdopontCreator : Bindable
    {
        Idopont selIp;
        int betegId;
        string o, st, sd;
        ObservableCollection<string> times, orvosok, dates;

        public ObservableCollection<Idopont> idopontok { get; set; }

        public ObservableCollection<string> Orvosok
        {
            get
            {
                var a = new ObservableCollection<string>
                    (idopontok.Select(x => x.Orvos).Distinct().ToList());
                orvosok = a;
                Orvos = orvosok.Count > 0 ? orvosok[0] : "";
                OnPropertyChanged("Dates");
                OnPropertyChanged("Times");
                return orvosok;
            }
        }
        public ObservableCollection<string> Dates
        {
            get
            {
                var a = new ObservableCollection<string>
                    (idopontok.Where(x => x.Orvos == o).Select(x => x.Datum.ToShortDateString()).Distinct().ToList());
                dates = a;
                selectedDate = dates.Count > 0 ? dates[0] : "";
                OnPropertyChanged("Times");
                return dates;
            }
        }
        public ObservableCollection<string> Times
        {
            get
            {
                var a = new ObservableCollection<string>
                    (idopontok.Where(x => x.Orvos == o && x.Datum.ToShortDateString().Equals(selectedDate))
                    .Select(x => x.Datum.ToShortTimeString()).Distinct().ToList());
                times = a;
                selectedTime = times.Count > 0 ? times[0] : "";
                return times;
            }
        }
        public Idopont SelectedIdopont
        { get { return selIp; } set { selIp = value; OnPropertyChanged(); OnPropertyChanged("Mine"); } }
        public bool Mine
        {
            get
            {
                //if ((SelectedIdopont = getSelectedIdopont()) != null)
                //{
                return betegId == SelectedIdopont.betegID;
                //}
                // return false;
            }
        }
        public string Orvos
        {
            get { return o; }
            set { o = value; OnPropertyChanged(); OnPropertyChanged("Dates"); }
        }
        public string selectedDate
        {
            get { return sd; }
            set { sd = value; OnPropertyChanged(); OnPropertyChanged("Times"); }
        }
        public string selectedTime
        {
            get { return st; }
            set { st = value; OnPropertyChanged(); SelectedIdopont = getSelectedIdopont(); }
        }
        public Idopont Idopont { get; set; }
        public IdopontCreator(int betegid)
        {
            betegId = betegid;
            idopontok = BetegMainController.dbController.getPossibleIdopont(betegid);
            OnPropertyChanged("Orvosok");

        }
        Idopont getSelectedIdopont()
        {
            if (Orvos != "" && selectedDate != "" && selectedTime != "")
            {
                var a = idopontok.FirstOrDefault(x => x.Orvos == Orvos
                && x.Datum.ToShortDateString().Equals(selectedDate)
                && x.Datum.ToShortTimeString().Equals(selectedTime));
                return a;
            }
            return null;
        }

        public Idopont createIdopont()
        {
            if ((SelectedIdopont = getSelectedIdopont()) != null&&!Mine)
            {
                SelectedIdopont.IdopontElem.BetegID = betegId;
                OnPropertyChanged("Mine");
                return SelectedIdopont;
            }
            return null;
        }
        public Idopont removeIdopont()
        {
            SelectedIdopont.IdopontElem.BetegID = null;
            OnPropertyChanged("Mine");
            return SelectedIdopont;
        }

    }

    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
