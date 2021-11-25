using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    class Panier_Global_Detail
    {
        public int id { get; set; }

        public int quantite { get; set; }

        public int id_references { get; set; }

        public int id_panier_global { get; set; }

        public Panier_Global_Detail(int Quantite, int ID_References, int ID_Panier_Global)
        {
            quantite = Quantite;
            id_references = ID_References;
            id_panier_global = ID_Panier_Global;
        }

        public Panier_Global_Detail(int ID, int Quantite, int ID_References, int ID_Panier_Global)
            :this(Quantite, ID_References, ID_Panier_Global)
        {
            id = ID;
        }
    }
}
