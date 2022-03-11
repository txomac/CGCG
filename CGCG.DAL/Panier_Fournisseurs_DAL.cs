using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Fournisseurs_DAL
    {
        public int id { get; set; }

        public float? puht { get; set; }

        public int id_fournisseur { get; set; }

        public int id_panier_global_detail { get; set; }

        public Panier_Fournisseurs_DAL(float? Puht, int ID_Fournisseur, int ID_Panier_Global_Detail)
        {
            puht = Puht;
            id_fournisseur = ID_Fournisseur;
            id_panier_global_detail = ID_Panier_Global_Detail;
        }

        public Panier_Fournisseurs_DAL(int ID, float? Puht, int ID_Fournisseur, int ID_Panier_Global_Detail)
            : this(Puht, ID_Fournisseur, ID_Panier_Global_Detail)
        {
            id = ID;
        }
    }
}
