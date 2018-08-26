using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessEntities;
using BusinessRules;

namespace GCP_INDRA.Controllers
{
    public class C0007TipoRecursoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE RECURSOS
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("C0007G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GPP0005_GPP_Proyecto_LIST()
        {
            try
            {
                var oBe = new BEGCP_TipoRecurso();
                var oBr = new BRGCP_TipoRecurso();
                oBe.acci = 1;

                var oList = oBr.GCP0010_TipoRecurso_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
