using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    interface IPanier_FournisseursService
    {
        public List<Panier_Fournisseurs> GetAllPanier_Fournisseurs();
        public Panier_Fournisseurs Insert(Panier_Fournisseurs pf);

    }
}
