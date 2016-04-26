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
    /// Interaction logic for OrvosAsszisztensWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensWindow : Window
    {
        OrvosViewModel ovm;

        StMungoServiceClient smc;
        public OrvosAsszisztensWindow(People orvos, StMungoServiceClient smc)
        {
            this.smc = smc;
            ovm = OrvosViewModel.Get();
            ovm.Orvos = orvos;
            ovm.MungoSystemInitial(smc);
            InitializeComponent();
            smc = new StMungoServiceClient();
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
           
        }

        private void ujBetegBtn_Click(object sender, RoutedEventArgs e)
        {
            OrvosAsszisztensUjBetegWindow ubw = new OrvosAsszisztensUjBetegWindow(smc);
            ubw.Show();
        }

        private void kezelesFelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ovm.SelectedKezeles != null)
            {
                OrvosAsszisztensKezelesWindow oak = new OrvosAsszisztensKezelesWindow(false,smc);
                oak.ShowDialog();
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
                OrvosAsszisztensKezelesWindow oak = new OrvosAsszisztensKezelesWindow(true,smc);
                oak.ShowDialog();
            }
        }

        private void lazlapFelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ovm.SelectedBeteg != null)
            {
                OrvosAsszisztensLazlapWindow oal = new OrvosAsszisztensLazlapWindow(smc);
                oal.ShowDialog();
            }
        }

        private void igenyBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
