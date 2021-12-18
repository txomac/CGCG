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

        public List<Panier_Fournisseurs> GetAllPanier_Fournisseurs()
        {
            var Panier_Fournisseurs = depot.GetAll() //retourne tous les fournisseurs (fournisser_DAL) de la BDD
                    .Select(f => new Panier_Fournisseurs(f.id, f.puht, f.id_fournisseur, f.id_panier_global_detail))
                    .ToList();

            return Panier_Fournisseurs;
        }
        public Panier_Fournisseurs Insert(Panier_Fournisseurs pf)
        {
            var Panier_Fournisseurs = new Panier_Fournisseurs_DAL(pf.puht, pf.id_fournisseur, pf.id_panier_global_detail);
            depot.Insert(Panier_Fournisseurs);

            return pf;
        }
    }
}
