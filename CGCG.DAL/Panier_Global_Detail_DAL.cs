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
        public List<References_DAL> References { get; set; }

        public List<Panier_Global_DAL> Panier_Global { get; set; }

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

        public void Insert(SqlConnection connexion)
        {
            connexion.Open();

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;

                commande.CommandText = "insert into panier_global_detail (id, quantite, id_references, id_panier_global)";
                id = (int)commande.ExecuteScalar();
            }

            foreach (var item in References)
            {
                item.id = id_references;
                item.Insert(connexion);
            }

            foreach (var item in Panier_Global)
            {
                item.id = id_panier_global;
                item.Insert(connexion);
            }

            connexion.Close();
        }
    }
}
