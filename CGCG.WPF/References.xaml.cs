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
            insert_page.Visibility = Visibility.Hidden;
            grid_getall.Visibility = Visibility.Visible;
            Client client = new Client("https://localhost:44335", new HttpClient());
            var adherents = await client.AllAdherentAsync();

            grid_getall.ItemsSource = adherents;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_insert(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Visible;
            grid_getall.Visibility = Visibility.Hidden;
        }

        private async void reference_insert_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44335", new HttpClient());
            if (insert_reference != null && insert_libelle != null && insert_marque != null && insert_desactive != null)
            {
                await client.ReferencePOSTAsync.(new Reference_DTO()
                {
                    Reference = insert_reference.Text,
                    Libelle = insert_libelle.Text,
                    Marque = insert_marque.Text,
                    Desactive= (bool)insert_desactive.IsChecked,
                    Id_fournisseurs = insert_idfournisseur.Text
                    
                });

                insert_page.Visibility = Visibility.Hidden;
                grid_getall.Visibility = Visibility.Visible;
                var adherents = await client.AllAdherentAsync();
                grid_getall.ItemsSource = adherents;

            }
        }
    }
}
