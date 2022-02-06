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
    public class Panier_FournisseursController : ControllerBase
    {
        private IPanier_FournisseursService service;

        public Panier_FournisseursController(IPanier_FournisseursService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Panier_Fournisseurs_DTO> GetAllPanier_Fournisseurs()
        {
            return service.GetAllPanier_Fournisseurs().Select(p => new Panier_Fournisseurs_DTO()
            {
                id = p.id,
                puht = p.puht,
                id_fournisseur = p.id_fournisseur,
                id_panier_global_detail = p.id_panier_global_detail
            });
        }

        [HttpGet("{id}")]
        public Panier_Fournisseurs_DTO GetIDPanierFournisseur([FromRoute] int id)
        {
            var p = service.GetPanierFournisseursByID(id);
            return new Panier_Fournisseurs_DTO()
            {
                id = p.id,
                puht = p.puht,
                id_fournisseur = p.id_fournisseur,
                id_panier_global_detail = p.id_panier_global_detail
            };
        }

        [HttpPut]
        public Panier_Fournisseurs_DTO GetPutPanierGlobal(Panier_Fournisseurs_DTO p)
        {
            var p_metier = service.Update(new Panier_Fournisseurs(p.id, p.puht,p.id_fournisseur,p.id_panier_global_detail));
            p.id = p_metier.id;
            p.puht = p_metier.puht;
            p.id_fournisseur = p_metier.id_fournisseur;
            p.id_panier_global_detail = p_metier.id_panier_global_detail;
            return p;
        }

        [HttpPost]
        public Panier_Fournisseurs_DTO Insert(Panier_Fournisseurs_DTO p)
        {
            var p_metier = service.Insert(new Panier_Fournisseurs(p.id, p.puht, p.id_fournisseur, p.id_panier_global_detail));
            //Je récupère l'ID
            p.id = p_metier.id;
            //je renvoie l'objet DTO
            return p;
        }
    }
}
