using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class Fournisseurs_References
    {
        public int id_fournisseurs { get; set; }
        public int id_references { get; set; }

        public Fournisseurs_References(int ID_Fournisseurs, int ID_References)
        {
            id_fournisseurs = ID_Fournisseurs;
            id_references = ID_References;
        }
    }
}
