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

        [HttpGet]
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
