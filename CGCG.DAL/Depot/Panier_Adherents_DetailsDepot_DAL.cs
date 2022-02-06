using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Adherents_DetailsDepot_DAL : Depot_DAL<Panier_Adherent_Details_DAL>
    {
        public override List<Panier_Adherent_Details_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, quantite, id_references, id_panier_adherents from panier_adherent_detail";
            var reader = commande.ExecuteReader();

            var listeDePanierAdherentDetail = new List<Panier_Adherent_Details_DAL>();

            while (reader.Read())
            {
                var f = new Panier_Adherent_Details_DAL(reader.GetInt32(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2),
                                                reader.GetInt32(3));
                listeDePanierAdherentDetail.Add(f);
            }

            DetruireConnexionEtCommande();

            return listeDePanierAdherentDetail;
        }

        public override Panier_Adherent_Details_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, quantite, id_references, id_panier_adherents from panier_adherent_detail where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Panier_Adherent_Details_DAL p;
            if (reader.Read())
            {
                p = new Panier_Adherent_Details_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));
            }
            else
                throw new Exception($"Pas de panier_adherent_detail dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }

        public override Panier_Adherent_Details_DAL Insert(Panier_Adherent_Details_DAL panier_adherent_detail)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_adherent_detail(quantite, id_references, id_panier_adherents)"
                                    + " values (@QUANTITE, @ID_REFERENCES, @ID_PANIER_ADHERENT); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@QUANTITE", panier_adherent_detail.quantite));
            commande.Parameters.Add(new SqlParameter("@ID_REFERENCES", panier_adherent_detail.id_references));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_ADHERENT", panier_adherent_detail.id_panier_adherents));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier_adherent_detail.id = ID;

            DetruireConnexionEtCommande();

            return panier_adherent_detail;
        }

        public override Panier_Adherent_Details_DAL Update(Panier_Adherent_Details_DAL panier_adherent_detail)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_adherent_detail set quantite=@QUANTITE, id_references=@ID_REFERENCES, id_panier_adherents=@ID_PANIER_ADHERENT"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier_adherent_detail.id));
            commande.Parameters.Add(new SqlParameter("@QUANTITE", panier_adherent_detail.quantite));
            commande.Parameters.Add(new SqlParameter("@ID_REFERENCES", panier_adherent_detail.id_references));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_ADHERENT", panier_adherent_detail.id_panier_adherents));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier adherent detail d'ID {panier_adherent_detail.id}");
            }

            DetruireConnexionEtCommande();

            return panier_adherent_detail;
        }

        public override void Delete(Panier_Adherent_Details_DAL panier_adherent_detail)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_adherent_detail where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier_adherent_detail.id));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le panier adherent detail d'ID {panier_adherent_detail.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
