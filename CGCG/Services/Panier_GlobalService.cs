using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class Panier_GlobalService : IPanier_GlobalService
    {
        public Panier_GlobalDepot_DAL depot = new Panier_GlobalDepot_DAL();

        public List<Panier_Global> GetAllPanierGlobal()
        {
            var panier = depot.GetAll()
                .Select(p => new Panier_Global(p.id, p.semaine))
                .ToList();

            return panier;
        }

        public Panier_Global GetPanierGlobalByID(int ID)
        {
            var p = depot.GetByID(ID);
            var panier = new Panier_Global(p.id, p.semaine);

            return panier;
        }

        public Panier_Global Insert(Panier_Global p)
        {
            var panier = new Panier_Global_DAL(p.id, p.semaine);

            depot.Insert(panier);

            return p;
        }

        public Panier_Global Update(Panier_Global p)
        {
            var panier = new Panier_Global_DAL(p.id, p.semaine);

            depot.Update(panier);

            return p;
        }

        public void Delete(Panier_Global p)
        {
            var panier = new Panier_Global_DAL(p.id, p.semaine);

            depot.Delete(panier);
        }
    }
}
