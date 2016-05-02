using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTeszt01.Controllers;

namespace EFTeszt01.Models
{
    public class Idopont
    {
        public Idopontok IdopontElem { get; set; }
        string o;
        public DateTime Datum { get { return IdopontElem.Datum.Value; } }
        public string Orvos { get { return o; } }
        public int? betegID { get { return IdopontElem.BetegID.HasValue?IdopontElem.BetegID.Value:0; } set { IdopontElem.BetegID = value; } }
        public override bool Equals(object obj)
        {
            if (obj is Idopont)
            {
                var a = obj as Idopont;
                return Datum.Equals(a.Datum) && Orvos.Equals(a.Orvos);
            }
            return false;
        }
        public Idopont(Idopontok idopontelem)
        {
            IdopontElem = idopontelem;
            o= BetegMainController.dbController.getOrvosById(IdopontElem.OrvosID.Value);
        }
    }
    public class BetegAdatok : Bindable
    {
        public Betegek betegekElem { get; set; }
        public People peopleElem { get; set; }

        public string Address { get { return peopleElem.Address; } set { peopleElem.Address = value; OnPropertyChanged(); } }
        public int BetegID { get { return betegekElem.BetegID; } }
        public string Email { get { return peopleElem.Email; } set { peopleElem.Email = value; OnPropertyChanged(); } }
        public string Gender { get { return peopleElem.Gender; } set { peopleElem.Gender = value; OnPropertyChanged(); } }
        public string Name { get { return peopleElem.Name; } set { peopleElem.Name = value; OnPropertyChanged(); } }
        public string Password { get { return peopleElem.Password; } set { peopleElem.Password = value; OnPropertyChanged(); } }
        public int PeopleID { get { return peopleElem.PeopleID; } }
        public string Phone { get { return peopleElem.Phone; } set { peopleElem.Phone = value; OnPropertyChanged(); } }
        public string UserName { get { return peopleElem.UserName; } set { peopleElem.UserName = value; OnPropertyChanged(); } }
        public string TAJ { get { return betegekElem.TAJ; } set { betegekElem.TAJ = value; OnPropertyChanged(); } }
        /*
        public string MothersName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MaidenName { get; set; }
        */
        Kortortenet act;
        public Kortortenet ActKortortenet { get { return act; } set { act = value; OnPropertyChanged(); } }

        public ObservableCollection<Idopont> idopontok { get; set; }
        public ObservableCollection<Kortortenet> Kortortenet { get; set; }
        public void changed()
        {
            OnPropertyChanged("idopontok");
            OnPropertyChanged("Kortortenet");
            ActKortortenet = Kortortenet.Count() > 0 ? Kortortenet[0] : null;
        }
        public BetegAdatok(Betegek betegelem, People pplelem)
        {
            betegekElem = betegelem;
            peopleElem = pplelem;
            idopontok = new ObservableCollection<Idopont>();
            Kortortenet = new ObservableCollection<Kortortenet>();

        }

    }
    public class Kortortenet
    {
        public Kortortenet_fej kortortFej { get; set; }
        public Kortortenet_tetel kortortTetel { get; set; }

        public DateTime? Datum { get { return kortortTetel.Datum; } }

        public string Kezeles { get { return kortortTetel.Kezeles; } }

        public string Orvos
        {
            get
            {
                int a = kortortTetel.Orvos!=null? kortortTetel.Orvos.Value:0;
                return BetegMainController.dbController.getOrvosById(a);
            }
        }
        public string toBind
        {
            get
            {
                return String.Format("Orvos: {0}\nKezelés:\n{1}", Orvos, Kezeles);
            }
        }
        public Kortortenet(Kortortenet_fej kfej, Kortortenet_tetel kttel)
        {
            kortortFej = kfej;
            kortortTetel = kttel;
        }
        public override string ToString()
        {
            string datum = Datum != null ? Datum.Value.ToShortDateString() : "-";
            return datum;
        }

    }
}
