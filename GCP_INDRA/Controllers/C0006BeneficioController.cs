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
    public class C0006BeneficioController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE BENEFICIOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("C0006G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0008_Beneficio_LIST_0001()
        {
            try
            {
                var oBr = new BRGCP_Beneficio();
                var oBe = new BEGCP_Beneficio();
                oBe.acci = 1;

                var oList = oBr.GCP0008_Beneficio_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
