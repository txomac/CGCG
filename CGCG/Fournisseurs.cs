using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Fournisseurs
    {
        public string nom { get; set; }

        public string prenom { get; set; }

        public string societe { get; set; }

        public string email { get; set; }

        public string addresse { get; set; }

        public bool status { get; set; }

        public int id { get; set; }

        public Fournisseurs(string Nom, string Prenom, string Societe, string Email, string Adresse, bool Status)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            addresse = Adresse;
            status = Status;
        }

        public Fournisseurs(int ID, string Nom, string Prenom, string Societe, string Email, string Adresse, bool Status)
            :this(Nom, Prenom, Societe, Email, Adresse, Status)
        {
            id = ID;
        }

        public void Liaison(References reference)
        {
            int id_fournisseur = this.id;
            int id_reference = reference.id;
        }
    }
}
