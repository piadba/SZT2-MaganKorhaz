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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using St_Mungo.StMungo_WCF;

namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        StMungoServiceClient smc;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            smc = new StMungoServiceClient();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            string username = userName.Text;
            string pw = PWBox.Password;

            BetegAdat ba = smc.getBetegAdatok(36);

            MungoSystem mungoSystem = smc.mungoSystem();

            
            if (mungoSystem.People
                .Where(ppl => ppl.Password == pw && ppl.UserName == username && ppl.Deleted == 0)
                .Count() > 0)
            {
                People sessionUser = mungoSystem.People
                .Where(ppl => ppl.Password == pw && ppl.UserName == username && ppl.Deleted == 0)
                .First();
                smc.People_getLoad();
                //mungoSystem.People.Load();

                Window showWindow = new Window();
                this.Hide();
                switch (sessionUser.Group)
                {
                    case 1:
                        //Beteg
                        break;
                    case 2:
                        showWindow = new OrvosAsszisztensWindow(sessionUser,smc);
                        break;
                    case 3:
                        showWindow = new ApoloMainWindow(smc.mungoSystem(), sessionUser);
                        showWindow.DataContext = sessionUser;
                        break;
                    case 4:
                        showWindow = new GazdAlkMainWindow(sessionUser,smc);
                        break;
                    case 5:
                        showWindow = new RecepciosMainWindow(sessionUser,smc);
                        //Recepciós
                        break;
                    case 6:
                        showWindow = new AdminWindow(smc.mungoSystem());
                        break;
                }
                showWindow.ShowDialog();
                St_Mungo.App.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Hibás felhasználónév vagy jelszó!");
            }
        }
    }
}
