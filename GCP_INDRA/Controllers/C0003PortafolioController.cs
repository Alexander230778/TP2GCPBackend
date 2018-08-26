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
    public class C0003PortafolioController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE PORTAFOLIOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("C0003G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GPP0004_GPP_Portafolio_LIST()
        {
            try
            {
                var oBr = new BRGPP_Portafolio();
                var oBe = new BEGPP_Portafolio();
                oBe.acci = 1;

                var oList = oBr.GPP0004_GPP_Portafolio_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
