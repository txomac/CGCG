using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Panier_Fournisseurs : List<Fournisseurs>
    {
        public List<Fournisseurs> lesfournisseurs;

        public List<Panier_Global_Detail> lespanierglobaldetail;

        public int id { get; set; }

        public float puht { get; set; }

        public int id_fournisseur { get; set; }

        public int id_panier_global_detail { get; set; }

        public Panier_Fournisseurs(float Puht, int ID_Fournisseur, int ID_Panier_Global_Detail)
        {
            puht = Puht;
            id_fournisseur = ID_Fournisseur;
            id_panier_global_detail = ID_Panier_Global_Detail;
        }

        public Panier_Fournisseurs(int ID, float Puht, int ID_Fournisseur, int ID_Panier_Global_Detail)
            :this(Puht, ID_Fournisseur, ID_Panier_Global_Detail)
        {
            id = ID;
        }

        public Panier_Fournisseurs(Fournisseurs[] desfournisseurs)
        {
            lesfournisseurs.AddRange(desfournisseurs);
        }

        public Panier_Fournisseurs(Panier_Global_Detail[] despanierglobaldetail)
        {
            lespanierglobaldetail.AddRange(despanierglobaldetail);
        }
    }
}
