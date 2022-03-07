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

            commande.CommandText = "select id, reference, libelle, marque, desactive from [references]";
            var reader = commande.ExecuteReader();

            var listeReferences = new List<References_DAL>();

            while (reader.Read())
            {
                var r = new References_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetBoolean(4));
                                            
                listeReferences.Add(r);
            }

            DetruireConnexionEtCommande();

            return listeReferences;
        }
        public override References_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, reference, libelle, marque, desactive  from [references] where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            References_DAL references;
            if (reader.Read())
            {
                references = new References_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetBoolean(4));
                                            
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return references;
        }
        public override References_DAL Insert(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into [references](reference, libelle, marque, desactive)"
                                    + " values (@REFERENCE, @LIBELE, @MARQUE, @DESACTIVE); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@REFERENCE", references.reference));
            commande.Parameters.Add(new SqlParameter("@LIBELE", references.libelle));
            commande.Parameters.Add(new SqlParameter("@MARQUE", references.marque));
            commande.Parameters.Add(new SqlParameter("@DESACTIVE", references.desactive));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            references.id = ID;

            DetruireConnexionEtCommande();

            return references;
        }
        public override References_DAL Update(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update [references] set reference=@REFERENCES, libelle=@LIBELE, marque=@MARQUE, desactive=@DESACTIVE where ID=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", references.id));
            commande.Parameters.Add(new SqlParameter("@REFERENCES", references.reference));
            commande.Parameters.Add(new SqlParameter("@LIBELE", references.libelle));
            commande.Parameters.Add(new SqlParameter("@MARQUE", references.marque));
            commande.Parameters.Add(new SqlParameter("@DESACTIVE", references.desactive));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la référence d'ID {references.id}");
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
                throw new Exception($"Impossible de supprimer la référence d'ID {references.id}");
            }

            DetruireConnexionEtCommande();
        }

        public void DesactiverReference(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update [references] set desactive=@DESACTIVE where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre a jour la ligne desactive d'ID {ID}");
            }

            DetruireConnexionEtCommande();
        }

        public int GetNomReferenceWithID(string Reference)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id from [references] where reference=@REFERENCE";
            commande.Parameters.Add(new SqlParameter("@REFERENCE", Reference));
            var reader = commande.ExecuteReader();

            var references = 0;
            if (reader.Read())
            {
                references = reader.GetInt32(0);
            }
            else
                throw new Exception($"Il n'y a pas de reference de nom : {Reference}");

            DetruireConnexionEtCommande();

            return references;
        }

        public List<string> GetAllReference()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select reference from [references]";
            var reader = commande.ExecuteReader();

            var listeReferences = new List<string>();

            while (reader.Read())
            {
                listeReferences.Add(reader.GetString(0));
            }

            DetruireConnexionEtCommande();

            return listeReferences;
        }
    }
}
