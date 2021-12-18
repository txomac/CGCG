using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCG.DAL;


namespace CGCG
{
    public class AdherentCSV
    {
        public void ActionAddCSVAdherent(Adherents adherent, Panier_Global panier_global)
        {
            var reader = new StreamReader(File.OpenRead(@"D:\New folder\Data.csv")); //todo : add path directory
            List<string> reference = new List<string>();
            List<Int32> quantite = new List<Int32>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                reference.Add(values[0]);
                quantite.Add(int.Parse(values[1]));

                Panier_Adherents_DetailsDepot_DAL depotPanierDetail = new Panier_Adherents_DetailsDepot_DAL();
                ReferencesDepot_DAL referenceDepot = new ReferencesDepot_DAL();
                Panier_AdherentsDepot_DAL panier_adherent = new Panier_AdherentsDepot_DAL();
                var id_panier_global = panier_global.id;


                Panier_Adherents_DAL panier_adherentDal = new Panier_Adherents_DAL(adherent.id, id_panier_global);

                panier_adherent.Insert(panier_adherentDal);

                var id_reference = referenceDepot.GetNomReferenceWithID(reference[0]);

                Panier_Adherent_Details_DAL panierAdherentDAL = new Panier_Adherent_Details_DAL(quantite[0], id_reference, panier_adherentDal.id);
                
            }
        }
    }
}
