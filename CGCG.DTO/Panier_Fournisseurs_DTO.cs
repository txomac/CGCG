using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DTO
{
    public class Panier_Fournisseurs_DTO
    {
        public int id { get; set; }

        public float? puht { get; set; }

        public int id_fournisseur { get; set; }

        public int id_panier_global_detail { get; set; }
    }
}
