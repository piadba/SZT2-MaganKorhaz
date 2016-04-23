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
    /// Interaction logic for OrvosAsszisztensFelhModWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensFelhModWindow : Window
    {
        OrvosViewModel ovm;
        public OrvosAsszisztensFelhModWindow()
        {
            InitializeComponent();
            ovm = OrvosViewModel.Get();
            this.DataContext = ovm;
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            ovm.Orvos.UserName = felhTb.Text;
            ovm.Orvos.Password = jszTb.Text;
            ovm.Mentes();
            MessageBox.Show("Sikeres mentés!");
        }
    }
}
