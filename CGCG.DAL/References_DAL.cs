using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class References_DAL
    {
        public int id { get; set; }

        public string reference { get; set; }

        public string libelle { get; set; }

        public string marque { get; set; }

        public bool desactive { get; set; }

        public int id_Fournisseurs { get; set; }

        public References_DAL(string Reference, string Libelle, string Marque, bool Desactive, int ID_Fournisseurs)
        {
            reference = Reference;
            libelle = Libelle;
            marque = Marque;
            desactive = Desactive;
            id_Fournisseurs = ID_Fournisseurs;
        }
        public References_DAL(int ID, string Reference, string Libelle, string Marque, bool Desactive, int ID_Fournisseurs)
           : this(Reference, Libelle, Marque, Desactive, ID_Fournisseurs)
        {
            id = ID;
        }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into reference(reference,libelle,marque,desactive)" + "values (@REFERENCE, @LIBELLE,@MARQUE,@DESACTIVE)";
                commande.Parameters.Add(new SqlParameter("@REFERENCE", reference));
                commande.Parameters.Add(new SqlParameter("@LIBELLE", libelle));
                commande.Parameters.Add(new SqlParameter("@MARQUE", marque));
                commande.Parameters.Add(new SqlParameter("@DESACTIVE", desactive));
                commande.ExecuteNonQuery();
            }
        }
    }
}
