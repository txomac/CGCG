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

namespace CGCG.WPF
{
    /// <summary>
    /// Logique d'interaction pour Adherent.xaml
    /// </summary>
    public partial class Adherent : Page
    {
        public Client ClientApi{ get; set; }


        public Adherent()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var adherent = new Adherents(add_name, add_prenom, add_societe, add_email, add_adresse, add_date, add_status);
           // var client = ClientApi.AdherentPOSTAsync()
        }
    }
}
