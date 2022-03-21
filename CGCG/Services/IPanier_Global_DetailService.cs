using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IPanier_Global_DetailService
    {
        public List<Panier_Global_Detail> GetAllPanierGlobalDetail();
        public Panier_Global_Detail GetPanierGlobalDetailByID(int ID);
        public Panier_Global_Detail Insert(Panier_Global_Detail p);
        public Panier_Global_Detail Update(Panier_Global_Detail p);
        public void Delete(Panier_Global_Detail p);

        public List<Panier_Global_Detail> GetByIDPanierGlobal(int ID);

    }
}
