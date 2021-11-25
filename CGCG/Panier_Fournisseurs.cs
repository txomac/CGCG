using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    class Panier_Fournisseurs : List<Fournisseurs>
    {
        public List<Fournisseurs> lesfournisseurs;

        public int id { get; set; }

        public float puht { get; set; }

        public int id_fournisseur { get; set; }

        public int id_panier_global_detail { get; set; }

        public Panier_Fournisseurs(float Puht)
        {
            puht = Puht;
        }

        public Panier_Fournisseurs(int ID, float Puht)
            :this(Puht)
        {
            id = ID;
        }

        public Panier_Fournisseurs (Fournisseurs[] desfournisseurs)
        {
            lesfournisseurs.AddRange(desfournisseurs);
        }
    }
}
