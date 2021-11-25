using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Fournisseurs_DAL
    {
        public string nom { get; set; }

        public string prenom { get; set; }

        public string societe { get; set; }

        public string email { get; set; }

        public string adresse { get; set; }

        public int id { get; set; }
        
        public int id_panier_fournisseur { get; set; }

        public Fournisseurs_DAL(string Nom, string Prenom, string Societe, string Email, string Adresse, int ID_Panier_Fournisseur)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            adresse = Adresse;
            id_panier_fournisseur = ID_Panier_Fournisseur;
        }

        public Fournisseurs_DAL(int ID, string Nom, string Prenom, string Societe, string Email, string Adresse, int ID_Panier_Fournisseur)
            : this(Nom, Prenom, Societe, Email, Adresse, ID_Panier_Fournisseur)
        {
            id = ID;
        }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Adherents(nom, prenom, societe, email, adresse)" + "values (@nom, @prenom, @societe, @email, @adresse, @id_panier_fournisseur)";
                commande.Parameters.Add(new SqlParameter("@nom", id));
                commande.Parameters.Add(new SqlParameter("@prenom", prenom));
                commande.Parameters.Add(new SqlParameter("@societe", societe));
                commande.Parameters.Add(new SqlParameter("@email", email));
                commande.Parameters.Add(new SqlParameter("@adresse", adresse));
                commande.Parameters.Add(new SqlParameter("@id_panier_fournisseur", id_panier_fournisseur));
                commande.ExecuteNonQuery();
            }
        }
    }
}
