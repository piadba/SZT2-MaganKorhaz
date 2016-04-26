using St_Mungo.StMungo_WCF;
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
    /// Interaction logic for IgenyMainWindow.xaml
    /// </summary>
    public partial class IgenyMainWindow : Window
    {
        People sessionUser;
        ObservableCollection<KorhaziEszkozok_Fej> igenyCsoport;
        ObservableCollection<KorhaziEszkoz> igenyEszkoz;
        KorhaziEszkozok_Fej selectedGroup;
        KorhaziEszkoz selectedEszkoz;
        StMungoServiceClient smc;
        public IgenyMainWindow(People sessionUser, StMungoServiceClient smc)
        {
            InitializeComponent();
            this.sessionUser = sessionUser;
            DataContext = sessionUser;
            this.smc = smc;
            smc.KorhaziEszkozok_Fej_getLoad();
            smc.KorhaziEszkoz_getLoad();

            igenyCsoport = new ObservableCollection<KorhaziEszkozok_Fej>(
                smc.mungoSystem().KorhaziEszkozok_Fej.Where(x=>x.Deleted==0));
            listBoxEszkozGroupIgeny.ItemsSource = igenyCsoport;

            
        }

        private void newEszkozGroup_Click(object sender, RoutedEventArgs e)
        {
            KorhaziEszkozok_Fej newIgeny = new KorhaziEszkozok_Fej() {Deleted=2,Statusz=true };
            EszkozGroupAddWindow egaw = new EszkozGroupAddWindow(newIgeny,smc);
            egaw.ShowDialog();
            if (newIgeny.Deleted==0)
            {
                smc.mungoSystem().KorhaziEszkozok_Fej.Add(newIgeny);
                igenyCsoport.Add(newIgeny);
            }
            smc.mungoSystemSave();
        }

        private void groupDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEszkozGroupIgeny.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else
            {
                if (smc.mungoSystem().KorhaziEszkozok_Fej.Where(x=>x.Eszkoz_FejID==selectedGroup.Eszkoz_FejID)
                    .Single().Statusz!=true ||
                    smc.mungoSystem().KorhaziEszkoz.Where(x=>x.Eszkoz_FejID==selectedGroup.Eszkoz_FejID).Count()>0)
                {
                    MessageBox.Show("Csak igényelt, üres csoport törölhető!");
                }
                else if (MessageBox.Show("Valóban törli?", "Törlés megerősítése", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroupIgeny.SelectedItem;
                    selectedGroup.Deleted = 1;
                    igenyCsoport.Remove(selectedGroup);
                }
                smc.mungoSystemSave();
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
                    (selectedGroup,smc);
                if (egaw.ShowDialog() == true)
                {
                    smc.mungoSystemSave();
                }
            }
        }

        private void listBoxEszkozGroupIgeny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((KorhaziEszkozok_Fej)listBoxEszkozGroupIgeny.SelectedItem != null)
            {
                selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroupIgeny.SelectedItem;
                igenyEszkoz = new ObservableCollection<KorhaziEszkoz>
                    (smc.mungoSystem().KorhaziEszkoz.Where(ke => ke.Deleted == 0 && ke.Eszkoz_FejID == selectedGroup.Eszkoz_FejID && ke.Statusz==true));
                listBoxEszkozIgeny.ItemsSource = igenyEszkoz;
            }
        }

        private void newEszkoz_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGroup != null)
            {
                KorhaziEszkoz newEszkoz = new KorhaziEszkoz() { Deleted = 2, Eszkoz_FejID = selectedGroup.Eszkoz_FejID, Statusz = true };
                EszkozAddModWindow eamw = new EszkozAddModWindow(newEszkoz,true,sessionUser,smc);
                smc.mungoSystem().KorhaziEszkoz.Add(newEszkoz);
                eamw.ShowDialog();
                if (newEszkoz.Deleted == 0 && newEszkoz.Eszkoz_FejID == selectedGroup.Eszkoz_FejID)
                {
                    igenyEszkoz.Add(newEszkoz);
                }
                smc.mungoSystemSave();
                foreach (KorhaziEszkozok_Fej item in smc.mungoSystem().KorhaziEszkozok_Fej.Where(x => x.Deleted == 0))
                {
                    item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                }
                igenyCsoport = new ObservableCollection<KorhaziEszkozok_Fej>(smc.mungoSystem().KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
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
                    (selectedEszkoz, true,sessionUser,smc);
                if (eamw.ShowDialog() == true)
                {
                    if (selectedEszkoz.Eszkoz_FejID != selectedGroup.Eszkoz_FejID)
                    {
                        igenyEszkoz.Remove(selectedEszkoz);
                        selectedEszkoz = null;
                    }
                    smc.mungoSystemSave();
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
                    smc.mungoSystemSave();
                    foreach (KorhaziEszkozok_Fej item in smc.mungoSystem().KorhaziEszkozok_Fej.Where(x => x.Deleted == 0))
                    {
                        item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                    }
                    igenyCsoport = new ObservableCollection<KorhaziEszkozok_Fej>(smc.mungoSystem().KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                    listBoxEszkozGroupIgeny.ItemsSource = igenyCsoport;
                }

            }
        }
        private bool getgroupIgenyState(int? igenyFejID)
        {
            //true: van benne igény
            //false: nincs benne igény
            bool vanIgeny = false;
            if (smc.mungoSystem().KorhaziEszkoz.Where(x => x.Deleted == 0 && x.Statusz == true && x.Eszkoz_FejID == igenyFejID).Count() > 0)
            {
                vanIgeny = true;
            }
            return vanIgeny;
        }
    }
}
