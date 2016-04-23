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
        public AdminWindow(MungoSystem mungoSystem)
        {
            InitializeComponent();
            this.mungoSystem = mungoSystem;
            comboBox.ItemsSource = new List<string> { "People" };
        }

        private void modositasButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (comboBox.SelectedIndex == 0)
            {
            //    var adatok = from People in mungoSystem.People
            //                 select new  {  People.UserName, People.Password, People.Group, People.Deleted };
                // dataGrid.ItemsSource = adatok;
              
                dataGrid.ItemsSource = mungoSystem.People.Local;
               // dataGrid.Columns.First().IsReadOnly = true;
            }
        }

        private void mentesButton_Click(object sender, RoutedEventArgs e)
        {

            
            Console.WriteLine(mungoSystem.SaveChanges());

        }
    }
}
