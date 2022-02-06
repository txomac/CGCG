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
    public class Panier_Adherent_DetailController : ControllerBase
    {
        private IPanier_Adherents_DetailsService service;

        public Panier_Adherent_DetailController(IPanier_Adherents_DetailsService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Panier_AdherentDetail_DTO> GetAllPanierAdherentDetail()
        {
            return service.GetAllPanierAdherentsDetails().Select(p => new Panier_AdherentDetail_DTO()
            {
                id = p.id,
                quantite = p.quantite,
                id_panier_adherents = p.id_panier_adherents,
                id_references = p.id_references
            });
        }

        [HttpGet("{id}")]
        public Panier_AdherentDetail_DTO GetIDPanierAdherentDetail([FromRoute] int id)
        {
            var p = service.GetPanierAdherentsDetailsByID(id);
            return new Panier_AdherentDetail_DTO()
            {
                id = p.id,
                quantite = p.quantite,
                id_panier_adherents = p.quantite,
                id_references = p.id_references
            };
        }

        [HttpPut]
        public Panier_AdherentDetail_DTO GetPutPanierAdherentDetail(Panier_AdherentDetail_DTO p)
        {
            var p_metier = service.Update(new Panier_Adherents_Details(p.id, p.quantite, p.id_panier_adherents, p.id_references));
            p.id = p_metier.id;
            p.quantite = p_metier.quantite;
            p.id_panier_adherents = p_metier.id_panier_adherents;
            p.id_references = p_metier.id_references;
            return p;
        }

        [HttpPost]
        public Panier_AdherentDetail_DTO Insert(Panier_AdherentDetail_DTO p)
        {
            var p_metier = service.Insert(new Panier_Adherents_Details(p.id, p.id_panier_adherents, p.id_references));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }
    }
}
