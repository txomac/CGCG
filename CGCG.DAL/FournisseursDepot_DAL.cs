using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class FournisseursDepot_DAL : Depot_DAL<Fournisseurs_DAL>
    {
        public override List<Fournisseurs_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenom, societe, email, adresse, id_panier_fournisseur from fournisseurs";
            var reader = commande.ExecuteReader();

            var listeDeFournisseurs = new List<Fournisseurs_DAL>();

            while (reader.Read())
            {
                var f = new Fournisseurs_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetString(4),
                                            reader.GetString(5),
                                            reader.GetInt32(6));
                listeDeFournisseurs.Add(f);
            }

            DetruireConnexionEtCommande();

            return listeDeFournisseurs;
        }

        public override Fournisseurs_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, nom, prenom, societe, email, adresse, id_panier_fournisseur from Points where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Fournisseurs_DAL f;
            if (reader.Read())
            {
                f = new Fournisseurs_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetInt32(6));
            }
            else
                throw new Exception($"Pas de fournisseur dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return f;
        }

        public override Fournisseurs_DAL Insert(Fournisseurs_DAL fournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs(nom, prenom, societe, email, adresse, id_panier_fournisseur)"
                                    + " values (@NOM, @PRENOM, @SOCIETE, @EMAIL, @ADRESSE, @ID_PANIER_FOURNISSEUR); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NOM", fournisseurs.nom));
            commande.Parameters.Add(new SqlParameter("@PRENOM", fournisseurs.prenom));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", fournisseurs.societe));
            commande.Parameters.Add(new SqlParameter("@EMAIL", fournisseurs.email));
            commande.Parameters.Add(new SqlParameter("@ADRESSE", fournisseurs.adresse));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_FOURNISSEUR", fournisseurs.id_panier_fournisseur));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            fournisseurs.id = ID;

            DetruireConnexionEtCommande();

            return fournisseurs;
        }

        public override Fournisseurs_DAL Update(Fournisseurs_DAL fournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update fournisseurs set nom=@NOM, prenom=@PRENOM, societe=@SOCIETE, email=@EMAIL, adresse=@ADRESSE, id_panier_fournisseur=@ID_PANIER_FOURNISSEUR)"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", fournisseurs.id));
            commande.Parameters.Add(new SqlParameter("@NOM", fournisseurs.nom));
            commande.Parameters.Add(new SqlParameter("@PRENOM", fournisseurs.prenom));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", fournisseurs.societe));
            commande.Parameters.Add(new SqlParameter("@EMAIL", fournisseurs.email));
            commande.Parameters.Add(new SqlParameter("@ADRESSE", fournisseurs.adresse));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_FOURNISSEUR", fournisseurs.id_panier_fournisseur));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur d'ID {fournisseurs.id}");
            }

            DetruireConnexionEtCommande();

            return fournisseurs;
        }

        public override void Delete(Fournisseurs_DAL fournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from fournisseurs where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", fournisseurs.id));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le fournisseur d'ID {fournisseurs.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
