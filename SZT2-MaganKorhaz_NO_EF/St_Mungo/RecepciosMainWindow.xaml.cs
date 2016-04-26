﻿
using St_Mungo.StMungo_WCF;
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
        StMungoServiceClient smc;
        public RecepciosMainWindow(People sessionUser, StMungoServiceClient smc)
        {
            this.smc = smc;
            InitializeComponent();
            recepciosViewModel = new RecepciosViewModel(smc.mungoSystem(),sessionUser);
    
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IdopontKezelo ik = new IdopontKezelo(recepciosViewModel,smc);
         
            ik.ShowDialog();
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
