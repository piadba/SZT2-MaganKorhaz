﻿using System;
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
    /// Interaction logic for OrvosAsszisztensWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensWindow : Window
    {
        OrvosViewModel ovm;
   
        public OrvosAsszisztensWindow(MungoSystem ms, People orvos)
        {           
            ovm = OrvosViewModel.Get();
            ovm.Orvos = orvos;
            ovm.MungoSystemInitial(ms);
            InitializeComponent();
            this.DataContext = ovm;
        }

        private void felhModBtn_Click(object sender, RoutedEventArgs e)
        {
            OrvosAsszisztensFelhModWindow felhmodWindow = new OrvosAsszisztensFelhModWindow();
            felhmodWindow.Show();
        }

        private void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void selChanged(object sender, SelectionChangedEventArgs e)
        {
            ovm.SelectedBeteg = ovm.Betegek.ElementAt(betegLst.SelectedIndex);
           
        }

        private void ujBetegBtn_Click(object sender, RoutedEventArgs e)
        {
            OrvosAsszisztensUjBetegWindow ubw = new OrvosAsszisztensUjBetegWindow();
            ubw.Show();
        }
    }
}
