using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTeszt01
{
    public class BetegAdatai
    {
        public int PeopleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Nev { get; set; }
        public string Cim { get; set; }
        public string Nem { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string TAJ { get; set; }

        public int BetegID { get; set; }

    }

    public class IdopontIDBeteg
    {
        public int IdopontID { get; set; }

        public DateTime Datum { get; set; }
      
        public string TAJ { get; set; }
        public string  Nev { get; set; }

        public string OrvosNev { get; set; }
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
        ObservableCollection<BetegAdatai> betegek;
        public ObservableCollection<BetegAdatai> Betegek { get { return betegek; } }

        BetegAdatai kivalasztottBeteg;
        public BetegAdatai KivalasztottBeteg { get { return kivalasztottBeteg; } set { kivalasztottBeteg = value; } }
        ObservableCollection<Idopontok> idopontok;
        public ObservableCollection<Idopontok> Idopontok { get { return idopontok; } }

        ObservableCollection<IdopontIDBeteg> idopontAdatok;
        public  ObservableCollection<IdopontIDBeteg> IdopontAdatok { get { return idopontAdatok; } }


        public RecepciosViewModel(MungoSystem mungoSystem, People sessionUser)
        {
            this.mungoSystem = mungoSystem;
            this.sessionUser = sessionUser;
            orvosok = new ObservableCollection<People>();
            idopontok = new ObservableCollection<Idopontok>();
            betegek = new ObservableCollection<BetegAdatai>();
            idopontAdatok = new ObservableCollection<IdopontIDBeteg>();
        }
    }

}
