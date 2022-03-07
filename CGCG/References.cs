using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG
{
    public class References
    {
        public int id { get; set; }

        public string reference { get; set; }

        public string libelle { get; set; }

        public string marque { get; set; }

        public bool desactive { get; set; }

        public References(string Reference, string Libelle, string Marque, bool Desactive)
        {
            reference = Reference;
            libelle = Libelle;
            marque = Marque;
            desactive = Desactive;
        }

        public References(int ID, string Reference, string Libelle, string Marque, bool Desactive)
           : this(Reference, Libelle, Marque, Desactive)
        {
            id = ID;
        }
    }
}
