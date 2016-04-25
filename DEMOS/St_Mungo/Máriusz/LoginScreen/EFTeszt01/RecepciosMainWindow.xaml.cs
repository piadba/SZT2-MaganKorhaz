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
    /// Interaction logic for RecepciosMainWindow.xaml
    /// </summary>
    public partial class RecepciosMainWindow : Window
    {
        RecepciosViewModel recepciosViewModel;
        public RecepciosMainWindow(MungoSystem mungoSystem, People sessionUser)
        {
            InitializeComponent();
            recepciosViewModel = new RecepciosViewModel(mungoSystem,sessionUser);
    
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IdopontKezelo ik = new IdopontKezelo(recepciosViewModel);
            ik.ShowDialog();
        }
    }
}
