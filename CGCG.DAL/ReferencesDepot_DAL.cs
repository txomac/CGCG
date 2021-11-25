using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class ReferencesDepot_DAL : Depot_DAL<References_DAL>
    {
        public override List<References_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, reference, libele, marque, desactive, IDFournisseur from references";
            var reader = commande.ExecuteReader();

            var listeDeReferences = new List<References_DAL>();

            while (reader.Read())
            {
                var r = new References_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetBoolean(4),
                                            reader.GetInt32(5));
                listeDeReferences.Add(r);
            }

            DetruireConnexionEtCommande();

            return listeDeReferences;
        }
        public override References_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, reference, libele, marque, desactive, IDFournisseur from references where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            References_DAL references;
            if (reader.Read())
            {
                references = new References_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetBoolean(4),
                                            reader.GetInt32(5));
            }
            else
                throw new Exception($"Pas de references dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return references;
        }
        public override References_DAL Insert(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into references(reference, libele, marque, desactive, IDFournisseur)"
                                    + " values (@REFERENCE, @LIBELE, @MARQUE, @DESACTIVE, @IDFOURNISSEUR); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NOM", references.reference));
            commande.Parameters.Add(new SqlParameter("@PRENOM", references.libelle));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", references.marque));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", references.desactive));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", references.id_Fournisseurs));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            references.id = ID;

            DetruireConnexionEtCommande();

            return references;
        }
        public override References_DAL Update(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update reference set reference=@REFERENCE, libele=@LIBELE, marque=@MARQUE, desactive=@DESACTIVE, id_Fournisseur=@IDFOURNISSEUR)"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", references.reference));
            commande.Parameters.Add(new SqlParameter("@NOM", references.libelle));
            commande.Parameters.Add(new SqlParameter("@PRENOM", references.marque));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", references.desactive));
            commande.Parameters.Add(new SqlParameter("@EMAIL", references.id_Fournisseurs));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la reference d'ID {references.id}");
            }

            DetruireConnexionEtCommande();

            return references;
        }
        public override void Delete(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from references where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", references.id));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la reference d'ID {references.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
