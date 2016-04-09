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
        MungoSystem mungoSystem;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mungoSystem = new MungoSystem();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            string username = userName.Text;
            string pw = PWBox.Password;
            if (mungoSystem.People
                .Where(ppl => ppl.Password == pw && ppl.UserName == username && ppl.Deleted == 0)
                .Count() > 0)
            {
                People sessionUser = mungoSystem.People
                .Where(ppl => ppl.Password == pw && ppl.UserName == username && ppl.Deleted == 0)
                .First();
                MessageBox.Show("Sikeres bejelentkezés!");
            }
            else
            {
                MessageBox.Show("Helytelen felhasználónév vagy jelszó!");
            }
        }
    }
}
