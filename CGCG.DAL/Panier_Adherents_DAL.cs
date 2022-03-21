using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCG.DAL
{
    public class Panier_Adherents_DAL
    {
        public int id { get; set; }

        public int id_adherents { get; set; }

        public int id_panier_global { get; set; }

        public int semaine { get; set; }


        public Panier_Adherents_DAL(int ID_Adherents, int ID_Panier_Global, int Semaine)
        {
            id_adherents = ID_Adherents;
            id_panier_global = ID_Panier_Global;
            semaine = Semaine;
        }

        public Panier_Adherents_DAL(int ID, int ID_Adherents, int ID_Panier_Global, int Semaine)
            : this(ID_Adherents, ID_Panier_Global, Semaine)
        {
            id = ID;
        }
    }
}
