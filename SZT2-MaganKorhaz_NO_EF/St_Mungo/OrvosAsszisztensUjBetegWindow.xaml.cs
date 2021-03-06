﻿using St_Mungo.StMungo_WCF;
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
    /// Interaction logic for OrvosAsszisztensUjBetegWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensUjBetegWindow : Window
    {
        OrvosViewModel ovm;
        StMungoServiceClient smc;
        public OrvosAsszisztensUjBetegWindow(StMungoServiceClient smc)
        {
            ovm = OrvosViewModel.Get();
            this.smc = smc;
            InitializeComponent();
            this.DataContext = ovm;
        }

        private void mentesBTN_Click(object sender, RoutedEventArgs e)
        {
            //ovm.Ms.People.Add(new People() { Name = nevTB.Text, Address = lakcimTB.Text, Gender = nemTB.Text, Email = emailTB.Text, Password = jszTB.Text, Phone = telTB.Text, Deleted = 0, Group = 4, UserName = felhTB.Text });
            //ovm.Mentes();
            //ovm.Ms.People.Load();
            //int id = ovm.Ms.People.Local.Where(elem => elem.Name == nevTB.Text).First().PeopleID;
            //ovm.Ms.Betegek.Add(new Betegek() { Deleted = 0, PeopleID = id, TAJ=tajTB.Text});
            //ovm.Mentes();
            //ovm.Ms.Betegek.Load();

            //ovm.MungoSystemInitial(ovm.Ms);
            ovm.Ujbeteg(new People() { Name = nevTB.Text, Address = lakcimTB.Text, Gender = nemTB.Text, Email = emailTB.Text, Password = jszTB.Text, Phone = telTB.Text, Deleted = 0, Group = 1, UserName = felhTB.Text }, tajTB.Text);
            this.Close();
        }

        private void megsemBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
