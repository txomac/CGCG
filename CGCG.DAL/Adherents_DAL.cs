using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Adherents_DAL
    {
        public string nom { get; set; }

        public string prenom { get; set; }

        public string societe { get; set; }

        public string email { get; set; }

        public string adresse { get; set; }

        public DateTime dateadhesion { get; set; }

        public int ID { get; set; }

        public Adherents_DAL(string Nom, string Prenom, string Societe, string Email, string Adresse, DateTime Dateadhesion)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            adresse = Adresse;
            dateadhesion = Dateadhesion;
        }

        public Adherents_DAL(int id, string Nom, string Prenom, string Societe, string Email, string Adresse, DateTime Dateadhesion)
            : this(Nom, Prenom, Societe, Email, Adresse, Dateadhesion)
        {
            ID = id;
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
                commande.Parameters.Add(new SqlParameter("@dateadhesion", dateadhesion));
                commande.ExecuteNonQuery();
            }
        }
    }
}
