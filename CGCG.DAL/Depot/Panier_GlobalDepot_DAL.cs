using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_GlobalDepot_DAL : Depot_DAL<Panier_Global_DAL>
    {
        public override List<Panier_Global_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, semaine from panier_global";
            var reader = commande.ExecuteReader();

            var listeDePanierGlobal = new List<Panier_Global_DAL>();

            while (reader.Read())
            {
                var panierglobal = new Panier_Global_DAL(reader.GetInt32(0),
                                                            reader.GetInt32(1));

                listeDePanierGlobal.Add(panierglobal);
            }

            DetruireConnexionEtCommande();

            return listeDePanierGlobal;
        }

        public override Panier_Global_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select semaine from panier_global where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Panier_Global_DAL panierglobal;
            if (reader.Read())
            {
                panierglobal = new Panier_Global_DAL(reader.GetInt32(0));
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return panierglobal;
        }

        public override Panier_Global_DAL Insert(Panier_Global_DAL panierglobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global(semaine)"
                                    + " values (@SEMAINE); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@SEMAINE", panierglobal.semaine));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panierglobal.id = ID;

            DetruireConnexionEtCommande();

            return panierglobal;
        }

        public override Panier_Global_DAL Update(Panier_Global_DAL panierglobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_global set semaine=@SEMAINE)"
                                    + " where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panierglobal.id));
            commande.Parameters.Add(new SqlParameter("@SEMAINE", panierglobal.semaine));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le point d'ID {panierglobal.id}");
            }

            DetruireConnexionEtCommande();

            return panierglobal;
        }

        public override void Delete(Panier_Global_DAL panierglobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_global where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panierglobal.id));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le point d'ID {panierglobal.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
