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
using System.Data.Entity;
using System.Threading;

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
        Task refreshTask;
        public ApoloMainWindow(MungoSystem mungoSystem,People sessionUser)
        {
            InitializeComponent();
            this.mungoSystem = mungoSystem;
            this.sessionUser = sessionUser;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mungoSystem.Lazlap.Load();
            lazlapok = new ObservableCollection<Lazlap>(mungoSystem.Lazlap.Where(
                            lazlap => lazlap.Deleted == 0
                            && lazlap.Statusz == 7));
            LazlapListBox.ItemsSource = lazlapok;

            felvettLazlapok = new ObservableCollection<Lazlap>(mungoSystem.Lazlap.Where(
                            lazlap => lazlap.Deleted == 0 && lazlap.Statusz == 8 
                            && lazlap.ApoloID == sessionUser.PeopleID));
            SelfLazlapListBox.ItemsSource = felvettLazlapok;
            refreshTask = new Task(Refresh);
            refreshTask.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mungoSystem.ApoloMuszak.Load();
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
            mungoSystem.SaveChanges();
        }

        private void LazlapReszlet_Click(object sender, RoutedEventArgs e)
        {
            if (LazlapListBox.SelectedItem==null || LazlapListBox.IsEnabled==false)
            {
                MessageBox.Show("Nincs kijelölt lázlap");
            }
            else
            {
                ApoloLazlapWindow alw = new ApoloLazlapWindow
                     ((Lazlap)LazlapListBox.SelectedItem, sessionUser, mungoSystem);
                alw.ShowDialog();
            }
            mungoSystem.SaveChanges();
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
            mungoSystem.SaveChanges();
            
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
            mungoSystem.SaveChanges();
        }

        private void Refresh()
        {
            while (true)
            {
                Thread.Sleep(10000);
                try
                {
                    lazlapok = new ObservableCollection<Lazlap>(mungoSystem.Lazlap.Where(
                           lazlap => lazlap.Deleted == 0
                           && lazlap.Statusz == 7));
                    Dispatcher.Invoke(() => LazlapListBox.ItemsSource = lazlapok);
                }
                catch (Exception)
                {

                    return;
                }
                
            }
        }
    }
}
