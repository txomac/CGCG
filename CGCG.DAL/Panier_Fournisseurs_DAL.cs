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
        public List<Fournisseurs_DAL> Fournisseurs { get; set; }

        public List<Panier_Global_Detail_DAL> Panier_Global_Detail { get; set; }

        public int id { get; set; }

        public float puht { get; set; }

        public int id_fournisseur { get; set; }

        public int id_panier_global_detail { get; set; }

        public Panier_Fournisseurs_DAL(float Puht, int ID_Fournisseur, int ID_Panier_Global_Detail)
        {
            puht = Puht;
            id_fournisseur = ID_Fournisseur;
            id_panier_global_detail = ID_Panier_Global_Detail;
        }

        public Panier_Fournisseurs_DAL(int ID, float Puht, int ID_Fournisseur, int ID_Panier_Global_Detail)
            : this(Puht, ID_Fournisseur, ID_Panier_Global_Detail)
        {
            id = ID;
        }

        public void Insert(SqlConnection connexion)
        {
            connexion.Open();

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;

                commande.CommandText = "insert into panier_fournisseur (id, puht, id_fournisseur, id_panier_global_detail)";
                id = (int)commande.ExecuteScalar();
            }

            foreach (var item in Fournisseurs)
            {
                item.id = id_fournisseur;
                item.Insert(connexion);
            }

            foreach (var item in Panier_Global_Detail)
            {
                item.id = id_panier_global_detail;
                item.Insert(connexion);
            }

            connexion.Close();
        }
    }
}
