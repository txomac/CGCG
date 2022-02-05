using System;

namespace CGCG.DTO
{
    public class Adherent_DTO
    {
        public int id { get; set; }

        public string nom { get; set; }

        public string prenom { get; set; }

        public string societe { get; set; }

        public string email { get; set; }

        public string adresse { get; set; }

        public DateTime dateadhesion { get; set; }

        public bool status { get; set; }

    }
}
