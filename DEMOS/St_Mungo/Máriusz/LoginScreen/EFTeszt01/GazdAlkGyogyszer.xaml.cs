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
    /// Interaction logic for GazdAlkGyogyszer.xaml
    /// </summary>
    public partial class GazdAlkGyogyszer : Window
    {
        Gyogyszer gyogyszer;
        public GazdAlkGyogyszer(Gyogyszer gyogyszer)
        {
            InitializeComponent();
            this.gyogyszer = gyogyszer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = gyogyszer;
            if (gyogyszer.Deleted!=0)
            {
                tbRendeles.Visibility = Visibility.Hidden;
                labelRendeles.Visibility = Visibility.Hidden;
                labelMennyiseg.Content = "Induló mennyiség:* ";
            }
            else
            {
                tbMennyiseg.IsEnabled = false;
                labelMennyiseg.Content = "Aktuális mennyiség:";
            }
        }



        private void OnlyNumeric(object sender, KeyEventArgs e)
        {
            if (!((e.Key>=Key.D0 && e.Key<=Key.D9) || 
                (e.Key>=Key.NumPad0 && e.Key<=Key.NumPad9)))
            {
                if (!(e.Key == Key.Back || e.Key == Key.Home || e.Key == Key.End || e.Key == Key.Left || e.Key == Key.Right || e.Key==Key.Delete || e.Key==Key.Tab))
                {
                    e.Handled = true;
                }
                
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement tb in gyogyszerGrid.Children)
            {
                if (tb.GetType() == typeof(TextBox)
                    && ((TextBox)tb).GetBindingExpression(TextBox.TextProperty) != null 
                    && string.IsNullOrEmpty(((TextBox)tb).Text)
                    )
                {
                    MessageBox.Show("A csillaggal jelölt mezők kitöltése kötelező!");
                    return;
                }
            }


            if (gyogyszer.Deleted == 0)
            {
                gyogyszer.Mennyiseg += int.Parse(tbRendeles.Text);
                this.DataContext = gyogyszer;
                Binding dbBinding = new Binding("Mennyiseg");
                dbBinding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
                tbMennyiseg.SetBinding(TextBox.TextProperty, dbBinding);

            }

            ((Gyogyszer)DataContext).Deleted = 0;

            tbMegnevezes.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            foreach (UIElement tb in gyogyszerGrid.Children)
            {
                if (tb.GetType() == typeof(TextBox)
                    && ((TextBox)tb).GetBindingExpression(TextBox.TextProperty) != null)
                {
                    ((TextBox)tb).GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            gyogyszer.UpdateThisBitch();
            this.DialogResult = true;
            this.Close();
            
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
