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
    /// Interaction logic for OrvosAsszisztensGyogyszerWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensGyogyszerWindow : Window
    {
        OrvosViewModel ovm;
        bool LazlapVagyOrvos;
        People sessionuser;
        public OrvosAsszisztensGyogyszerWindow(bool lvo,People sessionuser)
        {

            InitializeComponent();
            this.ovm = OrvosViewModel.Get();
            LazlapVagyOrvos = lvo;

            this.sessionuser = sessionuser;

            this.DataContext = ovm;
            ObservableCollection<Gyogyszer> comboSource = new ObservableCollection<Gyogyszer>(ovm.Gyogyszerek.Where(x => x.Deleted == 0));
            gyogyszerCMB.ItemsSource = comboSource;
            // itt kell folytatnom 

            gyogyszerCMB.DisplayMemberPath = "Megnevezes";
            // comboCsoport.SelectedValuePath = "Eszkoz_FejID";
        }

        private void mentesBTN_Click(object sender, RoutedEventArgs e)
        {
            if (mennyTB.Text != "")
            {
                try
                {
                    int.Parse(mennyTB.Text);
                    int id = ovm.LetezoGyogyszerVizsgalat((gyogyszerCMB.SelectedItem as Gyogyszer).Megnevezes);

                    if (id != 0)
                    {
                        int mennyiseg = int.Parse(mennyTB.Text);
                        if (ovm.GyogyszerMennyisegMod(mennyiseg, id))
                        {
                            if (LazlapVagyOrvos)
                            {
                                
                                int megfeleloForrasid = ovm.GetLazlapID(ovm.SelectedBeteg.PeopleID);
                                ovm.BetegGyogyszerei.Add(new KiadottGyogyszer() { ForrasID = megfeleloForrasid, GyogyszerID = id, Mennyiseg = mennyiseg, Deleted = 0, Statusz = 11 });
                                ovm.GyogyszerBeszurasTortent();
                            }
                            else
                            {
                                ovm.OrvosGyogyszerBeszuras(new KiadottGyogyszer() { GyogyszerID = id, Mennyiseg = mennyiseg, Deleted = 0, Statusz = 10},sessionuser.PeopleID);
                            }
                            this.Close();
                        }
                        else { MessageBox.Show("Nincs elegendő, vagy nem létezik a gyógyszer!"); }
                    }

                }
                catch {
                    MessageBox.Show("HIBA: nem megfelelő a mennyiség formátuma!");
                }
            }
            else {
                MessageBox.Show("HIBA: nem lett mennyiség megadva!");
            } 
            
        }

        private void megseBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void gyogySelChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    OrvosAsszisztensGyogyszerKapcsolat gy = gyogyszerCMB.SelectedItem as OrvosAsszisztensGyogyszerKapcsolat;
        //    ovm.SelectedGyogyszer = 
        //}
    }
}
