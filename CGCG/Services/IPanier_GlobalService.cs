using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IPanier_GlobalService
    {
        public List<Panier_Global> GetAllPanierGlobal();
        public Panier_Global GetPanierGlobalByID(int ID);
        public Panier_Global Insert(Panier_Global p);
        public Panier_Global Update(Panier_Global p);
        public void Delete(Panier_Global p);
    }
}
