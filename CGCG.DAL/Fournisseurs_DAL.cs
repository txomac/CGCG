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

        public string addresse { get; set; }

        public bool status { get; set; }

        public int id { get; set; }

        public Fournisseurs_DAL(string Nom, string Prenom, string Societe, string Email, string Adresse, bool Status)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            addresse = Adresse;
            status = Status;
        }

        public Fournisseurs_DAL(int ID, string Nom, string Prenom, string Societe, string Email, string Adresse, bool Status)
            : this(Nom, Prenom, Societe, Email, Adresse, Status)
        {
            id = ID;
        }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into fournisseurs(nom, prenom, societe, email, adresse, status)" + "values (@NOM, @PRENOM, @SOCIETE, @EMAIL, @ADRESSE, @STATUS)";
                commande.Parameters.Add(new SqlParameter("@NOM", nom));
                commande.Parameters.Add(new SqlParameter("@PRENOM", prenom));
                commande.Parameters.Add(new SqlParameter("@SOCIETE", societe));
                commande.Parameters.Add(new SqlParameter("@EMAIL", email));
                commande.Parameters.Add(new SqlParameter("@ADRESSE", addresse));
                commande.Parameters.Add(new SqlParameter("@STATUS", status));
                commande.ExecuteNonQuery();
            }
        }
    }
}
