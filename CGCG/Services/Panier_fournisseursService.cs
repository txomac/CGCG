using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;


namespace CGCG
{
    class Panier_fournisseursService : IPanier_FournisseursService
    {
        private Panier_FournisseursDepot_DAL depot = new Panier_FournisseursDepot_DAL();

        public List<Panier_fournisseurs> GetAllPanier_fournisseurs()
        {
            var Fournisseurs = depot.GetAll() //retourne tous les fournisseurs (fournisser_DAL) de la BDD
                    .Select(f => new Fournisseurs(f.id, f.nom, f.prenom, f.societe, f.email, f.adresse))
                    .ToList();

            return Fournisseurs;
        }
        public Panier_fournisseurs Insert(Panier_fournisseurs pf)
        {
            var fournisseur = new Fournisseurs_DAL(f.nom, f.prenom, f.societe, f.email, f.adresse);
            depot.Insert(fournisseur);

            return f;
        }
    }
}
