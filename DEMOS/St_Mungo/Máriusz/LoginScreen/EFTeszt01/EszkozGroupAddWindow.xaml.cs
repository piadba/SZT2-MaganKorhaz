using System;
using System.Collections.Generic;
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
    /// Interaction logic for EszkozGroupAddWindow.xaml
    /// </summary>
    public partial class EszkozGroupAddWindow : Window
    {
        string originalMegnevezes;

        MungoSystem ms;
        public EszkozGroupAddWindow(KorhaziEszkozok_Fej elem,MungoSystem ms)
        {
            InitializeComponent();
            this.DataContext = elem;
            originalMegnevezes = elem.Megnevezes;
            this.ms = ms;
            ms.KorhaziEszkozok_Fej.Load();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("A megnevezés kitöltése kötelező!");
            }
            else
            {
                ((KorhaziEszkozok_Fej)DataContext).Deleted = 0;
                this.DialogResult = true;
                this.Close();
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ((KorhaziEszkozok_Fej)DataContext).Megnevezes = originalMegnevezes;
            this.DialogResult = false;
            this.Close();
        }
    }
}
