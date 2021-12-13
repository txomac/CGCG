using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IPanier_Adherents_DetailsService
    {
        public List<Panier_Adherents_Details> GetAllPanierAdherentsDetails();
        public Panier_Adherents_Details GetPanierAdherentsDetailsByID(int ID);
        public Panier_Adherents_Details Insert(Panier_Adherents_Details p);
        public Panier_Adherents_Details Update(Panier_Adherents_Details p);
        public void Delete(Panier_Adherents_Details p);
    }
}
