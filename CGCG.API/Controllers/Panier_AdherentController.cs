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
    public class Panier_AdherentController : ControllerBase
    {
        private IPanier_AdherentsService service;

        public Panier_AdherentController(IPanier_AdherentsService srv)
        {
            service = srv;
        }

        [HttpGet("AllPanierAdherent")]
        public IEnumerable<Panier_adherent_DTO> GetAllPanierAdherent()
        {
            return service.GetAllPanierAdherents().Select(p => new Panier_adherent_DTO()
            {
                id = p.id,
                id_adherents = p.id_adherents,
                id_panier_global = p.id_panier_global,
                semaine = p.semaine
            });
        }

        [HttpGet("{idPanierAdherent}")]
        public Panier_adherent_DTO GetIDPanierAdherents([FromRoute] int idPanierAdherent)
        {
            var p = service.GetPanierAdherentsByID(idPanierAdherent);
            return new Panier_adherent_DTO()
            {
                id = p.id,
                id_adherents = p.id_adherents,
                id_panier_global = p.id_panier_global,
                semaine = p.semaine
            };
        }

        [HttpPut]
        public Panier_adherent_DTO GetPutPanierGlobal(Panier_adherent_DTO p)
        {
            var p_metier = service.Update(new Panier_Adherents(p.id, p.id_adherents, p.id_panier_global, p.semaine));
            p.id = p_metier.id;
            p.id_adherents = p_metier.id_adherents;
            p.id_panier_global = p_metier.id_panier_global;
            p.semaine = p_metier.semaine;
            return p;
        }

        [HttpPost]
        public Panier_adherent_DTO Insert(Panier_adherent_DTO p)
        {
            var p_metier = service.Insert(new Panier_Adherents(p.id, p.id_adherents, p.id_panier_global, p.semaine));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }
    }
}
