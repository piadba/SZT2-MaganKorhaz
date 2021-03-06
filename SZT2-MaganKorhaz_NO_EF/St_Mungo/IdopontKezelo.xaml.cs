﻿
using St_Mungo.StMungo_WCF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Interaction logic for IdopontKezelo.xaml
    /// </summary>
    public partial class IdopontKezelo : Window
    {
        StMungoServiceClient smc;
        RecepciosViewModel recepciosViewModel;
        public IdopontKezelo(RecepciosViewModel recepciosViewModel,StMungoServiceClient smc)
        {
            this.smc = smc;
            InitializeComponent();
            this.recepciosViewModel = recepciosViewModel;

            //smc.mung = recepciosViewModel.MungoSystem;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //mungoSystem.People.Load();
            smc.People_getLoad();
            this.DataContext = recepciosViewModel;
            recepciosViewModel.Orvosok.Clear();
            var orvosadatok = smc.People_getLocal().Where(x => x.Group == 2 && x.Deleted==0);
            
            foreach (var p in orvosadatok)
            {
                recepciosViewModel.Orvosok.Add(p);
            }

           
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //mungoSystem.Idopontok.Load();
            smc.Idopontok_getLoad();
            People o = comboBox.SelectedItem as People;
            var idopontok = smc.IdoPontok_getLocal().Where
                (x => x.Deleted == 0 && o.Deleted == 0 && x.OrvosID == o.PeopleID && x.Datum.Value.ToShortDateString() ==datePicker.SelectedDate.Value.ToShortDateString());
            recepciosViewModel.Idopontok.Clear();

            var idopontadatok = from i in idopontok
                                join b in smc.mungoSystem().Betegek on i.BetegID equals b.BetegID
                                join p in smc.mungoSystem().People on b.PeopleID equals p.PeopleID
                                where i.Deleted == 0 && b.Deleted == 0 && p.Deleted == 0
                                select new { Nev = p.Name, IdopontID = i.IdopontID, Datum = i.Datum, TAJ = b.TAJ };


            recepciosViewModel.IdopontAdatok.Clear();

            foreach (var p in idopontadatok)
                recepciosViewModel.IdopontAdatok.Add(new IdopontIDBeteg { Nev = p.Nev, TAJ = p.TAJ, IdopontID = p.IdopontID, Datum = (DateTime)p.Datum });

            foreach (var i in idopontok)
            {
                if (i.BetegID == null)
                    recepciosViewModel.IdopontAdatok.Add(new IdopontIDBeteg { IdopontID = i.IdopontID, Datum = (DateTime)i.Datum, Nev = "", TAJ = "" });
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(listBox.SelectedItem);
            IdopontIDBeteg selected = (listBox.SelectedItem) as IdopontIDBeteg;
            Idopontok ip = smc.mungoSystem().Idopontok.Where(x => x.IdopontID == selected.IdopontID).First();
            IdopontSzerkeszto isz = new IdopontSzerkeszto(recepciosViewModel, ip,smc);
           
            isz.ShowDialog();
 
        }


    }





}
