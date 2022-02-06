using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Global_Detail_DAL
    {
        public int id { get; set; }

        public int quantite { get; set; }

        public int id_references { get; set; }

        public int id_panier_global { get; set; }

        public Panier_Global_Detail_DAL(int Quantite, int ID_References, int ID_Panier_Global)
        {
            quantite = Quantite;
            id_references = ID_References;
            id_panier_global = ID_Panier_Global;
        }

        public Panier_Global_Detail_DAL(int ID, int Quantite, int ID_References, int ID_Panier_Global)
            : this(Quantite, ID_References, ID_Panier_Global)
        {
            id = ID;
        }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into panier_global_detail(id_references, quantite, id_panier_global)" + "values (@ID_REFERENCE, @QUANTITE, @ID_PANIER_GLOBAL)";
                commande.Parameters.Add(new SqlParameter("@ID_REFERENCE", id_references));
                commande.Parameters.Add(new SqlParameter("@QUANTITE", quantite));
                commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBAL", id_panier_global));

                commande.ExecuteNonQuery();
            }

        }
    }
}
