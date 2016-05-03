using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ApoloLazlapWindow.xaml
    /// </summary>
    public partial class ApoloLazlapWindow : Window
    {
        MungoSystem ms;
        Lazlap lazlap;
        People sessionUser;
        ObservableCollection<KiadottGyogyszer> lazlapGyogyszer;
        public ApoloLazlapWindow(Lazlap lazlap,People sessionUser,MungoSystem ms)
        {
            InitializeComponent();
            this.lazlap = lazlap;
            this.sessionUser = sessionUser;
            this.ms = ms;
            this.DataContext = lazlap;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ms.KiadottGyogyszer.Load();
            lazlapGyogyszer = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && x.Statusz == 11 && x.ForrasID == lazlap.LazlapID));
            listboxGyogyszerek.ItemsSource = lazlapGyogyszer;
            if (lazlap.ApoloID!=sessionUser.PeopleID)
            {
                textboxApoloMegjegyzes.IsEnabled = false;
                moreGyogyszer.Visibility = Visibility.Hidden;
                lessGyogyszer.Visibility = Visibility.Hidden;
                lezartCheckbox.Visibility = Visibility.Hidden;
            }
            if (lazlap.Statusz==9)
            {
                lezartCheckbox.IsChecked = true;
            }
        }

        private void moreGyogyszer_Click(object sender, RoutedEventArgs e)
        {
            if (listboxGyogyszerek.SelectedItem!=null)
            {
                KiadottGyogyszer kgy = (KiadottGyogyszer)listboxGyogyszerek.SelectedItem;
                if (kgy.Hasznalt<kgy.Mennyiseg || kgy.Hasznalt==null)
                {
                    if (kgy.Hasznalt==null)
                    {
                        kgy.Hasznalt = 0;
                    }
                    kgy.Hasznalt++;
                }
                else
                {
                    MessageBox.Show("Az előírtnál nem adható ki több gyógyszer!");
                }
                ms.SaveChanges();
                lazlapGyogyszer = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && x.Statusz == 11 && x.ForrasID == lazlap.LazlapID));
                listboxGyogyszerek.ItemsSource = lazlapGyogyszer;
            }
            else
            {
                MessageBox.Show("Nincs kijelölt gyógyszer!");
            }
        }

        private void lessGyogyszer_Click(object sender, RoutedEventArgs e)
        {
            if (listboxGyogyszerek.SelectedItem != null)
            {
                KiadottGyogyszer kgy = (KiadottGyogyszer)listboxGyogyszerek.SelectedItem;
                if (kgy.Hasznalt != 0 && kgy.Hasznalt != null)
                {
                    kgy.Hasznalt--;
                    ms.SaveChanges();
                    lazlapGyogyszer = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && x.Statusz == 11 && x.ForrasID == lazlap.LazlapID));
                    listboxGyogyszerek.ItemsSource = lazlapGyogyszer;
                }
            }
            else
            {
                MessageBox.Show("Nincs kijelölt gyógyszer!");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (lezartCheckbox.IsChecked==true)
            {
                lazlap.Statusz = 9;
                ms.SaveChanges();
            }
        }
    }
}
