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
    /// Interaction logic for EszkozAddModWindow.xaml
    /// </summary>
    public partial class EszkozAddModWindow : Window
    {
        string originalMegnevezes;
        public EszkozAddModWindow(KorhaziEszkoz newEszkoz)
        {
            InitializeComponent();
            this.DataContext = newEszkoz;
            originalMegnevezes = newEszkoz.Megnevezes;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("A megnevezés kitöltése kötelező!");
            }
            else
            {
                ((KorhaziEszkoz)DataContext).Deleted = 0;
                textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ((KorhaziEszkoz)DataContext).Megnevezes = originalMegnevezes;
            Close();
        }
    }
}
