using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class Panier_Adherents_DetailsService : IPanier_Adherents_DetailsService
    {
        public Panier_Adherents_DetailsDepot_DAL depot = new Panier_Adherents_DetailsDepot_DAL();

        public List<Panier_Adherents_Details> GetAllPanierAdherentsDetails()
        {
            var panier = depot.GetAll()
                .Select(p => new Panier_Adherents_Details(p.id, p.quantite, p.id_panier_adherents, p.id_references))
                .ToList();

            return panier;
        }

        public Panier_Adherents_Details GetPanierAdherentsDetailsByID(int ID)
        {
            var p = depot.GetByID(ID);
            var panier = new Panier_Adherents_Details(p.id, p.quantite, p.id_panier_adherents, p.id_references);

            return panier;
        }

        public Panier_Adherents_Details Insert(Panier_Adherents_Details p)
        {
            var panier = new Panier_Adherent_Details_DAL(p.id, p.quantite, p.id_panier_adherents, p.id_references);

            depot.Insert(panier);

            return p;
        }

        public Panier_Adherents_Details Update(Panier_Adherents_Details p)
        {
            var panier = new Panier_Adherent_Details_DAL(p.id, p.quantite, p.id_panier_adherents, p.id_references);

            depot.Update(panier);

            return p;
        }

        public void Delete(Panier_Adherents_Details p)
        {
            var panier = new Panier_Adherent_Details_DAL(p.id, p.quantite, p.id_panier_adherents, p.id_references);

            depot.Delete(panier);
        }
    }
}
