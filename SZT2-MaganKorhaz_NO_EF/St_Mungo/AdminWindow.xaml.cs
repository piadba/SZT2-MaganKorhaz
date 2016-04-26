using St_Mungo.StMungo_WCF;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MungoSystem mungoSystem;
        StMungoServiceClient smc;
        public AdminWindow(MungoSystem mungoSystem)
        {
            smc = new StMungoServiceClient();
            InitializeComponent();
            this.mungoSystem = mungoSystem;
            this.DataContext = this.mungoSystem;
            comboBox.ItemsSource = new List<string> { "People", "LookUps", "Betegek", "Kórtörténet Fej", "Kórtörténet Tétel" };
        }

        private void modositasButton_Click(object sender, RoutedEventArgs e)
        {

            

            switch (comboBox.SelectedIndex)
            {
                case 0:

                    // dataGrid.ItemsSource = adatok;
                    smc.People_getLoad();
                    dataGrid.ItemsSource = smc.People_getLocal();

                    // dataGrid.Columns.First().IsReadOnly = true;
                    break;

                case 1:
                    smc.Lookups_getLoad();
                    dataGrid.ItemsSource = smc.Lookups_getLocal();
                    break;
                case 2:
                    smc.Betegek_getLoad();
                    dataGrid.ItemsSource = smc.Betegek_getLocal();
                    break;
                case 3:
                    smc.Kortortenet_fej_getLoad();
                    dataGrid.ItemsSource = smc.Kortortenet_fej_getLocal();
                    break;
                case 4:
                    smc.Kortortenet_tetel_getLoad();
                    dataGrid.ItemsSource = smc.Kortortenet_tetel_getLocal();
                    break;
            }
 
        }

        private void mentesButton_Click(object sender, RoutedEventArgs e)
        {

            
            //Console.WriteLine(mungoSystem.SaveChanges());

        }
    }
}
