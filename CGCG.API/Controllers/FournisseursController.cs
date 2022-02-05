using CGCG.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGCG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FournisseursController : ControllerBase
    {
        private IFournisseursService service;

        public FournisseursController(IFournisseursService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Fournisseurs_DTO> GetAllFournisseurs()
        {
            return service.GetAllFournisseurs().Select(f => new Fournisseurs_DTO()
            {
                id = f.id,
                nom = f.nom,
                prenom = f.prenom,
                societe = f.societe,
                email = f.email,
                adresse = f.addresse
            });
        }

        [HttpPost]
        public Fournisseurs_DTO Insert(Fournisseurs_DTO f)
        {
            var f_metier = service.Insert(new Fournisseurs(f.id, f.nom, f.prenom, f.societe, f.email, f.adresse));
            //Je récupère l'ID
            f.id = f_metier.id;
            //je renvoie l'objet DTO
            return f;
        }

        [HttpPost("{id}")]
        public Fournisseurs_DTO GetFournisseursByID([FromRoute] int id)
        {
            var f = service.GetFournisseursByID(id);

            return new Fournisseurs_DTO()
            {
                id = f.id,
                nom = f.nom,
                prenom = f.prenom,
                societe = f.societe,
                email = f.email,
                adresse = f.addresse
            };
        }

        [HttpPut]
        public Fournisseurs_DTO GetPutFournisseur(Fournisseurs_DTO f)
        {
            var f_metier = service.Update(new Fournisseurs(f.id,f.nom,f.prenom,f.societe,f.email,f.adresse));
            f.id = f_metier.id;
            f.nom = f_metier.nom;
            f.prenom = f_metier.prenom;
            f.societe = f_metier.societe;
            f.email = f_metier.email;
            f.adresse = f_metier.addresse;
            return f;
        }

        [HttpDelete]
        public void DeleteFournisseur(int id)
        {
            var f_metier = service.GetFournisseursByID(id);

            service.Delete(f_metier);
        }



    }
}
