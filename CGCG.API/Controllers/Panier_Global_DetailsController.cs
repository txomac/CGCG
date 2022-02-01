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

        [HttpGet]
        public IEnumerable<Panier_Global_Details_DTO> GetAllPanier_Global_Details()
        {
            return service.GetAllPanierGlobalDetail().Select(p => new Panier_Global_Details_DTO()
            {
                id = p.id,
                quantite = p.quantite,
                id_references = p.id_references,
                id_panier_global = p.id_panier_global
            });
        }

        [HttpPost]
        public Panier_Global_Details_DTO Insert(Panier_Global_Details_DTO p)
        {
            var p_metier = service.Insert(new Panier_Global_Detail(p.id, p.quantite, p.id_references, p.id_panier_global));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }
    }
}
