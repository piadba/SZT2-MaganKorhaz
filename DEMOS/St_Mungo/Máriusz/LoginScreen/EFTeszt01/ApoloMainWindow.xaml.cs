using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.Entity;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for ApoloMainWindow.xaml
    /// </summary>
    public partial class ApoloMainWindow : Window
    {

        MungoSystem mungoSystem;
        People sessionUser;
        List<Lazlap> lazlapok;
        public ApoloMainWindow(MungoSystem mungoSystem,People sessionUser)
        {
            InitializeComponent();
            this.mungoSystem = mungoSystem;
            this.sessionUser = sessionUser;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mungoSystem.Lazlap.Load();
            lazlapok = mungoSystem.Lazlap.Where(lazlap => lazlap.Deleted == 0 && lazlap.Statusz == 7).ToList();
            LazlapListBox.ItemsSource = lazlapok;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            int d = DateTime.Now.Day;
            DateTime ma = new DateTime(y, m, d);
            mungoSystem.ApoloMuszak.Load();
            if (mungoSystem.ApoloMuszak.Where(am => am.Datum == ma
                    && am.PeopleID == sessionUser.PeopleID && am.Deleted == 0).Count() > 1)
            {
                mungoSystem.ApoloMuszak.Where(am => am.Datum == ma
                     && am.PeopleID == sessionUser.PeopleID && am.Deleted == 0)
                     .OrderByDescending(x => x.ApoloMuszakID)
                     .First().Deleted = 1;
                button.Content = "Műszak felvétele";
            }
            else
            {
                mungoSystem.ApoloMuszak.Add(new ApoloMuszak() { Datum = ma, PeopleID = sessionUser.PeopleID, Deleted = 0 });
                button.Content = "Műszak leadása";
            }
            
            mungoSystem.SaveChanges();
        }
    }
}
