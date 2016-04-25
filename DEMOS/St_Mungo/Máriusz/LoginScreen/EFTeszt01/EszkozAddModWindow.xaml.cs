using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EszkozAddModWindow.xaml
    /// </summary>
    public partial class EszkozAddModWindow : Window
    {
        string originalMegnevezes;
        bool igeny;
        public EszkozAddModWindow(KorhaziEszkoz newEszkoz,MungoSystem ms,bool Igeny,People sessionUser)
        {
            InitializeComponent();
            this.DataContext = newEszkoz;
            igeny = Igeny;
            originalMegnevezes = newEszkoz.Megnevezes;

         

            ms.KorhaziEszkozok_Fej.Load();
            if (sessionUser.Group!=4)
            {
                checkBox.IsEnabled = false;
            }
            if (newEszkoz.Statusz==true)
            {
                comboCsoport.Visibility = Visibility.Hidden;
                labelCombo.Visibility = Visibility.Hidden;
            }
            else
            {
                ObservableCollection<KorhaziEszkozok_Fej> comboSource =
                new ObservableCollection<KorhaziEszkozok_Fej>(
                ms.KorhaziEszkozok_Fej.Where
                (x => x.Deleted == 0));
                comboCsoport.ItemsSource = comboSource;

                comboCsoport.DisplayMemberPath = "Megnevezes";
                comboCsoport.SelectedValuePath = "Eszkoz_FejID";
            }
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
                if (comboCsoport.SelectedItem!=null)
                {
                    ((KorhaziEszkoz)DataContext).Eszkoz_FejID = ((KorhaziEszkozok_Fej)comboCsoport.SelectedItem).Eszkoz_FejID;
                    comboCsoport.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
                }
                textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                checkBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
