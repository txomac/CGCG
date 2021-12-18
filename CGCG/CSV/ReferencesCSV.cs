using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG
{
    public class ReferencesCSV
    {
        public void ActionAddCSVReference(Fournisseurs fournisseur)
        {
            var reader = new StreamReader(File.OpenRead(@"D:\New folder\Data.csv")); //todo : add path directory
            List<string> referencelist = new List<string>();
            List<string> libelle = new List<string>();
            List<string> marque = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                referencelist.Add(values[0]);
                libelle.Add(values[1]);
                marque.Add(values[2]);

                References referenceAdd = new References(referencelist[0], libelle[0], marque[0], false, fournisseur.id);

                References_DAL referenceDAL = new References_DAL(referenceAdd.reference, referenceAdd.libelle, referenceAdd.marque,referenceAdd.desactive,referenceAdd.id);

                var depotReference = new ReferencesDepot_DAL();

                depotReference.Insert(referenceDAL);

            }
        }
        
    }
}
