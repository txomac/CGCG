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

        public int id_panier_Adhents { get; set; }

        public Panier_Adherents_Details(int Quantite)
        {
            quantite = Quantite;
        }

        public Panier_Adherents_Details(int ID, int Quantite)
            :this(Quantite)
        {
            id = ID;
        }
    }
}
