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
    public class Panier_Global_DetailsController : ControllerBase
    {
        private IPanier_Global_DetailService service;

        public Panier_Global_DetailsController(IPanier_Global_DetailService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Panier_Global_Details_DTO> GetAllPanierGlobalDetails()
        {
            return service.GetAllPanierGlobalDetail().Select(p => new Panier_Global_Details_DTO()
            {
                id = p.id,
                quantite = p.quantite,
                id_references = p.id_references,
                id_panier_global = p.id_panier_global
            });
        }

        [HttpPut]
        public Panier_Global_Details_DTO GetPutPanierGlobalDetails(Panier_Global_Details_DTO p)
        {
            var p_metier = service.Update(new Panier_Global_Detail(p.id, p.quantite, p.id_references, p.id_panier_global));
            p.id = p_metier.id;
            p.quantite = p_metier.quantite;
            p.id_references = p_metier.id_references;
            p.id_panier_global = p_metier.id_panier_global;
            return p;
        }

        [HttpPost]
        public Panier_Global_Details_DTO Insert(Panier_Global_Details_DTO p)
        {
            var p_metier = service.Insert(new Panier_Global_Detail(p.quantite, p.id_references , p.id_panier_global));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }

        [HttpGet("{id}")]
        public Panier_Global_Details_DTO GetPanierGlobalDetailByID([FromRoute] int id)
        {
            var p = service.GetPanierGlobalDetailByID(id);
            return new Panier_Global_Details_DTO()
            {
                id = p.id,
                quantite = p.quantite,
                id_panier_global = p.id_panier_global,
                id_references = p.id_references
            };
        }
    }
}
