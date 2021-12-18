using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IPanier_AdherentsService
    {
        public List<Panier_Adherents> GetAllPanierAdherents();
        public Panier_Adherents GetPanierAdherentsByID(int ID);
        public Panier_Adherents Insert(Panier_Adherents p);
        public Panier_Adherents Update(Panier_Adherents p);
        public void Delete(Panier_Adherents p);
    }
}
