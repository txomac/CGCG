using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Fournisseurs_References_DAL
    {
        public int id { get; set; }

        public int id_fournisseurs { get; set; }

        public int id_references { get; set; }

        public Fournisseurs_References_DAL(int ID_Fournisseurs, int ID_References)
        {
            id_fournisseurs = ID_Fournisseurs;
            id_references = ID_References;
        }

        public Fournisseurs_References_DAL(int ID, int ID_Fournisseurs, int ID_References)
            :this(ID_Fournisseurs, ID_References)
        {
            id = ID;
        }

        public void Insert(SqlConnection connexion)
        {
            connexion.Open();

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;

                commande.CommandText = "insert into fournisseurs_references (id_fournisseurs, id_references)";
                id = (int)commande.ExecuteScalar();
            }

            connexion.Close();
        }
    }
}
