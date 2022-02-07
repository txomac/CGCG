using MyNamespace;
using CGCG;
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
using System.Net.Http;

namespace CGCG.WPF
{
    /// <summary>
    /// Logique d'interaction pour Adherent.xaml
    /// </summary>
    public partial class References : Page
    {


        public References()
        {
            InitializeComponent();


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44368", new HttpClient());
            var reference = await client.AllReferenceAsync();

            grid_getall.ItemsSource = reference;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_insert(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44368", new HttpClient());

        }
    }
}
