using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Panier_Global
    {
        public int id { get; set; }
        public int semaine { get; set; }

        public Panier_Global(int Semaine)
        {
            semaine = Semaine;
        }

        public Panier_Global(int ID, int Semaine)
            :this(Semaine)
        {
            id = ID;
            semaine = Semaine;
        }
    }
}
