using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    class Fournisseurs
    {
        public string nom { get; set; }

        public string prenom { get; set; }

        public string societe { get; set; }

        public string email { get; set; }

        public string adresse { get; set; }

        public int id { get; set; }

        public int id_panier_fournisseur { get; set; }

        public Fournisseurs(string Nom, string Prenom, string Societe, string Email, string Adresse, int ID_Panier_Fournisseur)
        {
            nom = Nom;
            prenom = Prenom;
            societe = Societe;
            email = Email;
            adresse = Adresse;
            id_panier_fournisseur = ID_Panier_Fournisseur;
        }

        public Fournisseurs(int ID, string Nom, string Prenom, string Societe, string Email, string Adresse, int ID_Panier_Fournisseur)
            :this(Nom, Prenom, Societe, Email, Adresse, ID_Panier_Fournisseur)
        {
            id = ID;
        }
    }
}
