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
            ovm.OrvosGyogyszerKiadas();
        }

        private void ujBetegBtn_Click(object sender, RoutedEventArgs e)
        {
            OrvosAsszisztensUjBetegWindow ubw = new OrvosAsszisztensUjBetegWindow();
            ubw.Show();
        }

        private void kezelesFelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ovm.SelectedBeteg != null)
            {
                OrvosAsszisztensKezelesWindow oak = new OrvosAsszisztensKezelesWindow(false);
                oak.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kijelölt beteg!");
            }
        }

        private void kezelesChanged(object sender, SelectionChangedEventArgs e)
        {
            ovm.SelectedKezeles = ovm.SelectedKorlapTetel.ElementAt(adatlapLst.SelectedIndex);
        }

        private void korlapModBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ovm.SelectedKezeles != null)
            {
                OrvosAsszisztensKezelesWindow oak = new OrvosAsszisztensKezelesWindow(true);
                oak.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kijelölt kezelés!");
            }
        }

        private void lazlapFelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ovm.SelectedBeteg != null)
            {
                OrvosAsszisztensLazlapWindow oal = new OrvosAsszisztensLazlapWindow(ovm.Orvos);
                oal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs kijelölt beteg!");
            }
        }

        private void igenyBTN_Click(object sender, RoutedEventArgs e)
        {
            IgenyMainWindow imw = ovm.IgenyNyito();
            imw.ShowDialog();
        }

        private void kijelentkezesBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            ovm.SelectedBeteg = null;
            mw.ShowDialog();
        }

        private void gyogyadBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ovm.SelectedBeteg != null)
            {
                OrvosAsszisztensGyogyszerWindow ogyw = new OrvosAsszisztensGyogyszerWindow(false,ovm.Orvos);
                ogyw.ShowDialog();
            }
            else
                MessageBox.Show("Nincs kijelölt beteg!");
        }

        private void gyogydelBTN_Click(object sender, RoutedEventArgs e)
        { 
            if (ovm.SelectedBeteg != null)
            {
                ovm.OrvosGyogyszerTorles(orvosGyogyLST.SelectedItem as KiadottGyogyszer);
            }
            else
                MessageBox.Show("Nincs kijelölt beteg!");
        }
    }
}
