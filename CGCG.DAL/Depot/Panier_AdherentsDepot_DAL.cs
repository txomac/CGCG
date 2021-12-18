using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_AdherentsDepot_DAL : Depot_DAL<Panier_Adherents_DAL>
    {
        public override List<Panier_Adherents_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_adherents, id_panier_global from panier_adherent";
            var reader = commande.ExecuteReader();

            var listePanier = new List<Panier_Adherents_DAL>();

            while (reader.Read())
            {
                var p = new Panier_Adherents_DAL(reader.GetInt32(0),
                                                    reader.GetInt32(1),
                                                    reader.GetInt32(2));

                listePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePanier;
        }

        public override Panier_Adherents_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_adherent, id_panier_global from panier_adherent where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Panier_Adherents_DAL p;

            if (reader.Read())
            {
                p = new Panier_Adherents_DAL(reader.GetInt32(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2));
            }
            else
            {
                throw new Exception($"Pas de panier avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }

        public override Panier_Adherents_DAL Insert(Panier_Adherents_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_adherent(id_adherents, id_panier_global)" + " values (@ID_ADHERENTS, @ID_PANIER_GLOBAL); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@ID_ADHERENTS", panier.id_adherents));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBAL", panier.id_panier_global));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.id_adherents = GetByID(ID).id_adherents;
            panier.id_panier_global = GetByID(ID).id_panier_global;
            DetruireConnexionEtCommande();

            return panier;
        }

        public override Panier_Adherents_DAL Update(Panier_Adherents_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_adherents set id_adherents=@ID_ADHERENTS, id_panier_global=@ID_PANIER_GLOBAL where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier adherent d'ID {panier.id}");
            }

            panier.id_adherents = GetByID(panier.id).id_adherents;
            panier.id_panier_global = GetByID(panier.id).id_panier_global;

            DetruireConnexionEtCommande();

            return panier;
        }

        public override void Delete(Panier_Adherents_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer le panier adherent d'ID {panier.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
