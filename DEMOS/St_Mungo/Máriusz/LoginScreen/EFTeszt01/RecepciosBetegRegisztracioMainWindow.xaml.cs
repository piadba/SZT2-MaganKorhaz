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
    /// Interaction logic for RecepciosBetegRegisztracioMainWindow.xaml
    /// </summary>
    public partial class RecepciosBetegRegisztracioMainWindow : Window
    {
        RecepciosViewModel recepciosViewModel;
        MungoSystem mungoSystem;
        public RecepciosBetegRegisztracioMainWindow(RecepciosViewModel recepciosViewModel)
        {
            InitializeComponent();
            this.recepciosViewModel = recepciosViewModel;
            mungoSystem = recepciosViewModel.MungoSystem;
            this.DataContext = recepciosViewModel;

        }

        void initWindow()
        {
            mungoSystem.Betegek.Load();

            var betegek = from b in mungoSystem.Betegek
                          join p in mungoSystem.People on b.PeopleID equals p.PeopleID
                          where b.Deleted == 0 && p.Deleted == 0
                          select new { TAJ = b.TAJ, Nev = p.Name, BetegID = b.BetegID, PeopleID = b.PeopleID };

            recepciosViewModel.Betegek.Clear();

            foreach (var b in betegek)
            {
                recepciosViewModel.Betegek.Add(new BetegAdatai { TAJ = b.TAJ, Nev = b.Nev, BetegID = b.BetegID, PeopleID = (int)b.PeopleID });
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            initWindow();

        }

        private void ujButton_Click(object sender, RoutedEventArgs e)
        {
     
            RecepciosBetegModositoWindow bm = new RecepciosBetegModositoWindow(recepciosViewModel, null);
            bm.ShowDialog();
            initWindow();
        }

        private void modositasButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                BetegAdatai kiv = (listBox.SelectedItem) as BetegAdatai;
                Betegek b = mungoSystem.Betegek.Local.Where(x => x.PeopleID == kiv.PeopleID).First();
                RecepciosBetegModositoWindow bm = new RecepciosBetegModositoWindow(recepciosViewModel, b);
                bm.ShowDialog();
                initWindow();
            }
            else
                MessageBox.Show("Nincs kiválasztott beteg");
        }
    }
}
