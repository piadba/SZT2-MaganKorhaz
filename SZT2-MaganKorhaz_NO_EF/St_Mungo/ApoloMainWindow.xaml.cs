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
    /// Interaction logic for ApoloMainWindow.xaml
    /// </summary>
    public partial class ApoloMainWindow : Window
    {
        MungoSystem mungoSystem;
        People sessionUser;
        ObservableCollection<Lazlap> lazlapok;
        ObservableCollection<Lazlap> felvettLazlapok;
        StMungoServiceClient smc;
        public ApoloMainWindow(MungoSystem mungoSystem,People sessionUser)
        {
            InitializeComponent();
            smc = new StMungoServiceClient();
            this.mungoSystem = mungoSystem;
            this.sessionUser = sessionUser;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            smc.Lazlap_getLoad();
            lazlapok = new ObservableCollection<Lazlap>(mungoSystem.Lazlap.Where(
                            lazlap => lazlap.Deleted == 0
                            && lazlap.Statusz == 7));
            LazlapListBox.ItemsSource = lazlapok;

            felvettLazlapok = new ObservableCollection<Lazlap>(mungoSystem.Lazlap.Where(
                            lazlap => lazlap.Deleted == 0 && lazlap.Statusz == 8 
                            && lazlap.ApoloID == sessionUser.PeopleID));
            SelfLazlapListBox.ItemsSource = felvettLazlapok;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            smc.ApoloMuszak_getLoad();
            if (mungoSystem.ApoloMuszak.Where(am => am.Deleted==0 && am.PeopleID==sessionUser.PeopleID && am.EndDate==null).Count()>0)
            {
                mungoSystem.ApoloMuszak.Where(am => am.Deleted == 0 && am.PeopleID == sessionUser.PeopleID && am.EndDate == null).Single().EndDate = DateTime.Now;
                button.Content = "Műszak felvétele";
                LazlapListBox.IsEnabled = false;
                foreach (Lazlap item in felvettLazlapok.ToList())
                {
                    item.ApoloID = null;
                    item.Statusz = 7;
                    lazlapok.Add(item);
                    felvettLazlapok.Remove(item);
                }
            }
            else
            {
                mungoSystem.ApoloMuszak.Add(new ApoloMuszak { Deleted = 0, PeopleID = sessionUser.PeopleID, StartDate = DateTime.Now });
                button.Content = "Műszak leadása";
                LazlapListBox.IsEnabled = true;
            }
            smc.mungoSystemSave();
        }

        private void LazlapReszlet_Click(object sender, RoutedEventArgs e)
        {
            if (LazlapListBox.SelectedItem==null || LazlapListBox.IsEnabled==false)
            {
                MessageBox.Show("Nincs kijelölt lázlap");
            }
            else
            {
                
            }
            smc.mungoSystemSave();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mungoSystem.ApoloMuszak.Where(am => am.Deleted == 0 && am.PeopleID == sessionUser.PeopleID && am.EndDate == null).Count() > 0)
            {
                MessageBox.Show("Nem adta le a műszakot!");
                e.Cancel=true;
            }
        }

        private void LazlapAdd_Click(object sender, RoutedEventArgs e)
        {
            if (LazlapListBox.SelectedItem == null || LazlapListBox.IsEnabled == false)
            {
                MessageBox.Show("Nincs kijelölt lázlap!");
            }
            else
            {
                Lazlap selected = (Lazlap)LazlapListBox.SelectedItem;
                selected.ApoloID = sessionUser.PeopleID;
                selected.Statusz = 8;
                selected.UtolsoFelvetelDatum = DateTime.Now;
                lazlapok.Remove(selected);
                felvettLazlapok.Add(selected);
            }
            smc.mungoSystemSave();

        }

        private void LazlapRemove_Click(object sender, RoutedEventArgs e)
        {
            if (SelfLazlapListBox.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt lázlap!");
            }
            else
            {
                Lazlap selected = (Lazlap)SelfLazlapListBox.SelectedItem;
                selected.ApoloID = null;
                selected.Statusz = 7;
                lazlapok.Add(selected);
                felvettLazlapok.Remove(selected);
            }
            smc.mungoSystemSave();
        }
    }
}
