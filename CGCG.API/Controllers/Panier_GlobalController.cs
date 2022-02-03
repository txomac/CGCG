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
    public class Panier_GlobalController : ControllerBase
    {
        private IPanier_GlobalService service;

        public Panier_GlobalController(IPanier_GlobalService srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<Panier_Global_DTO> GetAllPanierGlobal()
        {
            return service.GetAllPanierGlobal().Select(p => new Panier_Global_DTO()
            {
                id = p.id,
                semaine = p.semaine
            });
        }

        [HttpGet("{id}")]
        public Panier_Global_DTO GetIDPanierGlobal([FromRoute] int id)
        {
            var p = service.GetPanierGlobalByID(id);
            return new Panier_Global_DTO()
            {
                id = p.id,
                semaine = p.semaine
            };
        }

        [HttpPut]
        public Panier_Global_DTO GetPutPanierGlobal(Panier_Global_DTO p)
        {
            var p_metier = service.Update(new Panier_Global(p.id, p.semaine);
            p.id = p_metier.id;
            p.semaine = p_metier.semaine;
            return p;
        }

        [HttpPost]
        public Panier_Global_DTO Insert(Panier_Global_DTO p)
        {
            var p_metier = service.Insert(new Panier_Global(p.id, p.semaine));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }
    }
}
