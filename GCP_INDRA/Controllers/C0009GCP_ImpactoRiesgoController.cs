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
    public class C0009GCP_ImpactoRiesgoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE IMPACTO DE RIESGO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ImpactoRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0006_GCP_ImpactoRiesgo_LIST()
        {
            try
            {
                var oBe = new BEGCP_ImpactoRiesgo();
                var oBr = new BRGCP_ImpactoRiesgo();

                var oList = oBr.GCPP0006_GCP_ImpactoRiesgo_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
