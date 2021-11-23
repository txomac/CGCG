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

        public Fournisseurs_DAL(string Nom, string Prenom, string Societe, string Email, string Adresse)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            adresse = Adresse;
        }

        public Fournisseurs_DAL(int ID, string Nom, string Prenom, string Societe, string Email, string Adresse)
            : this(Nom, Prenom, Societe, Email, Adresse)
        {
            id = ID;
        }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Adherents(nom,prenom,societe,email,adresse,dateadhesion)" + "values (@nom, @prenom,@societe,@email,@adresse,@dateadhesion)";
                commande.Parameters.Add(new SqlParameter("@nom", nom));
                commande.Parameters.Add(new SqlParameter("@prenom", prenom));
                commande.Parameters.Add(new SqlParameter("@societe", societe));
                commande.Parameters.Add(new SqlParameter("@email", email));
                commande.Parameters.Add(new SqlParameter("@adresse", adresse));
                commande.ExecuteNonQuery();
            }
        }
    }
}
