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
using System.Windows.Threading;
using System.Threading;
using System.Diagnostics;

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
        ObservableCollection<KiadottGyogyszer> kiadottGyogyszerek;
        ObservableCollection<KorhaziEszkozok_Fej> eszkozok_fej;
        ObservableCollection<KorhaziEszkoz> eszkozok;

        KorhaziEszkozok_Fej selectedGroup;
        KorhaziEszkoz selectedEszkoz;
        Gyogyszer selectedGyogyszer;
        //KiadottGyogyszer selectedKiadottGyogyszer;

        Task refreshTask;
        public GazdAlkMainWindow(MungoSystem mungoSystem,People sessionUser)
        {
            InitializeComponent();
            this.sessionUser = sessionUser;
            this.mungoSystem = mungoSystem;

            mungoSystem.Gyogyszer.Load();
            mungoSystem.KiadottGyogyszer.Load();
            mungoSystem.KorhaziEszkoz.Load();
            mungoSystem.KorhaziEszkozok_Fej.Load();
            mungoSystem.Kortortenet_fej.Load();
            mungoSystem.Kortortenet_tetel.Load();
            mungoSystem.Lazlap.Load();

            this.DataContext = sessionUser;
            refreshTask = new Task(Refresh);
            refreshTask.Start();
            gyogyszerek = new ObservableCollection<Gyogyszer>(mungoSystem.Gyogyszer.Where(gy => gy.Deleted==0));
            eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef=>kef.Deleted==0));
        }

        private void Refresh()
        {
            while (true)
            {
                Thread.Sleep(10000);
                try
                {
                    gyogyszerek = new ObservableCollection<Gyogyszer>(mungoSystem.Gyogyszer.Where(gy => gy.Deleted == 0));
                    eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                    Dispatcher.Invoke(() => listBoxEszkozGroup.ItemsSource = eszkozok_fej);
                    Dispatcher.Invoke(() => listBoxGyogyszer.ItemsSource = gyogyszerek);
                    if (selectedGroup != null)
                    {
                        eszkozok = new ObservableCollection<KorhaziEszkoz>
                       (mungoSystem.KorhaziEszkoz.Where(ke => ke.Deleted == 0 && ke.Eszkoz_FejID == selectedGroup.Eszkoz_FejID));
                        Dispatcher.Invoke(() => listBoxEszkoz.ItemsSource = eszkozok);
                    }
                    if (selectedGyogyszer != null)
                    {
                        kiadottGyogyszerek = new ObservableCollection<KiadottGyogyszer>(
                        mungoSystem.KiadottGyogyszer.Where(
                        x => x.GyogyszerID == selectedGyogyszer.GyogyszerID && x.Deleted == 0));
                        Dispatcher.Invoke(() => listBoxKiadottGyogyszer.ItemsSource = kiadottGyogyszerek);
                    }
                }
                catch (Exception)
                {
                    refreshTask = new Task(Refresh);
                    refreshTask.Start();
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBoxEszkozGroup.ItemsSource = eszkozok_fej;
            listBoxGyogyszer.ItemsSource = gyogyszerek;
        }

        private void listBoxEszkozGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((KorhaziEszkozok_Fej)listBoxEszkozGroup.SelectedItem != null)
            {
                selectedGroup = (KorhaziEszkozok_Fej)listBoxEszkozGroup.SelectedItem;
                eszkozok = new ObservableCollection<KorhaziEszkoz>
                    (mungoSystem.KorhaziEszkoz.Where(ke => ke.Deleted == 0 && ke.Eszkoz_FejID == selectedGroup.Eszkoz_FejID));
                listBoxEszkoz.ItemsSource = eszkozok;
            }
        }

        private void newEszkozGroup_Click(object sender, RoutedEventArgs e)
        {
            KorhaziEszkozok_Fej newFej = new KorhaziEszkozok_Fej() { Deleted = 2 ,Statusz=false};
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
            if (listBoxEszkozGroup.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else if (mungoSystem.KorhaziEszkoz.Where(x=>x.Deleted==0 && 
            x.Eszkoz_FejID==selectedGroup.Eszkoz_FejID).Count()>0)
            {
                MessageBox.Show("Csak üres csoport törölhető!");
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
                    mungoSystem.SaveChanges();
                    foreach (KorhaziEszkozok_Fej item in mungoSystem.KorhaziEszkozok_Fej.Where(x => x.Deleted == 0))
                    {
                        item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                    }
                    eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                    listBoxEszkozGroup.ItemsSource = eszkozok_fej;
                }
                
            }
        }

        private void newEszkoz_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGroup!=null)
            {
                KorhaziEszkoz newEszkoz = new KorhaziEszkoz() { Deleted = 2, Eszkoz_FejID = selectedGroup.Eszkoz_FejID, Statusz = false };
                EszkozAddModWindow eamw = new EszkozAddModWindow(newEszkoz,mungoSystem,false,sessionUser);
                mungoSystem.KorhaziEszkoz.Add(newEszkoz);
                eamw.ShowDialog();
                if (newEszkoz.Deleted == 0 && newEszkoz.Eszkoz_FejID==selectedGroup.Eszkoz_FejID)
                {
                    eszkozok.Add(newEszkoz);
                }
                mungoSystem.SaveChanges();
                foreach (KorhaziEszkozok_Fej item in mungoSystem.KorhaziEszkozok_Fej.Where(x => x.Deleted == 0))
                {
                    item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                }
                eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                listBoxEszkozGroup.ItemsSource = eszkozok_fej;
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
                    (selectedEszkoz,mungoSystem,false,sessionUser);
                if (eamw.ShowDialog() == true)
                {
                    //int? fejID = selectedEszkoz.Eszkoz_FejID;
                    if (selectedEszkoz.Eszkoz_FejID!=selectedGroup.Eszkoz_FejID)
                    {
                        eszkozok.Remove(selectedEszkoz);
                        selectedEszkoz = null;
                    }
                    //mungoSystem.KorhaziEszkozok_Fej.Where(x => x.Eszkoz_FejID == fejID).Single()
                    //        .Statusz = getgroupIgenyState(fejID);

                    mungoSystem.SaveChanges();
                    foreach (KorhaziEszkozok_Fej item in eszkozok_fej)
                    {
                        item.Statusz = getgroupIgenyState(item.Eszkoz_FejID);
                    }
                    mungoSystem.SaveChanges();
                    eszkozok_fej = new ObservableCollection<KorhaziEszkozok_Fej>(mungoSystem.KorhaziEszkozok_Fej.Where(kef => kef.Deleted == 0));
                    listBoxEszkozGroup.ItemsSource = eszkozok_fej;
                }
            }
        }

        private bool getgroupIgenyState(int? igenyFejID)
        {
            //true: van benne igény
            //false: nincs benne igény
            bool vanIgeny=false;
            if (mungoSystem.KorhaziEszkoz.Where(x=>x.Deleted==0 && x.Statusz==true && x.Eszkoz_FejID==igenyFejID).Count()>0)
            {
                vanIgeny = true;
            }
            return vanIgeny;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            IgenyMainWindow imw = new IgenyMainWindow(sessionUser, mungoSystem);
            imw.ShowDialog();
        }

    

        private void listBoxGyogyszer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxGyogyszer.SelectedItem != null)
            {
                selectedGyogyszer = (Gyogyszer)listBoxGyogyszer.SelectedItem;
                kiadottGyogyszerek = new ObservableCollection<KiadottGyogyszer>(
                    mungoSystem.KiadottGyogyszer.Where(
                    x => x.GyogyszerID == selectedGyogyszer.GyogyszerID && x.Deleted == 0));
                listBoxKiadottGyogyszer.ItemsSource = kiadottGyogyszerek;
            }

        }

        private void buttonRendMod_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGyogyszer!=null)
            {
                GazdAlkGyogyszer gag = new GazdAlkGyogyszer(selectedGyogyszer);
                if (gag.ShowDialog() == true)
                {
                    mungoSystem.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Nincs kijelölve elem!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void buttonNewgyogyszer_Click(object sender, RoutedEventArgs e)
        {
            Gyogyszer ujGyogyszer = new Gyogyszer() {Deleted=2 };
            GazdAlkGyogyszer gag = new GazdAlkGyogyszer(ujGyogyszer);
            mungoSystem.Gyogyszer.Add(ujGyogyszer);
            if (gag.ShowDialog()==true)
            {
                gyogyszerek.Add(ujGyogyszer);
            }
            mungoSystem.SaveChanges();

         
        }

        private void buttonGyogyszerdel_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxGyogyszer.SelectedItem == null)
            {
                MessageBox.Show("Nincs kijelölt elem!");
            }
            else if (listBoxKiadottGyogyszer.Items.Count>0)
            {
                MessageBox.Show("A gyógyszer kiadásra vár, ezért nem törölhető!");
            }
            else
            {
                if (MessageBox.Show("Valóban törli?", "Törlés megerősítése", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedGyogyszer = (Gyogyszer)listBoxGyogyszer.SelectedItem;
                    selectedGyogyszer.Deleted = 1;
                    gyogyszerek.Remove(selectedGyogyszer);
                }
                mungoSystem.SaveChanges();
            }
        }

        private void buttonLogoug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.ShowDialog();
        }
    }
}
