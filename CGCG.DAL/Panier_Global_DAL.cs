using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Global_DAL
    {
        public int semaine { get; set; }

        public int id { get; set; }

        public Panier_Global_DAL(int Semaine)
        {
            semaine = Semaine;
        }

        public Panier_Global_DAL(int ID, int Semaine)
            : this(Semaine)
        {
            id = ID;
            semaine = Semaine;
        }
    }
}
