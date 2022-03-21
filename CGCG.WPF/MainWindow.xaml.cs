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

namespace CGCG.WPF
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

        private void Button_Click_adherent(object sender, RoutedEventArgs e)
        {
            Main.Content = new Adherent();
        }

        private void Button_Click_fournisseur(object sender, RoutedEventArgs e)
        {
            Main.Content = new Fournisseurs();
        }

        private void Button_Click_reference(object sender, RoutedEventArgs e)
        {
            Main.Content = new References();
        }

        private void Button_Click_panier_global(object sender, RoutedEventArgs e)
        {
            Main.Content = new Panier_Global();
        }
    }
}
