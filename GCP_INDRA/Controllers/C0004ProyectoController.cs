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
    public class C0004ProyectoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE PROYECTOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("C0004G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GPP0005_GPP_Proyecto_LIST(BEGPP_Proyecto oBe)
        {
            try
            {
                var oBr = new BRGPP_Proyecto();
                oBe.acci = 1;

                var oList = oBr.GPP0005_GPP_Proyecto_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
