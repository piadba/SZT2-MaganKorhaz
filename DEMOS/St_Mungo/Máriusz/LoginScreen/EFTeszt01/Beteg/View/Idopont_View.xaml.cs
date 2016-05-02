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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EFTeszt01.Models;
using EFTeszt01.Controllers;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for Idopont_View.xaml
    /// </summary>
    public partial class Idopont_View : UserControl
    {
        BetegMainController bc;
        public Idopont_View(BetegMainController betegController)
        {
            InitializeComponent();
            bc = betegController;
            this.DataContext = bc;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bc.SaveIdopont();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bc.DeleteIdopont();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        { 
        }
    }
}
