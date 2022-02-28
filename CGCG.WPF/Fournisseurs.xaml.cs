using MyNamespace;
using CGCG;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;


namespace CGCG.WPF
{
    /// <summary>
    /// Logique d'interaction pour Fournisseurs.xaml
    /// </summary>
    public partial class Fournisseurs : Page
    {
        public Fournisseurs()
        {
            InitializeComponent();
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_fournisseur.Visibility = Visibility.Hidden;

        }

        private async void Button_fournisseur_getall(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_fournisseur.Visibility = Visibility.Visible;
            Client client = new Client("https://localhost:44335", new HttpClient());
            var adherents = await client.AllAdherentAsync();

            grid_getall_fournisseur.ItemsSource = adherents;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_insert(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Visible;
            grid_getall_fournisseur.Visibility = Visibility.Hidden;

        }

        private async void valide_insert_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44335", new HttpClient());
            if (insert_nom != null && insert_prenom != null && insert_societe != null && insert_email != null && insert_status != null)
            {
                await client.FournisseursPOSTAsync(new Fournisseurs_DTO()
                {
                    Nom = insert_nom.Text,
                    Prenom = insert_prenom.Text,
                    Societe = insert_societe.Text,
                    Adresse = insert_adresse.Text,
                    Email = insert_email.Text,
                    Status = (bool)insert_status.IsChecked,
                });

                insert_page.Visibility = Visibility.Hidden;
                grid_getall_fournisseur.Visibility = Visibility.Visible;
                var fournisseur = await client.AllFournisseursAsync();
                grid_getall_fournisseur.ItemsSource = fournisseur;

            }
        }

        private void Button_modifier(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_fournisseur.Visibility = Visibility.Visible;

            if (grid_getall_fournisseur.SelectedItem != null)
            {
                Client client = new Client("https://localhost:44335", new HttpClient());
                Fournisseurs_DTO fournisseur = (Fournisseurs_DTO)grid_getall_fournisseur.SelectedItem;
                client.FournisseursPUTAsync(fournisseur);
            }
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            insert_page.Visibility = Visibility.Hidden;
            grid_getall_fournisseur.Visibility = Visibility.Visible;

            if (grid_getall_fournisseur.SelectedItem != null)
            {
                Client client = new Client("https://localhost:44335", new HttpClient());
                Fournisseurs_DTO fournisseur = (Fournisseurs_DTO)grid_getall_fournisseur.SelectedItem;
                client.FournisseursDELETEAsync(fournisseur.Id);
            }
        }
    }
}
