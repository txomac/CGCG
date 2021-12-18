using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class Panier_Global_DetailService : IPanier_Global_DetailService
    {
        public Panier_Global_DetailDepot_DAL depot = new Panier_Global_DetailDepot_DAL();

        public List<Panier_Global_Detail> GetAllPanierGlobalDetail()
        {
            var panier = depot.GetAll()
                .Select(p => new Panier_Global_Detail(p.id, p.quantite, p.id_panier_global, p.id_references))
                .ToList();

            return panier;
        }

        public Panier_Global_Detail GetPanierGlobalDetailByID(int ID)
        {
            var p = depot.GetByID(ID);
            var panier = new Panier_Global_Detail(p.id, p.quantite, p.id_panier_global, p.id_references);

            return panier;
        }

        public Panier_Global_Detail Insert(Panier_Global_Detail p)
        {
            var panier = new Panier_Global_Detail_DAL(p.id, p.quantite, p.id_panier_global, p.id_references);

            depot.Insert(panier);

            return p;
        }

        public Panier_Global_Detail Update(Panier_Global_Detail p)
        {
            var panier = new Panier_Global_Detail_DAL(p.id, p.quantite, p.id_panier_global, p.id_references);

            depot.Update(panier);

            return p;
        }

        public void Delete(Panier_Global_Detail p)
        {
            var panier = new Panier_Global_Detail_DAL(p.id, p.quantite, p.id_panier_global, p.id_references);

            depot.Delete(panier);
        }
    }
}
