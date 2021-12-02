using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Global_DetailDepot_DAL : Depot_DAL<Panier_Global_Detail_DAL>
    {
        public override List<Panier_Global_Detail_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, quantite, id_references, id_panier_global from panier_global_detail";
            var reader = commande.ExecuteReader();

            var listePanier = new List<Panier_Global_Detail_DAL>();

            while (reader.Read())
            {
                var p = new Panier_Global_Detail_DAL(reader.GetInt32(0),
                                                    reader.GetInt32(1),
                                                    reader.GetInt32(2),
                                                    reader.GetInt32(3));

                listePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePanier;
        }

        public override Panier_Global_Detail_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, quantite, id_references, id_panier_global from panier_global_detail where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Panier_Global_Detail_DAL p;

            if (reader.Read())
            {
                p = new Panier_Global_Detail_DAL(reader.GetInt32(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2),
                                                reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"Pas de panier avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }

        public override Panier_Global_Detail_DAL Insert(Panier_Global_Detail_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global_detail(quantite, id_references, id_panier_global)" + " values (@QUANTITE, @ID_REFERENCES, @ID_PANIER_GLOBAL); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@QUANTITE", panier.quantite));
            commande.Parameters.Add(new SqlParameter("@ID_REFERENCES", panier.id_references));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBAL", panier.id_panier_global));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.quantite = GetByID(ID).quantite;
            panier.id_references = GetByID(ID).id_references;
            panier.id_panier_global = GetByID(ID).id_panier_global;
            DetruireConnexionEtCommande();

            var depotPanierGlobal = new Panier_GlobalDepot_DAL();
            foreach (var item in panier.Panier_Global)
            {
                item.id = ID;
                depotPanierGlobal.Insert(item);
            }

            var depotReferences = new ReferencesDepot_DAL();
            foreach (var item in panier.References)
            {
                item.id = ID;
                depotReferences.Insert(item);
            }

            return panier;
        }

        public override Panier_Global_Detail_DAL Update(Panier_Global_Detail_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_global_detail set quantite=@QUANTITE, id_references=@ID_REFERENCES, id_panier_global=@ID_PANIER_GLOBAL where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier global detail d'ID {panier.id}");
            }

            panier.quantite = GetByID(panier.id).quantite;
            panier.id_references = GetByID(panier.id).id_references;
            panier.id_panier_global = GetByID(panier.id).id_panier_global;

            DetruireConnexionEtCommande();

            var depotPanierGlobal = new Panier_GlobalDepot_DAL();
            foreach (var item in panier.Panier_Global)
            {
                depotPanierGlobal.Update(item);
            }

            var depotReferences = new ReferencesDepot_DAL();
            foreach (var item in panier.References)
            {
                depotReferences.Update(item);
            }

            return panier;
        }

        public override void Delete(Panier_Global_Detail_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_global_detail where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer le panier global detail d'ID {panier.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
