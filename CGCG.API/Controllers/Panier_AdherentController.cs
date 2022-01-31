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

        [HttpGet]
        public IEnumerable<Panier_adherent_DTO> GetAllPanierAdherent()
        {
            return service.GetAllPanierAdherents().Select(p => new Panier_adherent_DTO()
            {
                id = p.id,
                id_adherents = p.id_adherents,
                id_panier_global = p.id_panier_global
            });
        }

        [HttpPost]
        public Panier_adherent_DTO Insert(Panier_adherent_DTO p)
        {
            var p_metier = service.Insert(new Panier_Adherents(p.id, p.id_adherents, p.id_panier_global));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }
    }
}
