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
using EFTeszt01.Models;
using EFTeszt01.Controllers;



namespace EFTeszt01
{
    /// <summary>
    /// Interaction logic for AdatMod_View.xaml
    /// </summary>
    public partial class AdatMod_View : UserControl
    {
        BetegMainController betegController;
        public AdatMod_View(BetegMainController controller)
        {
            InitializeComponent();
            betegController = controller;
        }
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichTextBox textBox = (RichTextBox)d;
            if (e.NewValue != null)
            {
                textBox.Document.Blocks.Clear();
                textBox.Document.Blocks.Add(new Paragraph(new Run(e.NewValue.ToString())));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = betegController.betegAdatok;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            betegController.SaveChanges();
        }
    }
}
