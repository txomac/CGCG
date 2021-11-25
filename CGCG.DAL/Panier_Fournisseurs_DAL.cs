using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    class Panier_Fournisseurs_DAL
    {
        public List<Fournisseurs_DAL> Fournisseurs { get; set; }

        public int id { get; set; }

        public float puht { get; set; }

        public Panier_Fournisseurs_DAL(float Puht)
        {
            puht = Puht;
        }

        public Panier_Fournisseurs_DAL(int ID, float Puht)
            :this(Puht)
        {
            id = ID;
        }

        public void Insert()
        {
            var chaineDeConnexion = @"todo";

            using (var connexion = new SqlConnection(chaineDeConnexion))
            {
                connexion.Open();

                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;

                    commande.CommandText = "insert into panier_fournisseur (id, puht)";
                    id = (int)commande.ExecuteScalar();
                }

                foreach (var item in Fournisseurs)
                {
                    item.id_panier_fournisseur = id;
                    item.Insert(connexion);
                }

                connexion.Close();
            }
        }
    }
}
