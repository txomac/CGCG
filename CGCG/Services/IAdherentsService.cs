using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public interface IAdherentsService
    {
        public List<Adherents> GetAllAdherents();
        public Adherents GetAdherentsByID(int ID);
        public Adherents Insert(Adherents a);
        public Adherents Update(Adherents a);
        public void Delete(Adherents a);
    }
}
