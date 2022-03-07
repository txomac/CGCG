using CgCgApI;
using CGCG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.IO;
using Microsoft.Win32;

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
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_reference.Visibility = Visibility.Hidden;

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_insert(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Visible;
            grid_getall_reference   .Visibility = Visibility.Hidden;
        }

        private async void reference_insert_Click(object sender, RoutedEventArgs e)
        {
            Fournisseurs_DTO fournisseur = (Fournisseurs_DTO)listeFournisseur.SelectedItem;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && fournisseur != null)
            {
                var clientApi = new Client("https://localhost:44335/", new HttpClient());

                var referencesCSV = File.ReadAllText(openFileDialog.FileName).Split(new[] { '\r', '\n' });

                await clientApi.ImportCSVAsync(fournisseur.Id, referencesCSV);
            }
            else if (fournisseur == null) MessageBox.Show("Vous devez choisir un fournisseur.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private async void Button_getall(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_reference.Visibility = Visibility.Visible;
            Client client = new Client("https://localhost:44335", new HttpClient());
            var references = await client.AllReferenceAsync();

            grid_getall_reference.ItemsSource = references;
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_reference.Visibility = Visibility.Visible;

            if (grid_getall_reference.SelectedItem != null)
            {
                Client client = new Client("https://localhost:44335", new HttpClient());
                Reference_DTO reference = (Reference_DTO)grid_getall_reference.SelectedItem;
                client.FournisseursDELETEAsync(reference.Id);
            }
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44335/", new HttpClient());
            var fournisseurs = await clientApi.AllFournisseursAsync();

            listeFournisseur.ItemsSource = fournisseurs;
        }
    }
}
