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
    /// Interaction logic for IgenyMainWindow.xaml
    /// </summary>
    public partial class IgenyMainWindow : Window
    {
        People sessionUser;
        MungoSystem ms;
        public IgenyMainWindow(People sessionUser,MungoSystem ms)
        {
            InitializeComponent();
            this.sessionUser = sessionUser;
            this.ms = ms;
        }
    }
}
