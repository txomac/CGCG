using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Panier_Global_Detail
    {
        public List<References> lesreferences;

        public List<Panier_Global> lespanierglobal;

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

        public Panier_Global_Detail(References[] desreferences)
        {
            lesreferences.AddRange(desreferences);
        }

        public Panier_Global_Detail(Panier_Global[] despanierglobal)
        {
            lespanierglobal.AddRange(despanierglobal);
        }
    }
}
