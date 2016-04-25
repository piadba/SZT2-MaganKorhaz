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
    /// Interaction logic for OrvosAsszisztensGyogyszerWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensGyogyszerWindow : Window
    {
        OrvosViewModel ovm;
        public OrvosAsszisztensGyogyszerWindow()
        {
            InitializeComponent();
            this.ovm = OrvosViewModel.Get();
            this.DataContext = ovm;
        }

        private void mentesBTN_Click(object sender, RoutedEventArgs e)
        {
            int id = ovm.LetezoGyogyszerVizsgalat(gyogyszerIDTB.Text);

            if (id != 0)
            {
                ovm.BetegGyogyszerei.Add(new KiadottGyogyszer() { ForrasID = ovm.BetegLazlapja.LazlapID, GyogyszerID = id, Mennyiseg = int.Parse(mennyTB.Text), Deleted = 0, Statusz = 11 });
                ovm.GyogyszerBeszurasTortent();
            }
            this.Close();
        }

        private void megseBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
