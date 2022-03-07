using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IReferencesService
    {
        public List<References> GetAllReferences();
        public References GetReferencesByID(int ID);
        public List<References> GetByReference(string reference);
        public References Insert(References r);
        public References Update(References r);
        public void Delete(References r);
    }
}
