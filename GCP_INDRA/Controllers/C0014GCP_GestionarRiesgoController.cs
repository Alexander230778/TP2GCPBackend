using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessEntities;
using BusinessRules;

namespace GCP_INDRA.Controllers
{
    public class C0014GCP_GestionarRiesgoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE RIESGOS
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GestionarRiesgo/{estado}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0023_ReunionRFC_LIST(int estado)
        {
            try
            {
                var oBr = new BRGCP_GestionarRiesgo();
                var oBe = new BEGCP_GestionarRiesgo();
                oBe.esr_Codigo = estado;

                var oList = oBr.GCP0025_GestionarRiesgo_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
