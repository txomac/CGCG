using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Adherents
    {
        public string nom { get; set; }

        public string prenom { get; set; }

        public string societe { get; set; }

        public string email { get; set; }

        public string adresse { get; set; }

        public DateTime dateadhesion { get; set; }

        public int ID { get; set; }

        public Adherents(string Nom, string Prenom, string Societe, string Email, string Adresse, DateTime Dateadhesion)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            adresse = Adresse;
            dateadhesion = Dateadhesion;
        }

        public Adherents(int id, string Nom, string Prenom, string Societe, string Email, string Adresse, DateTime Dateadhesion)
            :this(Nom,Prenom,Societe,Email,Adresse,Dateadhesion)
        {
            ID = id;
        }
    }
}
