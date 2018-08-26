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
    public class C0010GCP_EstadoRiesgoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE ESTADO DE RIESGO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EstadoRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0007_GCP_EstadoRiesgo_LIST()
        {
            try
            {
                var oBe = new BEGCP_EstadoRiesgo();
                var oBr = new BRGCP_EstadoRiesgo();

                var oList = oBr.GCPP0007_GCP_EstadoRiesgo_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
