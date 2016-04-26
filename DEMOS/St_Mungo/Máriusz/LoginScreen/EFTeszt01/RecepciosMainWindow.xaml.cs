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
            RecepciosIdopontKezeloWindow ik = new RecepciosIdopontKezeloWindow(recepciosViewModel);
         
            ik.ShowDialog();
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RecepciosErtesitesWindow ert = new RecepciosErtesitesWindow(recepciosViewModel);
            ert.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RecepciosBetegRegisztracioMainWindow br = new RecepciosBetegRegisztracioMainWindow(recepciosViewModel);
            br.ShowDialog();
        }
    }
}
