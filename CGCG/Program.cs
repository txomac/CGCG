using System;
using CGCG.DAL;

namespace CGCG
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region AjoutDansFournisseurReference
            FournisseursDepot_DAL depot = new FournisseursDepot_DAL();
            Fournisseurs_DAL fournisseur1 = depot.GetByID(1);

            ReferencesDepot_DAL depot2 = new ReferencesDepot_DAL();
            References_DAL reference1 = depot2.GetByID(1);

            Fournisseurs_References fourrefe = new Fournisseurs_References(fournisseur1.id, reference1.id);

            fourrefe.Insert(fournisseur1, reference1);
            #endregion


        }
    }
}
