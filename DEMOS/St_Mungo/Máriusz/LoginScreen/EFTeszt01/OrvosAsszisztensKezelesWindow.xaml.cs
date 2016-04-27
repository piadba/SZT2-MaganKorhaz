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
    /// Interaction logic for OrvosAsszisztensKezelesWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensKezelesWindow : Window
    {
        OrvosViewModel ovm;
        bool AddMod;
        public OrvosAsszisztensKezelesWindow(bool addmod)
        {
            this.AddMod = addmod;
            ovm = OrvosViewModel.Get();
            InitializeComponent();
            this.DataContext = ovm;
            if (addmod)
            {
                datumDP.SelectedDate = ovm.SelectedKezeles.Datum;
                orvosTB.Text = (ovm.SelectedKezeles.Orvos).ToString();
                kezlesTB.Text = ovm.SelectedKezeles.Kezeles;
            }
            else {
                datumDP.SelectedDate = DateTime.Now;
                orvosTB.Text = null;
                kezlesTB.Text = "";
            }

        }

        private void mentesBTN(object sender, RoutedEventArgs e)
        {
            if (AddMod)
            {
                Kortortenet_tetel kt = new Kortortenet_tetel() { Datum = datumDP.SelectedDate, Orvos = int.Parse(orvosTB.Text), Kezeles = kezlesTB.Text, Deleted = ovm.SelectedKezeles.Deleted, KortortenetFejID = ovm.SelectedKezeles.KortortenetFejID, KortortenetTetelID = ovm.SelectedKezeles.KortortenetTetelID };

                ovm.KezelesModositas(kt);
            }
            else{
                Kortortenet_tetel kt = new Kortortenet_tetel() { Datum = datumDP.SelectedDate, Orvos = int.Parse(orvosTB.Text), Kezeles = kezlesTB.Text, Deleted = 0};
                ovm.KezelesLetrehozas(kt);
            }
            this.Close();
        }

        private void megseBTN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
