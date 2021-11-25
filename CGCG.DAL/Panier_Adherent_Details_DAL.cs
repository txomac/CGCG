using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Adherent_Details_DAL
    {
        public int id { get; set; }

        public int quantite { get; set; }

        public int id_references { get; set; }

        public int id_panier_adherents { get; set; }

        public Panier_Adherent_Details_DAL(int Quantite, int Id_references, int Id_panier_adherent)
        {
            quantite = Quantite;
            id_references = Id_references;
            id_panier_adherents = Id_panier_adherent;
        }

        public Panier_Adherent_Details_DAL(int ID, int Quantite, int Id_references, int Id_panier_adherent)
            : this(Quantite, Id_references, Id_panier_adherent )
        {
            id = ID;
        }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into panier_adherent_detail(quantite)"
                                + " values (@QUANTITE)";
                commande.Parameters.Add(new SqlParameter("@QUANTITE", quantite));

                commande.ExecuteNonQuery();
            }
        }
    }
}
