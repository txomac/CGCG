using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Panier_Adherents_Details
    {
        public List<References> lesreferences;

        public List<Panier_Adherents> lespanieradherants;

        public int id { get; set; }

        public int quantite { get; set; }

        public int id_references { get; set; }

        public int id_panier_adhents { get; set; }

        public Panier_Adherents_Details(int Quantite, int ID_References, int ID_Panier_Adherants)
        {
            quantite = Quantite;
            id_references = ID_References;
            id_panier_adhents = ID_Panier_Adherants;
        }

        public Panier_Adherents_Details(int ID, int Quantite, int ID_References, int ID_Panier_Adherants)
            :this(Quantite, ID_References, ID_Panier_Adherants)
        {
            id = ID;
        }

        public Panier_Adherents_Details(References[] desreferences)
        {
            lesreferences.AddRange(desreferences);
        }

        public Panier_Adherents_Details(Panier_Adherents[] despanieradherants)
        {
            lespanieradherants.AddRange(despanieradherants);
        }
    }
}
