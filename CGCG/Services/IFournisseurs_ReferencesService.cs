using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IFournisseurs_ReferencesService
    {
        public List<Fournisseurs_References> GetAllFournisseursReferences();
        public Fournisseurs_References GetFournisseursReferencesByID(int ID);
        public Fournisseurs_References Insert(Fournisseurs_References fr);
        public Fournisseurs_References Update(Fournisseurs_References fr);
        public void Delete(Fournisseurs_References p);

        public void DeleteById(int id);
    }
}
