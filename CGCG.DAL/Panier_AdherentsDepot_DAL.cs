using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    class Panier_AdherentsDepot_DAL : Depot_DAL<Panier_Adherents_DAL>
    {
        public override List<Panier_AdherentsDepot_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, puht from panier_fournisseurs";
            var reader = commande.ExecuteReader();

            var depotFournisseur = new FournisseursDepot_DAL();

            var listePanier = new List<Panier_Fournisseurs_DAL>();

            while (reader.Read())
            {
                var p = new Panier_Fournisseurs_DAL(reader.GetInt32(0),
                                                    reader.GetFloat(1),
                                                    reader.GetInt32(2),
                                                    reader.GetInt32(3));

                listePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePanier;
        }

        public override Panier_Fournisseurs_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, puht, id_fournisseur, id_panier_global_detail from panier_fournisseur where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var depotFournisseurs = new FournisseursDepot_DAL();

            Panier_Fournisseurs_DAL p;

            if (reader.Read())
            {
                p = new Panier_Fournisseurs_DAL(reader.GetInt32(0),
                                                reader.GetFloat(1),
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

        public override Panier_Fournisseurs_DAL Insert(Panier_Fournisseurs_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_fournisseur(puht, id_fournisseur, id_panier_global_detail)" + " values (@PUHT, @ID_FOURNISSEUR, @ID_PANIER_GLOBAL_DETAIL); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@PUHT", panier.puht));
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEUR", panier.id_fournisseur));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBAL_DETAIL", panier.id_panier_global_detail));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.puht = GetByID(ID).puht;
            panier.id_fournisseur = GetByID(ID).id_fournisseur;
            panier.id_panier_global_detail = GetByID(ID).id_panier_global_detail;
            DetruireConnexionEtCommande();

            var depotFournisseur = new FournisseursDepot_DAL();
            foreach (var item in panier.Fournisseurs)
            {
                item.id = ID;
                depotFournisseur.Insert(item);
            }

            return panier;
        }

        public override Panier_Fournisseurs_DAL Update(Panier_Fournisseurs_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_fournisseurs set puht=@PUHT, id_fournisseur=@ID_FOURNISSEUR, id_panier_global_detail=@ID_PANIER_GLOBAL_DETAIL where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier fournisseur d'ID {panier.id}");
            }

            panier.puht = GetByID(panier.id).puht;

            DetruireConnexionEtCommande();

            var depotFournisseur = new FournisseursDepot_DAL();
            foreach (var item in panier.Fournisseurs)
            {
                depotFournisseur.Update(item);
            }

            return panier;
        }

        public override void Delete(Panier_Fournisseurs_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_fournisseur where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer le panier fournisseur d'ID {panier.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
}
