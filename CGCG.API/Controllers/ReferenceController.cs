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
   
        public class ReferenceController : ControllerBase
        {
            private IReferencesService service;

            public ReferenceController(IReferencesService srv)
            {
                service = srv;
            }

            [HttpGet]
            public IEnumerable<Reference_DTO> GetAllReference()
            {
                return service.GetAllReferences().Select(r => new Reference_DTO()
                {
                    id = r.id,
                    reference = r.reference,
                    libelle = r.libelle,
                    marque = r.marque,
                    desactive = r.desactive,
                    id_fournisseurs = r.id_fournisseurs,
                });
            }

            [HttpPost]
        public Reference_DTO Insert(Reference_DTO r)
        {
            var r_metier = service.Insert(new References(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs));
            //Je récupère l'ID
            r.id = r_metier.id;
            //je renvoie l'objet DT
            return r;
        }
    }
}
