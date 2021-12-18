using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class ReferencesService : IReferencesService
    {
        public ReferencesDepot_DAL depot = new ReferencesDepot_DAL();

        public List<References> GetAllReferences()
        {
            var references = depot.GetAll()
                .Select(r => new References(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs))
                .ToList();

            return references;
        }

        public References GetReferencesByID(int ID)
        {
            var r = depot.GetByID(ID);
            var references = new References(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs);

            return references;
        }

        public References Insert(References r)
        {
            var references = new References_DAL(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs);

            depot.Insert(references);

            return r;
        }

        public References Update(References r)
        {
            var references = new References_DAL(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs);

            depot.Update(references);

            return r;
        }

        public void Delete(References r)
        {
            var references = new References_DAL(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs);

            depot.Delete(references);
        }
    }
}
