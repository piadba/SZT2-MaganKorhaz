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
using System.Collections.ObjectModel;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for GazdAlkMainWindow.xaml
    /// </summary>
    public partial class GazdAlkMainWindow : Window
    {
        People sessionUser;
        MungoSystem mungoSystem;
        ObservableCollection<Gyogyszer> gyogyszerek;
        ObservableCollection<KorhaziEszkozok_Fej> eszkozok_fej;
        ObservableCollection<KorhaziEszkoz> eszkozok;
        public GazdAlkMainWindow(MungoSystem mungoSystem,People sessionUser)
        {
            InitializeComponent();
            this.sessionUser = sessionUser;
            this.mungoSystem = mungoSystem;
            gyogyszerek = new ObservableCollection<Gyogyszer>(mungoSystem.Gyogyszer.Where(gy => gy.Deleted==0));
            eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef=>kef.Deleted==0));
            eszkozok = new ObservableCollection<KorhaziEszkoz>(mungoSystem.KorhaziEszkoz.Where(ke => ke.Deleted == 0));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            treeViewEszkoz.ItemsSource = eszkozok_fej;
        }
    }
}
