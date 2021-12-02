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
        public override List<Fournisseurs_References_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_fournisseur, id_references from fournisseurs_references";
            var reader = commande.ExecuteReader();

            var listePanier = new List<Fournisseurs_References_DAL>();

            while (reader.Read())
            {
                var p = new Fournisseurs_References_DAL(reader.GetInt32(0),
                                                    reader.GetInt32(1),
                                                    reader.GetInt32(2));

                listePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePanier;
        }

        public override Fournisseurs_References_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_fournisseurs, id_references from fournisseurs_references where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Fournisseurs_References_DAL p;

            if (reader.Read())
            {
                p = new Fournisseurs_References_DAL(reader.GetInt32(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2));
            }
            else
            {
                throw new Exception($"Pas de reference fournisseur avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }

        public override Fournisseurs_References_DAL Insert(Fournisseurs_References_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs_references(id_fournisseurs, id_fournisseurs_references)" + " values (@ID_FOURNISSEUR, @ID_FOURNISSEURS_REFERENCES); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEUR", panier.id_fournisseurs));
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEURS_REFERENCES", panier.id_references));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.id_fournisseurs = GetByID(ID).id_fournisseurs;
            panier.id_references = GetByID(ID).id_references;

            DetruireConnexionEtCommande();

            return panier;
        }

        public override Fournisseurs_References_DAL Update(Fournisseurs_References_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update fournisseurs_references set id_fournisseurs=@ID_FOURNISSEURS, id_references=@ID_REFERENCES where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour la reference fournisseur d'ID {panier.id}");
            }

            panier.id_fournisseurs = GetByID(panier.id).id_fournisseurs;
            panier.id_references = GetByID(panier.id).id_references;

            DetruireConnexionEtCommande();

            return panier;
        }

        public override void Delete(Fournisseurs_References_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from fournisseurs_references where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer la reference fournisseur d'ID {panier.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
