using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class Fournisseurs_ReferencesService : IFournisseurs_ReferencesService
    {
        public Fournisseurs_ReferencesDepot_DAL depot = new Fournisseurs_ReferencesDepot_DAL();

        public List<Fournisseurs_References> GetAllFournisseursReferences()
        {
            var fournisseurs_ref = depot.GetAll()
                .Select(fr => new Fournisseurs_References(fr.id_fournisseurs, fr.id_references))
                .ToList();

            return fournisseurs_ref;
        }

        public Fournisseurs_References GetFournisseursReferencesByID(int ID)
        {
            var fr = depot.GetByID(ID);
            var fournisseurs_ref = new Fournisseurs_References(fr.id_fournisseurs, fr.id_references);

            return fournisseurs_ref;
        }

        public Fournisseurs_References Insert(Fournisseurs_References fr)
        {
            var fournisseurs_ref = new Fournisseurs_References_DAL(fr.id_fournisseurs, fr.id_references);

            depot.Insert(fournisseurs_ref);

            return fr;
        }

        public Fournisseurs_References Update(Fournisseurs_References fr)
        {
            var fournisseurs_ref = new Fournisseurs_References_DAL(fr.id_fournisseurs, fr.id_references);

            depot.Update(fournisseurs_ref);

            return fr;
        }

        public void Delete(Fournisseurs_References fr)
        {
            var fournisseurs_ref = new Fournisseurs_References_DAL(fr.id_fournisseurs, fr.id_references);

            depot.Delete(fournisseurs_ref);
        }
    }
}
