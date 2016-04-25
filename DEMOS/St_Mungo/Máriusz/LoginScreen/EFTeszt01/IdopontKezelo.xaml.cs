using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
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
    /// Interaction logic for IdopontKezelo.xaml
    /// </summary>
    public partial class IdopontKezelo : Window
    {
        MungoSystem mungoSystem;
        RecepciosViewModel recepciosViewModel;
        public IdopontKezelo(RecepciosViewModel recepciosViewModel)
        {
            InitializeComponent();
            this.recepciosViewModel = recepciosViewModel;

            mungoSystem = recepciosViewModel.MungoSystem;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            mungoSystem.People.Load();
       
            this.DataContext = recepciosViewModel;
            var orvosadatok = mungoSystem.People.Local.Where(x => x.Group == 2 && x.Deleted==0);
            foreach (var p in orvosadatok)
            {
                recepciosViewModel.Orvosok.Add(p);
            }
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mungoSystem.Idopontok.Load();
           
            People o = comboBox.SelectedItem as People;
            var idopontadatok = mungoSystem.Idopontok.Local.Where(x => x.OrvosID == o.PeopleID);
            foreach (var p in idopontadatok)
                recepciosViewModel.Idopontok.Add(p);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IdopontSzerkeszto isz = new IdopontSzerkeszto(recepciosViewModel, listBox.SelectedItem as Idopontok);
            this.Hide();
            isz.ShowDialog();
            this.Show();
        }
    }

    public class IdopontAdatok
    {
        DateTime datum;
        int peopleID;

        public IdopontAdatok(DateTime datum, int peopleID)
        {
            this.datum = datum;
            this.peopleID = peopleID;
        }
    }



    //public class OrvosAdatConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
