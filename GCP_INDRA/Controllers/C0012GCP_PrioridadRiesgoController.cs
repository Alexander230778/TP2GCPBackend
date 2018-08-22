using BusinessEntities;
using BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GCP_INDRA.Controllers
{
    public class C0012GCP_PrioridadRiesgoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE PRIORIDAD DE RIESGO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PrioridadRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0017_PrioridadRiesgo_LIST()
        {
            try
            {
                var oBe = new BEGCP_PrioridadRiesgo();
                var oBr = new BRGCP_PrioridadRiesgo();

                var oList = oBr.GCPP0017_PrioridadRiesgo_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
