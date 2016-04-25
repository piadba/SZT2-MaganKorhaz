using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Interaction logic for IgenyMainWindow.xaml
    /// </summary>
    public partial class IgenyMainWindow : Window
    {
        People sessionUser;
        MungoSystem ms;
        ObservableCollection<KorhaziEszkozok_Fej> igenyCsoport;
        ObservableCollection<KorhaziEszkoz> igenyEszkoz;
        KorhaziEszkozok_Fej selectedGroup;
        KorhaziEszkoz selectedEszkoz;
        public IgenyMainWindow(People sessionUser,MungoSystem ms)
        {
            InitializeComponent();
            this.sessionUser = sessionUser;
            DataContext = sessionUser;
            this.ms = ms;
            ms.KorhaziEszkozok_Fej.Load();
            ms.KorhaziEszkoz.Load();

            igenyCsoport = new ObservableCollection<KorhaziEszkozok_Fej>(
                ms.KorhaziEszkozok_Fej.Where(x=>x.Deleted==0));
            listBoxEszkozGroupIgeny.ItemsSource = igenyCsoport;

            
        }

        private void newEszkozGroup_Click(object sender, RoutedEventArgs e)
        {
            KorhaziEszkozok_Fej newIgeny = new KorhaziEszkozok_Fej() {Deleted=2,Statusz=true };
            EszkozGroupAddWindow egaw = new EszkozGroupAddWindow(newIgeny);
            egaw.ShowDialog();
            if (newIgeny.Deleted==0)
            {
                ms.KorhaziEszkozok_Fej.Add(newIgeny);
                igenyCsoport.Add(newIgeny);
            }
            ms.SaveChanges();
        }

        private void groupDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozGroupIgeny.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                if (ms.KorhaziEszkozok_Fej.Where(x=>x.Eszkoz_FejID==selectedGroup.Eszkoz_FejID)
                    .Single().Statusz!=true ||
                    ms.KorhaziEszkoz.Where(x=>x.Eszkoz_FejID==selectedGroup.Eszkoz_FejID).Count()>0)
                {
                    MessageBox.Show("Csak igényelt, üres csoport törölhető!");
                }
                else if (MessageBox.Show("Valóban törli?", "Törlés megerősítése", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroupIgeny.SelectedItem;
                    selectedGroup.Deleted = 1;
                    igenyCsoport.Remove(selectedGroup);
                }
                ms.SaveChanges();
            }
        }

        private void GroupMod_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozGroupIgeny.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                EszkozGroupAddWindow egaw = new EszkozGroupAddWindow
                    (selectedGroup);
                if (egaw.ShowDialog() == true)
                {
                    ms.SaveChanges();
                }
            }
        }

        private void listBoxEszkozGroupIgeny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((KorhaziEszkozok_Fej)listBoxEszkozGroupIgeny.SelectedItem != null)
            {
                selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroupIgeny.SelectedItem;
                igenyEszkoz = new ObservableCollection<KorhaziEszkoz>
                    (ms.KorhaziEszkoz.Where(ke => ke.Deleted == 0 && ke.Eszkoz_FejID == selectedGroup.Eszkoz_FejID && ke.Statusz==true));
                listBoxEszkozIgeny.ItemsSource = igenyEszkoz;
            }
        }

        private void newEszkoz_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGroup != null)
            {
                KorhaziEszkoz newEszkoz = new KorhaziEszkoz() { Deleted = 2, Eszkoz_FejID = selectedGroup.Eszkoz_FejID, Statusz = true };
                EszkozAddModWindow eamw = new EszkozAddModWindow(newEszkoz, ms,true,sessionUser);
                ms.KorhaziEszkoz.Add(newEszkoz);
                eamw.ShowDialog();
                if (newEszkoz.Deleted == 0 && newEszkoz.Eszkoz_FejID == selectedGroup.Eszkoz_FejID)
                {
                    igenyEszkoz.Add(newEszkoz);
                }
                ms.SaveChanges();
                foreach (KorhaziEszkozok_Fej item in ms.KorhaziEszkozok_Fej.Where(x => x.Deleted == 0))
                {
                    item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                }
                igenyCsoport = new ObservableCollection<KorhaziEszkozok_Fej>(ms.KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                listBoxEszkozGroupIgeny.ItemsSource = igenyCsoport;
            }
            else
            {
                MessageBox.Show("Nincs kijelölve csoport!");
            }
        }

        private void igenyEszkozmod_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozIgeny.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                selectedEszkoz = (KorhaziEszkoz)listBoxEszkozIgeny.SelectedItem;
                EszkozAddModWindow eamw = new EszkozAddModWindow
                    (selectedEszkoz, ms, true,sessionUser);
                if (eamw.ShowDialog() == true)
                {
                    if (selectedEszkoz.Eszkoz_FejID != selectedGroup.Eszkoz_FejID)
                    {
                        igenyEszkoz.Remove(selectedEszkoz);
                        selectedEszkoz = null;
                    }
                    ms.SaveChanges();
                }
            }
        }

        private void eszkozDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozIgeny.SelectedItem == null || ((KorhaziEszkoz)listBoxEszkozIgeny.SelectedItem).Statusz!=true)
            {
                MessageBox.Show("Csak felvett igény törölhető!");
            }
            else
            {
                if (MessageBox.Show("Valóban törli?", "Törlés megerősítése", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedEszkoz = (KorhaziEszkoz)listBoxEszkozIgeny.SelectedItem;
                    selectedEszkoz.Deleted = 1;
                    igenyEszkoz.Remove(selectedEszkoz);
                    ms.SaveChanges();
                    foreach (KorhaziEszkozok_Fej item in ms.KorhaziEszkozok_Fej.Where(x => x.Deleted == 0))
                    {
                        item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                    }
                    igenyCsoport = new ObservableCollection<KorhaziEszkozok_Fej>(ms.KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                    listBoxEszkozGroupIgeny.ItemsSource = igenyCsoport;
                }

            }
        }
        private bool getgroupIgenyState(int? igenyFejID)
        {
            //true: van benne igény
            //false: nincs benne igény
            bool vanIgeny = false;
            if (ms.KorhaziEszkoz.Where(x => x.Deleted == 0 && x.Statusz == true && x.Eszkoz_FejID == igenyFejID).Count() > 0)
            {
                vanIgeny = true;
            }
            return vanIgeny;
        }
    }
}
