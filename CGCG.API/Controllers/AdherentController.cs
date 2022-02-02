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
    public class AdherentController : ControllerBase
    {
        private IAdherentsService service;

        public AdherentController(IAdherentsService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Adherent_DTO> GetAllAdherent()
        {
            return service.GetAllAdherents().Select(a => new Adherent_DTO()
            {
                id = a.id,
                nom = a.nom,
                prenom = a.prenom,
                societe = a.societe,
                email = a.email,
                adresse = a.adresse,
                dateadhesion = a.dateadhesion
            });
        }

        [HttpGet("{id}")]
        public Adherent_DTO GetIDAdherent([FromRoute] int id)
        {
            var a = service.GetAdherentsByID(id);
            return new Adherent_DTO()
            {
                id = a.id,
                nom = a.nom,
                prenom = a.prenom,
                societe = a.societe,
                email = a.email,
                adresse = a.adresse,
                dateadhesion = a.dateadhesion
            };
        }

        [HttpPut]
        public Adherent_DTO GetPutAdherent(Adherent_DTO a) 
        {
            var a_metier = service.Update(new Adherents(a.id, a.nom, a.prenom,a.societe,a.email,a.adresse,a.dateadhesion));
            a.id = a_metier.id;
            a.nom = a_metier.nom;
            a.prenom = a_metier.prenom;
            a.societe = a_metier.societe;
            a.email = a_metier.email;
            a.adresse = a_metier.adresse;
            a.dateadhesion = a_metier.dateadhesion;
            return a;
           
        }

        [HttpPost]
        public Adherent_DTO Insert(Adherent_DTO a)
        {
            var a_metier = service.Insert(new Adherents(a.id, a.nom, a.prenom, a.societe, a.email, a.adresse, a.dateadhesion));
            //Je récupère l'ID
            a.id = a_metier.id;
            //je renvoie l'objet DTO
            return a;
        }
    }
}
