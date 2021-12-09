using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

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

        public void Insert(Fournisseurs_DAL fournisseur, References_DAL reference)
        {
            Fournisseurs_References_DAL fournisseurDAL = new Fournisseurs_References_DAL(fournisseur.id, reference.id);

            var depotFournisseur = new Fournisseurs_ReferencesDepot_DAL();

            depotFournisseur.Insert(fournisseurDAL);

        }
    }
}
