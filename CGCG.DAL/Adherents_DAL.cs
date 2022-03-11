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

        public string addresse { get; set; }

        public DateTime dateadhesion { get; set; }

        public bool status { get; set; }

        public int id { get; set; }

        public Adherents_DAL(string Nom, string Prenom, string Societe, string Email, string Adresse, DateTime Dateadhesion, bool Status)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            addresse = Adresse;
            dateadhesion = Dateadhesion;
            status = Status;
        }

        public Adherents_DAL(int ID, string Nom, string Prenom, string Societe, string Email, string Adresse, DateTime Dateadhesion, bool Status)
            : this(Nom, Prenom, Societe, Email, Adresse, Dateadhesion, Status)
        {
            id = ID;
        }
    }
}
