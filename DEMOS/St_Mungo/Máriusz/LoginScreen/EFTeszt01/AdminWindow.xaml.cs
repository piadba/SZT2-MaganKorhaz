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
using System.Data.Entity;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MungoSystem mungoSystem;
        public AdminWindow(MungoSystem mungoSystem)
        {
            InitializeComponent();
            this.mungoSystem = mungoSystem;
            this.DataContext = this.mungoSystem;
            comboBox.ItemsSource = new List<string> { "People", "Betegek", "Időpontok", "Kórtörténet Fej", "Kórtörténet Tétel", "Gyógyszer" };
        }

        private void modositasButton_Click(object sender, RoutedEventArgs e)
        {

            

            switch (comboBox.SelectedIndex)
            {
                case 0:

                    // dataGrid.ItemsSource = adatok;
                    mungoSystem.People.Load();
                    dataGrid.ItemsSource = mungoSystem.People.Local;

                    // dataGrid.Columns.First().IsReadOnly = true;
                    break;
         
                case 1:
                    mungoSystem.Betegek.Load();
                    dataGrid.ItemsSource = mungoSystem.Betegek.Local;
                    break;

                case 2:
                    mungoSystem.Idopontok.Load();
                    dataGrid.ItemsSource = mungoSystem.Idopontok.Local;
                    break;

                case 3:
                    mungoSystem.Kortortenet_fej.Load();
                    dataGrid.ItemsSource = mungoSystem.Kortortenet_fej.Local;
                    break;
                case 4:
                    mungoSystem.Kortortenet_tetel.Load();
                    dataGrid.ItemsSource = mungoSystem.Kortortenet_tetel.Local;
                    break;

                case 5:
                    mungoSystem.Gyogyszer.Load();
                    dataGrid.ItemsSource = mungoSystem.Gyogyszer.Local;
                    break;

            }
 
        }

        private void mentesButton_Click(object sender, RoutedEventArgs e)
        {

            
            Console.WriteLine(mungoSystem.SaveChanges());

        }

        private void visszaButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();

            mw.ShowDialog();
        }
    }
}
