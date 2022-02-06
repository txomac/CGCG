using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;

namespace CGCG.CSV
{
    public class Panier_GlobalCSV
    {
        public void EcrireCSV()
        {
            ReferencesDepot_DAL depotReference = new ReferencesDepot_DAL();
            Panier_Global_DetailDepot_DAL panierGlobalDetail = new Panier_Global_DetailDepot_DAL();
            List<string> listeReference = new List<string>();
            List<Int32> listeQuantite = new List<Int32>();
            StringBuilder listeCSV = new StringBuilder();
            listeCSV.Append("reference");
            listeCSV.Append(';');
            listeCSV.Append("quantite");
            listeCSV.Append(';');
            listeCSV.Append("prix unitaire HT");
            listeCSV.Append('\n');

            listeReference = depotReference.GetAllReference();
            listeQuantite = panierGlobalDetail.GetAllQuantite();

            for (var index = 0; index <= listeReference.Count; index++)
            {
                listeCSV.Append(listeReference[index]);
                listeCSV.Append(';');
                listeCSV.Append(listeQuantite[index]);
                listeCSV.Append(0);
                listeCSV.Append('\n');
            }

            File.WriteAllText(@"C:\Users\thoma\Desktop",listeCSV.ToString());
        }

        /*public bool CheckIfNameAlrdyHere(string nom, List<string> liste)
        {
            var check = false;
            foreach (var item in liste)
            {
                if (item != nom)
                {
                    check = true;
                }
            }
            return check;
        }*/
    }
}
