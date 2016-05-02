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
using EFTeszt01.Controllers;
using EFTeszt01.Models;

namespace EFTeszt01

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BetegWindow : Window
    {
        private BetegMainController controller;
        public BetegWindow(MungoSystem mungoSys,People sessionUsr)
        {
            InitializeComponent();
            controller = new BetegMainController(mungoSys,sessionUsr);
        }
        public BetegWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = controller;
        }

        private void AdatmodositasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            controller.SetView(ViewTypes.Adatok);
        }
        private void IdopontMenuItem_Click(object sender, RoutedEventArgs e)
        {
            controller.SetView(ViewTypes.Idopont);
        }
        private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.ShowDialog();
        }
    }
}
