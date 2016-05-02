using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTeszt01.Models;

namespace EFTeszt01.Controllers
{
    public class DBController
    {
        MungoSystem Database;
        public BetegAdatok getBetegAdatok(int peopleID)
        {
            var betegInfo = Database.Betegek.FirstOrDefault(x => x.PeopleID == peopleID);
            var pplInfo = Database.People.FirstOrDefault(x => x.PeopleID == peopleID);
            BetegAdatok value = new BetegAdatok(betegInfo, pplInfo);
            return value;
        }
        public string getOrvosById(int peopleID)
        {
            var a = Database.People.FirstOrDefault(x => x.PeopleID == peopleID).Name;
            return a;
        }
        public ObservableCollection<Kortortenet> getKortortenetekByBetegId(int betegID)
        {
            var adatok = new ObservableCollection<Kortortenet>();
            var kortortenetfej = Database.Kortortenet_fej.Where(x => x.BetegID == betegID).FirstOrDefault();
            var tetelek = Database.Kortortenet_tetel.Where(x => x.KortortenetFejID == kortortenetfej.KortortenetFejID);
            foreach (var item in tetelek)
            {
                adatok.Add(new Kortortenet(kortortenetfej, item));
            }
            return adatok;
        }
        public ObservableCollection<Idopont> getAllIdopont()
        {
            var adatok = new ObservableCollection<Idopont>();
            var tetelek = Database.Idopontok.Where(x => x.Deleted == 0);
            foreach (var item in tetelek)
            {
                adatok.Add(new Idopont(item));
            }
            return adatok;
        }
        public ObservableCollection<Idopont> getPossibleIdopont(int? betegId)
        {
            var adatok = new ObservableCollection<Idopont>();
            if (betegId.HasValue)
            {
                var tetelek = Database.Idopontok.Where(x => x.Deleted == 0 && (x.BetegID == betegId.Value || x.BetegID == null));
                foreach (var item in tetelek)
                {
                    adatok.Add(new Idopont(item));
                }
                return adatok;
            }
            return getAllIdopont();
        }
        public DBController(MungoSystem db)
        {
            Database = db;
        }
        public void IdopontSaveChanges(Idopont ipk)
        {
            Database.Idopontok.Attach(ipk.IdopontElem);
            var entry = Database.Entry(ipk.IdopontElem);
            entry.State = System.Data.EntityState.Modified;
            Database.SaveChanges();
        }

        public void Beteg_SaveChanges(BetegAdatok beteg)
        {
            Database.People.Attach(beteg.peopleElem);
            var entry = Database.Entry(beteg.peopleElem);
            entry.State = System.Data.EntityState.Modified;

            Database.Betegek.Attach(beteg.betegekElem);
            var entry2 = Database.Entry(beteg.betegekElem);
            entry2.State = System.Data.EntityState.Modified;

            Database.SaveChanges();
        }
    }
}
