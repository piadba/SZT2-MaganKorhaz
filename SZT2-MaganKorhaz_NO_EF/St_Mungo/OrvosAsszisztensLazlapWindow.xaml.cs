﻿using St_Mungo.StMungo_WCF;
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
    /// Interaction logic for OrvosAsszisztensLazlapWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensLazlapWindow : Window
    {
        OrvosViewModel ovm;
        StMungoServiceClient smc;
        public OrvosAsszisztensLazlapWindow(StMungoServiceClient smc)
        {
            this.smc = smc;
            ovm = OrvosViewModel.Get();
            InitializeComponent();
            ovm.SelectedBetegLazlapja();
            ovm.SelectedBetegGyogyszerei();
            this.DataContext = ovm;
        }

        private void mentesBTN_Click(object sender, RoutedEventArgs e)
        {
            ovm.SelectedBetegLazlapMentes();
            ovm.BetegGyogyszerei.Clear();
            ovm.BetegLazlapja = null;
            this.Close();
        }

        private void megseBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gyogyBTN_Click(object sender, RoutedEventArgs e)
        {
            OrvosAsszisztensGyogyszerWindow ogyw = new OrvosAsszisztensGyogyszerWindow(smc);
            ogyw.ShowDialog();
        }

        private void gyogyDelBTN_Click(object sender, RoutedEventArgs e)
        {
            
            KiadottGyogyszer kgy =  ovm.GyogyszerNevToKiadott(listBox.SelectedItem as string);
            ovm.SelectedGyogyszerTorles(kgy);
        }
    }
}
