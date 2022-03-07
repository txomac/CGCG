using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Fournisseurs_ReferencesDepot_DAL : Depot_DAL<Fournisseurs_References_DAL>
    {
        #region GetAll
        public override List<Fournisseurs_References_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_fournisseurs, id_references from fournisseurs_references";
            var reader = commande.ExecuteReader();

            var listePanier = new List<Fournisseurs_References_DAL>();

            while (reader.Read())
            {
                var p = new Fournisseurs_References_DAL(reader.GetInt32(0),
                                                    reader.GetInt32(1));

                listePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePanier;
        }
        #endregion

        #region GetByID
        public override Fournisseurs_References_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Insert
        public override Fournisseurs_References_DAL Insert(Fournisseurs_References_DAL liaison)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs_references(id_fournisseurs, id_references)" + " values (@ID_FOURNISSEUR, @ID_REFERENCES); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEUR", liaison.id_fournisseurs));
            commande.Parameters.Add(new SqlParameter("@ID_REFERENCES", liaison.id_references));
            commande.ExecuteNonQuery();
            DetruireConnexionEtCommande();

            return liaison;
        }
        #endregion

        #region Update
        public override Fournisseurs_References_DAL Update(Fournisseurs_References_DAL panier)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public override void Delete(Fournisseurs_References_DAL panier)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DeleteById
        public void DeleteById(int id)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from fournisseurs_references where id_fournisseurs=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", id));

            DetruireConnexionEtCommande();

        }
        #endregion

    }
}
