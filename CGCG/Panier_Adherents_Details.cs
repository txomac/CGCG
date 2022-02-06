using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Panier_Adherents_Details
    {
        public int id { get; set; }

        public int quantite { get; set; }

        public int id_references { get; set; }

        public int id_panier_adherents { get; set; }

        public Panier_Adherents_Details(int Quantite, int ID_References, int ID_Panier_Adherents)
        {
            quantite = Quantite;
            id_references = ID_References;
            id_panier_adherents = ID_Panier_Adherents;
        }

        public Panier_Adherents_Details(int ID, int Quantite, int ID_References, int ID_Panier_Adherents)
            :this(Quantite, ID_References, ID_Panier_Adherents)
        {
            id = ID;
        }
    }
}
