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
            lazlapok = mungoSystem.Lazlap.Where(lazlap => lazlap.Deleted == 0 && lazlap.Statusz == 7).ToList();
            LazlapListBox.ItemsSource = lazlapok;
        }
    }
}
