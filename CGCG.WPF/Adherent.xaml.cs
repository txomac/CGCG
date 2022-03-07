using CgCgApI;
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
    public partial class Adherent : Page
    {


        public Adherent()
        {
            InitializeComponent();
            insert_page.Visibility = Visibility.Hidden; 
            grid_getall.Visibility = Visibility.Hidden;


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

        private async void valide_insert_Click(object sender, RoutedEventArgs e)
        {
            
            Client client = new Client("https://localhost:44335", new HttpClient());
            if (insert_nom != null && insert_prenom != null && insert_societe != null && insert_email != null && insert_status != null)
            {
                await client.AdherentPOSTAsync(new Adherent_DTO()
                {
                    Nom = insert_nom.Text,
                    Prenom = insert_prenom.Text,
                    Societe = insert_societe.Text,
                    Adresse = insert_adresse.Text,
                    Email = insert_email.Text,
                    Status = (bool)insert_status.IsChecked,
                    Dateadhesion = DateTime.Now
                });

                insert_page.Visibility = Visibility.Hidden;
                grid_getall.Visibility = Visibility.Visible;
                var adherents = await client.AllAdherentAsync();
                grid_getall.ItemsSource = adherents;

            }
        }

        private void Button_Click_modifier(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall.Visibility = Visibility.Visible;

            if (grid_getall.SelectedItem != null)
            {
                Client client = new Client("https://localhost:44335", new HttpClient());
                Adherent_DTO adherent = (Adherent_DTO)grid_getall.SelectedItem;
                client.AdherentPUTAsync(adherent);
            }
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall.Visibility = Visibility.Visible;

            if (grid_getall.SelectedItem != null)
            {
                Client client = new Client("https://localhost:44335", new HttpClient());
                Adherent_DTO adherent = (Adherent_DTO)grid_getall.SelectedItem;
                client.AdherentDELETEAsync(adherent.Id);
            }
        }
    }
}
