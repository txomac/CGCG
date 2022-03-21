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
   
        public class Fournisseur_ReferenceController : ControllerBase
        {
            private IFournisseurs_ReferencesService service;

            public Fournisseur_ReferenceController(IFournisseurs_ReferencesService srv)
            {
                service = srv;
            }

            [HttpGet("AllReferenceFournisseur")]
            public IEnumerable<Fournisseur_Reference_DTO> GetAllReference()
            {
                return service.GetAllFournisseursReferences().Select(fr => new Fournisseur_Reference_DTO()
                {
                    id_fournisseurs = fr.id_fournisseurs,
                    id_references = fr.id_references
                    
                });
            }

        [HttpGet("GetFournisseurReferenceByFournisseur")]
        public IEnumerable<Fournisseur_Reference_DTO> GetFournisseurReferenceByFournisseur(int ID)
        {
            return service.GetByIDFournisseur(ID).Select(fr => new Fournisseur_Reference_DTO()
            {
                id_fournisseurs = fr.id_fournisseurs,
                id_references = fr.id_references
            });
        }
        [HttpPost]
        public Fournisseur_Reference_DTO Insert(Fournisseur_Reference_DTO fr)
        {
            var fr_metier = service.Insert(new Fournisseurs_References (fr.id_fournisseurs, fr.id_references));
            //je renvoie l'objet DTO
            return fr;
        }
    }
}
