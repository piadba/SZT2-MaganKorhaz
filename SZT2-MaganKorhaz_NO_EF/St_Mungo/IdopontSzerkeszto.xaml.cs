using St_Mungo.StMungo_WCF;
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
    /// Interaction logic for IdopontSzerkeszto.xaml
    /// </summary>
    public partial class IdopontSzerkeszto : Window
    {
        Idopontok idopont;
        RecepciosViewModel recepciosViewModel;
        StMungoServiceClient smc;
        public IdopontSzerkeszto(RecepciosViewModel recepciosViewModel, Idopontok idopont, StMungoServiceClient smc)
        {
            InitializeComponent();
            this.smc = smc;
            this.recepciosViewModel = recepciosViewModel;
            //smc.mungoSystem() = recepciosViewModel.MungoSystem;
            this.idopont = idopont;
            
            var orvosnev = smc.mungoSystem().People.Where(x => x.PeopleID == idopont.OrvosID).Select(x => x.Name).First();
            orvosLbl.Content = orvosnev;
            datumLbl.Content = idopont.Datum.Value.ToShortDateString() +" " + idopont.Datum.Value.ToShortTimeString();
            this.DataContext = recepciosViewModel;

            smc.Betegek_getLoad();

            var betegek = from b in smc.mungoSystem().Betegek
                          join p in smc.mungoSystem().People on b.PeopleID equals p.PeopleID
                          where b.Deleted == 0 && p.Deleted==0
                          select new { TAJ = b.TAJ, Nev = p.Name, BetegID = b.BetegID, PeopleID = b.PeopleID };
           
            foreach(var b in betegek)
            {
                recepciosViewModel.Betegek.Add(new BetegTajIDNev { TAJ = b.TAJ, Nev = b.Nev, BetegID = b.BetegID, PeopleID = (int)b.PeopleID });
            }

            
 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int kivBetegID = (comboBox.SelectedItem as BetegTajIDNev).BetegID;
            idopont.BetegID = kivBetegID;

            smc.mungoSystemSave();
            //recepciosViewModel.MungoSystem.SaveChanges();

            statusz.Content = "Mentés sikerült";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedItem = recepciosViewModel.Betegek.Where(x => x.BetegID == idopont.BetegID).First();
          
        }

  
    }


}
