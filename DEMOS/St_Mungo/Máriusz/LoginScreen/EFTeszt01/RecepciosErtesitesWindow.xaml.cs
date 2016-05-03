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
using System.Net.Mail;
using System.Net;
using EFTeszt01.EmailKuldoServiceReference;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for RecepciosErtesitesWindow.xaml
    /// </summary>
    public partial class RecepciosErtesitesWindow : Window
    {
        MungoSystem mungoSystem;
        RecepciosViewModel recepciosViewModel;
        public RecepciosErtesitesWindow(RecepciosViewModel recepciosViewModel)
        {
            InitializeComponent();
            this.recepciosViewModel = recepciosViewModel;

            mungoSystem = recepciosViewModel.MungoSystem;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mungoSystem.Idopontok.Load();

     
            var idopontok = mungoSystem.Idopontok.Local.Where
                (x => x.Deleted == 0 &&  x.Datum.Value.ToShortDateString() == datePicker.SelectedDate.Value.ToShortDateString());

          

            var idopontadatok = from i in idopontok
                                join b in mungoSystem.Betegek on i.BetegID equals b.BetegID
                                join p in mungoSystem.People on b.PeopleID equals p.PeopleID
                                join o in mungoSystem.People on i.OrvosID equals o.PeopleID
                                where i.Deleted == 0 && b.Deleted == 0 && p.Deleted == 0
                                select new { Nev = p.Name, IdopontID = i.IdopontID, Datum = i.Datum, TAJ = b.TAJ, OrvosNev = o.Name };


            recepciosViewModel.IdopontAdatok.Clear();

            foreach (var p in idopontadatok)
                recepciosViewModel.IdopontAdatok.Add(new IdopontIDBeteg { OrvosNev = p.OrvosNev,Nev = p.Nev, TAJ = p.TAJ, IdopontID = p.IdopontID, Datum = (DateTime)p.Datum });


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mungoSystem.People.Load();
            datePicker.SelectedDate = DateTime.Now;
            this.DataContext = recepciosViewModel;
            recepciosViewModel.IdopontAdatok.Clear();

        }

        private void NotifyBeteg(IdopontIDBeteg idopontadatok, string megjegyzes)
        {


            Console.WriteLine();   //  TODO  WCF meghívása, formázott email küldése

            var fromName = recepciosViewModel.SessionUser.Name;
            var toName = idopontadatok.Nev;

            var fromAddress = "szt2mungo@gmail.com";
            var toAddress = "szt2mungo@gmail.com";
         
            string subject = "Értesítés időpontról";
            string body = "Tisztelt "+ idopontadatok.Nev + "!\nÖnnek foglalt időpontja van kórházunkban: "
                + idopontadatok.Datum + "\nKezelőorvos neve: " +  idopontadatok.OrvosNev + "\n"+ megjegyzes
                +"\n\nKöszönjük, hogy minket választott!\t Tisztelettel: "+ recepciosViewModel.SessionUser.Name;

            EmailClient client = new EmailClient();
            client.EmailKuldes(fromAddress, fromName, toAddress, toName, subject, body);

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IdopontIDBeteg ia = (listBox.SelectedItem) as IdopontIDBeteg;

            NotifyBeteg(ia,textBox.Text);
            DialogResult = true;
        }
    }
}
