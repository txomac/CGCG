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

        [HttpGet("AllFournisseurs")]
        public IEnumerable<Fournisseurs_DTO> GetAllFournisseurs()
        {
            return service.GetAllFournisseurs().Select(f => new Fournisseurs_DTO()
            {
                id = f.id,
                nom = f.nom,
                prenom = f.prenom,
                societe = f.societe,
                email = f.email,
                adresse = f.addresse,
                status = f.status
            });
        }

        [HttpPost]
        public Fournisseurs_DTO Insert(Fournisseurs_DTO f)
        {
            var f_metier = service.Insert(new Fournisseurs(f.id, f.nom, f.prenom, f.societe, f.email, f.adresse, f.status));
            //Je récupère l'ID
            f.id = f_metier.id;
            //je renvoie l'objet DTO
            return f;
        }

        [HttpGet("{idFournisseurs}")]
        public Fournisseurs_DTO GetFournisseursByID([FromRoute] int idFournisseurs)
        {
            var f = service.GetFournisseursByID(idFournisseurs);

            return new Fournisseurs_DTO()
            {
                id = f.id,
                nom = f.nom,
                prenom = f.prenom,
                societe = f.societe,
                email = f.email,
                adresse = f.addresse,
                status = f.status
            };
        }

        [HttpPut]
        public Fournisseurs_DTO GetPutFournisseur(Fournisseurs_DTO f)
        {
            var f_metier = service.Update(new Fournisseurs(f.id,f.nom,f.prenom,f.societe,f.email,f.adresse, f.status));
            f.id = f_metier.id;
            f.nom = f_metier.nom;
            f.prenom = f_metier.prenom;
            f.societe = f_metier.societe;
            f.email = f_metier.email;
            f.adresse = f_metier.addresse;
            f.status = f_metier.status;
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
