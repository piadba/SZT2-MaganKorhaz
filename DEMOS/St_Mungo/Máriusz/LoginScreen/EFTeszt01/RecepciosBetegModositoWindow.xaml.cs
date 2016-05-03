using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for RecepciosBetegModositoWindow.xaml
    /// </summary>
    public partial class RecepciosBetegModositoWindow : Window
    {
        RecepciosViewModel recepciosViewModel;
        MungoSystem mungoSystem;
        Betegek kivbet;
        People kivpeo;

        public RecepciosBetegModositoWindow(RecepciosViewModel recepciosViewModel, Betegek kivalasztottBeteg)
        {
            InitializeComponent();

            this.recepciosViewModel = recepciosViewModel;
            mungoSystem = recepciosViewModel.MungoSystem;
            mungoSystem.People.Load();
            mungoSystem.Betegek.Load();


            if (kivalasztottBeteg != null)
            {
                var beteg = from b in mungoSystem.Betegek
                              join p in mungoSystem.People on b.PeopleID equals p.PeopleID
                              where p.PeopleID == kivalasztottBeteg.PeopleID && b.BetegID == kivalasztottBeteg.BetegID
                              select new BetegAdatai() { PeopleID = p.PeopleID, UserName = p.UserName, Password = p.Password, Nev = p.Name,
                              Cim = p.Address, Nem= p.Gender, Email = p.Email, Phone=p.Phone, TAJ = b.TAJ, BetegID = b.BetegID};

                recepciosViewModel.KivalasztottBeteg = beteg.First();
                this.DataContext = recepciosViewModel.KivalasztottBeteg;      

                kivbet = mungoSystem.Betegek.Local.Where(x => x.BetegID == kivalasztottBeteg.BetegID).First();
                kivpeo = mungoSystem.People.Local.Where(x => x.PeopleID == kivalasztottBeteg.PeopleID).First();
                                                 
            }

            else
            {
                BetegAdatai beteg = new BetegAdatai();
                recepciosViewModel.KivalasztottBeteg = beteg;
                this.DataContext = recepciosViewModel.KivalasztottBeteg;

            }
                          
            
        }

        private void mentesBTN_Click(object sender, RoutedEventArgs e)
        {
            BetegAdatai beteg = recepciosViewModel.KivalasztottBeteg;

            if (kivbet != null && kivpeo != null)
            {
                kivbet.TAJ = beteg.TAJ;
                kivbet.Deleted = 0;
                kivpeo.Address = beteg.Cim;
                kivpeo.Deleted = 0;
                kivpeo.Email = beteg.Email;
                kivpeo.Gender = beteg.Nem;
                kivpeo.Group = 1;
                kivpeo.Name = beteg.Nev;
                kivpeo.Password = beteg.Password;
                kivpeo.Phone = beteg.Phone;
                kivpeo.UserName = beteg.UserName;

            }
            else
            {
                try
                {
                    People p = new People() { Address = beteg.Cim, Deleted = 0, Email = beteg.Email, Gender = beteg.Nem, Group = 1, Name = beteg.Nev, Password = beteg.Password, Phone = beteg.Phone, UserName = beteg.UserName };
                    mungoSystem.People.Local.Add(p);
                    Console.WriteLine(mungoSystem.SaveChanges());

                    mungoSystem.People.Load();

                    mungoSystem.Betegek.Load();
                    mungoSystem.Betegek.Local.Add(new Betegek() { Deleted = 0, PeopleID = p.PeopleID, TAJ = beteg.TAJ });

                    Console.WriteLine(mungoSystem.SaveChanges());

                    mungoSystem.Kortortenet_fej.Load();
                    mungoSystem.Betegek.Load();

                    mungoSystem.Kortortenet_fej.Local.Add(new Kortortenet_fej() { Deleted = 0, BetegID = mungoSystem.Betegek.Where(x => x.Deleted == 0 && x.PeopleID == p.PeopleID).First().BetegID });
                }
                catch (Exception ex2) { Console.WriteLine(ex2.Message); }
            }

            try

            {
                Console.WriteLine(mungoSystem.SaveChanges());
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach(var err in ex.EntityValidationErrors)
                    foreach(var err2 in err.ValidationErrors)
                        Console.WriteLine(err2.ErrorMessage);
            }

            DialogResult = true;
        }

        private void megsemBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void torlesBTN_Click(object sender, RoutedEventArgs e)
        {
            if (kivbet != null && kivpeo !=null)
            {
                kivbet.Deleted = 1;
                kivpeo.Deleted = 1;
                mungoSystem.SaveChanges();
                DialogResult = true;
            }

            DialogResult = false;
        }
    }
}
