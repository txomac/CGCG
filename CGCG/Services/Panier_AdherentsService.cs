using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class Panier_AdherentsService : IPanier_AdherentsService
    {
        public Panier_AdherentsDepot_DAL depot = new Panier_AdherentsDepot_DAL();

        public List<Panier_Adherents> GetAllPanierAdherents()
        {
            var panier = depot.GetAll()
                .Select(p => new Panier_Adherents(p.id, p.id_adherents, p.id_panier_global, p.semaine))
                .ToList();

            return panier;
        }

        public Panier_Adherents GetPanierAdherentsByID(int ID)
        {
            var p = depot.GetByID(ID);
            var panier = new Panier_Adherents(p.id, p.id_adherents, p.id_panier_global, p.semaine);

            return panier;
        }

        public Panier_Adherents Insert(Panier_Adherents p)
        {
            var panier = new Panier_Adherents_DAL(p.id, p.id_adherents, p.id_panier_global, p.semaine);

            depot.Insert(panier);

            return p;
        }

        public Panier_Adherents Update(Panier_Adherents p)
        {
            var panier = new Panier_Adherents_DAL(p.id, p.id_adherents, p.id_panier_global, p.semaine);

            depot.Update(panier);

            return p;
        }

        public void Delete(Panier_Adherents p)
        {
            var panier = new Panier_Adherents_DAL(p.id, p.id_adherents, p.id_panier_global, p.semaine);

            depot.Delete(panier);
        }
    }
}
