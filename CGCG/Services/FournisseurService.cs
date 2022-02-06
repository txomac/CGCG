using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class FournisseurService : IFournisseursService
    {
        private FournisseursDepot_DAL depot = new FournisseursDepot_DAL();

        public List<Fournisseurs> GetAllFournisseurs()
        {
            var Fournisseurs = depot.GetAll() //retourne tous les fournisseurs (fournisser_DAL) de la BDD
                    .Select(f => new Fournisseurs(f.id,f.nom,f.prenom,f.societe,f.email,f.addresse, f.status))
                    .ToList();

            return Fournisseurs;
        }
        public Fournisseurs GetFournisseursByID(int ID) 
        {
            var f = depot.GetByID(ID);
            var fournisseur = new Fournisseurs(f.id, f.nom, f.prenom, f.societe, f.email, f.addresse, f.status);
            return fournisseur;
        }
        public Fournisseurs Insert(Fournisseurs f)
        {
            var fournisseur = new Fournisseurs_DAL(f.nom, f.prenom, f.societe, f.email, f.addresse, f.status);
            depot.Insert(fournisseur);

            return f;
        }
        public Fournisseurs Update(Fournisseurs f)
        {
            var fournisseur= new Fournisseurs_DAL(f.nom,f.prenom,f.societe,f.email,f.addresse, f.status);
            depot.Update(fournisseur);

            return f;
        }
        public void Delete(Fournisseurs f) 
        {
            var fournisseur = new Fournisseurs_DAL(f.nom, f.prenom, f.societe, f.email, f.addresse, f.status);
            depot.Delete(fournisseur);
        }
    }
}
