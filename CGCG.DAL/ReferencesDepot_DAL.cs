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

            commande.CommandText = "select id, reference, libelle, marque, desactive from references";
            var reader = commande.ExecuteReader();

            var listeReferences = new List<References_DAL>();

            while (reader.Read())
            {
                var r = new References_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetString(3),
                                            reader.GetBoolean(4),
                                            reader.GetInt32(5));
                listeReferences.Add(r);
            }

            DetruireConnexionEtCommande();

            return listeReferences;
        }
        public override References_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id,reference,libelle,marque,desactive, id_fournisseurs from [references] where id=@ID";
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
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return references;
        }
        public override References_DAL Insert(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into references(references, libele, marque, desactive, id_fournisseurs)"
                                    + " values (@REFERENCES, @LIBELE, @MARQUE, @DESACTIVE, @ID_FOURNISSEURS); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@REFERENCES", references.reference));
            commande.Parameters.Add(new SqlParameter("@LIBELE", references.libelle));
            commande.Parameters.Add(new SqlParameter("@MARQUE", references.marque));
            commande.Parameters.Add(new SqlParameter("@DESACTIVE", references.desactive));
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEURS", references.id_fournisseurs));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            references.id = ID;

            DetruireConnexionEtCommande();

            return references;
        }
        public override References_DAL Update(References_DAL references)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update references set references=@REFERENCES, libele=@LIBELE, marque=@MARQUE, desactive=@DESACTIVE, id_fournisseurs=@ID_FOURNISSEURS)"
                                    + " where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@REFERENCES", references.reference));
            commande.Parameters.Add(new SqlParameter("@LIBELE", references.libelle));
            commande.Parameters.Add(new SqlParameter("@MARQUE", references.marque));
            commande.Parameters.Add(new SqlParameter("@DESACTIVE", references.desactive));
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEURS", references.id_fournisseurs));
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
    }
}
