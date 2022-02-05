using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class AdherentsService : IAdherentsService
    {
        public AdherentDepot_DAL depot = new AdherentDepot_DAL();

        public List<Adherents> GetAllAdherents()
        {
            var adherents = depot.GetAll()
                .Select(a => new Adherents(a.id, a.nom, a.prenom, a.societe, a.email, a.adresse, a.dateadhesion, a.status))
                .ToList();

            return adherents;
        }

        public Adherents GetAdherentsByID(int ID)
        {
            var a = depot.GetByID(ID);
            var adherents = new Adherents(a.id, a.nom, a.prenom, a.societe, a.email, a.adresse, a.dateadhesion, a.status);

            return adherents;
        }

        public Adherents Insert(Adherents a)
        {
            var adherents = new Adherents_DAL(a.id, a.nom, a.prenom, a.societe, a.email, a.adresse, a.dateadhesion, a.status);

            depot.Insert(adherents);

            return a;
        }

        public Adherents Update(Adherents a)
        {
            var adherents = new Adherents_DAL(a.id, a.nom, a.prenom, a.societe, a.email, a.adresse, a.dateadhesion, a.status);

            depot.Update(adherents);

            return a;
        }

        public void Delete(Adherents a)
        {
            var adherents = new Adherents_DAL(a.id, a.nom, a.prenom, a.societe, a.email, a.adresse, a.dateadhesion, a.status);

            depot.Delete(adherents);
        }
    }
}
