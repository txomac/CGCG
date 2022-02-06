using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IPanier_FournisseursService
    {
        public List<Panier_Fournisseurs> GetAllPanier_Fournisseurs();

        public Panier_Fournisseurs GetPanierFournisseursByID(int ID);

        public Panier_Fournisseurs Insert(Panier_Fournisseurs pf);

        public Panier_Fournisseurs Update(Panier_Fournisseurs p);


    }
}
