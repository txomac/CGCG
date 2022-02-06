using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DTO
{
    public class Panier_AdherentDetail_DTO
    {
        public int id { get; set; }
        public int quantite { get; set; }
        public int id_references { get; set; }
        public int id_panier_adherents { get; set; }
    }
}
