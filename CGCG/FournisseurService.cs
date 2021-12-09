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
                    .Select(f => new Fournisseurs(f.id,f.nom,f.prenom,f.societe,f.email,f.adresse))
                    .ToList();

            return Fournisseurs;
        }
        public Fournisseurs GetFournisseursByID(int ID) 
        {
            var f = depot.GetByID(ID);
            var fournisseur = new Fournisseurs(f.id, f.nom, f.prenom, f.societe, f.email, f.adresse);
            return fournisseur;
        }
        public Fournisseurs Insert(Fournisseurs f)
        {
            var poly = new Polygone_DAL(t.Select(p => new Point_DAL(p.X, p.Y)));
            depot.Insert(poly);

            t.ID = poly.ID;

            return t;
        }
        public Fournisseurs Update(Fournisseurs f)
        {
            var poly = new Polygone_DAL(t.ID, null, null, t.Select(p => new Point_DAL(p.X, p.Y)));
            depot.Update(poly);

            return t;
        }
        public void Delete(Fournisseurs f) 
        {
            var poly = new Polygone_DAL(t.ID, null, null, t.Select(p => new Point_DAL(p.X, p.Y)));
            depot.Delete(poly);
        }
    }
}
