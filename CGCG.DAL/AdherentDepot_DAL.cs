using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherents_DAL>
    {
        public override List<Adherents_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenom, societe, email, adresse, dateadhesion from adherents";
            var reader = commande.ExecuteReader();

            var listeDAdherents = new List<Adherents_DAL>();

            while (reader.Read())
            {
                var a = new Adherents_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetString(4),
                                            reader.GetString(5),
                                            reader.GetDateTime(6));
                listeDAdherents.Add(a);
            }

            DetruireConnexionEtCommande();

            return listeDAdherents;
        }
        public override Adherents_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenom, societe, email, adresse, dateadhesion from adherents where ID=@id";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Adherents_DAL adherent;
            if (reader.Read())
            {
                adherent = new Adherents_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetString(4),
                                            reader.GetString(5),
                                            reader.GetDateTime(6));
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return adherent;
        }
        public override Adherents_DAL Insert(Adherents_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into adherents(nom, prenom, societe, email, adresse, dateadhesion)"
                                    + " values (@NOM, @PRENOM, @SOCIETE, @EMAIL, @ADRESSE, @DATEADHESION); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NOM", adherent.nom));
            commande.Parameters.Add(new SqlParameter("@PRENOM", adherent.prenom));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", adherent.societe));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", adherent.email));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", adherent.adresse));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", adherent.dateadhesion));


            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            adherent.ID = ID;

            DetruireConnexionEtCommande();

            return adherent;
        }
        public override Adherents_DAL Update(Adherents_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update adherents set nom=@NOM, prenom=@PRENOM, societe=@SOCIETE, email=@EMAIL, adresse=@ADRESSE, dateadhesion=@DATEADHESION)"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            commande.Parameters.Add(new SqlParameter("@NOM", adherent.nom));
            commande.Parameters.Add(new SqlParameter("@PRENOM", adherent.prenom));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", adherent.societe));
            commande.Parameters.Add(new SqlParameter("@EMAIL", adherent.email));
            commande.Parameters.Add(new SqlParameter("@ADRESSE", adherent.adresse));
            commande.Parameters.Add(new SqlParameter("@DATEADHESION", adherent.dateadhesion));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'adhérent d'ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();

            return adherent;
        }
        public override void Delete(Adherents_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent d'ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
