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
    /// Interaction logic for OrvosAsszisztensUjBetegWindow.xaml
    /// </summary>
    public partial class OrvosAsszisztensUjBetegWindow : Window
    {
        OrvosViewModel ovm;
        public OrvosAsszisztensUjBetegWindow()
        {
            ovm = OrvosViewModel.Get();
            InitializeComponent();
            this.DataContext = ovm;
        }

        private void mentesBTN_Click(object sender, RoutedEventArgs e)
        {
            //ovm.Ms.People.Add(new People() { Name = nevTB.Text, Address = lakcimTB.Text, Gender = nemTB.Text, Email = emailTB.Text, Password = jszTB.Text, Phone = telTB.Text, Deleted = 0, Group = 4, UserName = felhTB.Text });
            //ovm.Mentes();
            //ovm.Ms.People.Load();
            //int id = ovm.Ms.People.Local.Where(elem => elem.Name == nevTB.Text).First().PeopleID;
            //ovm.Ms.Betegek.Add(new Betegek() { Deleted = 0, PeopleID = id, TAJ=tajTB.Text});
            //ovm.Mentes();
            //ovm.Ms.Betegek.Load();

            //ovm.MungoSystemInitial(ovm.Ms);
            if (nevTB.Text != "" && emailTB.Text != "" && tajTB.Text != "" && felhTB.Text != "" && jszTB.Text != "" && telTB.Text != "" && lakcimTB.Text != "")
            {
                ovm.Ujbeteg(new People() { Name = nevTB.Text, Address = lakcimTB.Text, Gender = nemTB.Text, Email = emailTB.Text, Password = jszTB.Text, Phone = telTB.Text, Deleted = 0, Group = 1, UserName = felhTB.Text }, tajTB.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("HIBA: a következők közül legalább egy nincs megadva:\n\tNév\n\tFelhasználó név\n\tJelszó\n\tEmail cím\n\tTelefonszám\n\tLakcím");
            }
        }

        private void megsemBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
