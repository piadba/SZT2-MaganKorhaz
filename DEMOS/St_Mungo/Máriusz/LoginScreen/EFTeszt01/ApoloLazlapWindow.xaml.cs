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
            lazlapGyogyszer = new ObservableCollection<KiadottGyogyszer>(ms.KiadottGyogyszer.Where(x => x.Deleted == 0 && x.Statusz == 11 && x.ForrasID == lazlap.LazlapID));

            listboxGyogyszerek.ItemsSource = lazlapGyogyszer;
        }
    }
}
