using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTeszt01
{
    public class BetegTajIDNev
    {
        public string TAJ { get; set; }
        public string Nev { get; set; }
        public int PeopleID { get; set; }
        public int BetegID { get; set; }
    }
    public class RecepciosViewModel
    {
        MungoSystem mungoSystem;
        People sessionUser;

        public MungoSystem MungoSystem { get { return mungoSystem; } }

        public People SessionUser { get { return sessionUser; } }
        ObservableCollection<People> orvosok;

        public ObservableCollection<People> Orvosok
        { get { return orvosok; } }
        ObservableCollection<BetegTajIDNev> betegek;
        public ObservableCollection<BetegTajIDNev> Betegek { get { return betegek; } }
        ObservableCollection<Idopontok> idopontok;
        public ObservableCollection<Idopontok> Idopontok { get { return idopontok; } }


        public RecepciosViewModel(MungoSystem mungoSystem, People sessionUser)
        {
            this.mungoSystem = mungoSystem;
            this.sessionUser = sessionUser;
            orvosok = new ObservableCollection<People>();
            idopontok = new ObservableCollection<Idopontok>();
            betegek = new ObservableCollection<BetegTajIDNev>();
        }
    }

}
