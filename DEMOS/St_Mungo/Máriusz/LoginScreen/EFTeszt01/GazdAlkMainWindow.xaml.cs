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
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for GazdAlkMainWindow.xaml
    /// </summary>
    public partial class GazdAlkMainWindow : Window
    {
        People sessionUser;
        MungoSystem mungoSystem;
        ObservableCollection<Gyogyszer> gyogyszerek;
        ObservableCollection<KorhaziEszkozok_Fej> eszkozok_fej;
        ObservableCollection<KorhaziEszkoz> eszkozok;
        KorhaziEszkozok_Fej selectedGroup;
        KorhaziEszkoz selectedEszkoz;
        public GazdAlkMainWindow(MungoSystem mungoSystem,People sessionUser)
        {
            InitializeComponent();
            this.sessionUser = sessionUser;
            this.mungoSystem = mungoSystem;
            mungoSystem.Gyogyszer.Load();
            mungoSystem.KorhaziEszkoz.Load();
            mungoSystem.KorhaziEszkozok_Fej.Load();
            this.DataContext = sessionUser;
            gyogyszerek = new ObservableCollection<Gyogyszer>(mungoSystem.Gyogyszer.Where(gy => gy.Deleted==0));
            eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef=>kef.Deleted==0));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBoxEszkozGroup.ItemsSource = eszkozok_fej;
        }

        private void listBoxEszkozGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((KorhaziEszkozok_Fej)listBoxEszkozGroup.SelectedItem!=null)
            {
                selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroup.SelectedItem;
                eszkozok = new ObservableCollection<KorhaziEszkoz>
                    (mungoSystem.KorhaziEszkoz.Where(ke => ke.Deleted == 0 && ke.Eszkoz_FejID == selectedGroup.Eszkoz_FejID));
                listBoxEszkoz.ItemsSource = eszkozok;
            }
            
        }

        private void newEszkozGroup_Click(object sender, RoutedEventArgs e)
        {
            
            KorhaziEszkozok_Fej newFej = new KorhaziEszkozok_Fej() { Deleted = 2 };
            EszkozGroupAddWindow egaw = new EszkozGroupAddWindow(newFej);
            mungoSystem.KorhaziEszkozok_Fej.Add(newFej);
            egaw.ShowDialog();
            if (newFej.Deleted == 0)
            {
                eszkozok_fej.Add(newFej);
            }
            mungoSystem.SaveChanges();
        }
        private void GroupMod_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozGroup.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                EszkozGroupAddWindow egaw = new EszkozGroupAddWindow
                    (selectedGroup);
                if (egaw.ShowDialog()==true)
                {
                    mungoSystem.SaveChanges();                    
                }
            }
            
        }

        private void groupDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozGroup.SelectedItem==null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                if (MessageBox.Show("Valóban törli?", "Törlés megerősítése", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroup.SelectedItem;
                    selectedGroup.Deleted = 1;
                    eszkozok_fej.Remove(selectedGroup);
                }
                mungoSystem.SaveChanges();
            }
        }

        private void eszkozDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkoz.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                if (MessageBox.Show("Valóban törli?", "Törlés megerősítése", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedEszkoz = (KorhaziEszkoz)listBoxEszkoz.SelectedItem;
                    selectedEszkoz.Deleted = 1;
                    eszkozok.Remove(selectedEszkoz);
                }
                mungoSystem.SaveChanges();
            }
        }

        private void newEszkoz_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGroup!=null)
            {
                KorhaziEszkoz newEszkoz = new KorhaziEszkoz() { Deleted = 2, Eszkoz_FejID = selectedGroup.Eszkoz_FejID, Statusz = false };
                EszkozAddModWindow eamw = new EszkozAddModWindow(newEszkoz);
                mungoSystem.KorhaziEszkoz.Add(newEszkoz);
                eamw.ShowDialog();
                if (newEszkoz.Deleted == 0)
                {
                    eszkozok.Add(newEszkoz);
                }
                mungoSystem.SaveChanges();
            }
            else
            {
                MessageBox.Show("Nincs kijelölve csoport!");
            }
            
        }

        private void GroupMod_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkoz.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                selectedEszkoz = (KorhaziEszkoz)listBoxEszkoz.SelectedItem;
                EszkozAddModWindow eamw = new EszkozAddModWindow
                    (selectedEszkoz);
                if (eamw.ShowDialog() == true)
                {
                    mungoSystem.SaveChanges();
                }
            }
        }

        private void listBoxEszkoz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if ((KorhaziEszkoz)listBoxEszkoz.SelectedItem != null)
            //{
            //    selectedEszkoz = (KorhaziEszkoz)listBoxEszkoz.SelectedItem;
            //    eszkozok = new ObservableCollection<KorhaziEszkoz>
            //        (mungoSystem.KorhaziEszkoz.Where(ke => ke.Deleted == 0 && ke.Eszkoz_FejID == selectedGroup.Eszkoz_FejID));
            //    listBoxEszkoz.ItemsSource = eszkozok;
            //}
        }
    }
}
