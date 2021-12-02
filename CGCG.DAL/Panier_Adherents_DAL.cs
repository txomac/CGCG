using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Adherents_DAL
    {
        public List<Panier_Global_DAL> lepanierglobal { get; set; }

        public List<Adherents_DAL> Adherents { get; set; }

        public int id { get; set; }

        public int id_adherents { get; set; }

        public int id_panier_global { get; set; }


        public Panier_Adherents_DAL(int ID_Adherents, int ID_Panier_Global)
        {
            id_adherents = ID_Adherents;
            id_panier_global = ID_Panier_Global;
        }

        public Panier_Adherents_DAL(int ID, int ID_Adherents, int ID_Panier_Global)
            : this(ID_Adherents, ID_Panier_Global)
        {
            id = ID;
        }

        public void Insert(SqlConnection connexion)
        {

            connexion.Open();

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;

                commande.CommandText = "insert into panier_adherents (id, id_adherents, id_panier_global)";
                id = (int)commande.ExecuteScalar();
            }

            foreach (var item in Adherents)
            {
                item.id = id_adherents;
                item.Insert(connexion);
            }

            foreach (var item in lepanierglobal)
            {
                item.id = id_panier_global;
                item.Insert(connexion);
            }
            connexion.Close();

        }
    }
}
