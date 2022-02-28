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

            [HttpGet("AllReference")]
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

        [HttpGet("{idReference}")]
        public Reference_DTO GetIDReference([FromRoute] int idReference)
        {
            var r = service.GetReferencesByID(idReference);
            return new Reference_DTO()
            {
                id = r.id,
                reference = r.reference,
                libelle = r.libelle,
                marque = r.marque,
                desactive = r.desactive,
                id_fournisseurs = r.id_fournisseurs,
            };
        }
        [HttpPut]
        public Reference_DTO GetPutReference(Reference_DTO r)
        {
            var r_metier = service.Update(new References(r.id, r.reference, r.libelle, r.marque, r.desactive, r.id_fournisseurs));
            r.id = r_metier.id;
            r.reference = r_metier.reference;
            r.libelle = r_metier.libelle;
            r.marque = r_metier.marque;
            r.desactive = r_metier.desactive;
            r.id_fournisseurs = r_metier.id_fournisseurs;
            return r;

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
