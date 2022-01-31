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

        [HttpGet]
        public IEnumerable<Panier_AdherentDetail_DTO> GetAllPanierAdherent()
        {
            return service.GetAllPanierAdherentsDetails().Select(p => new Panier_AdherentDetail_DTO()
            {
                id = p.id,
                id_panier_adherents = p.id_panier_adherents,
                id_references = p.id_references
            });
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
