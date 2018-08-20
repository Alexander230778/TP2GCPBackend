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
    public class C0008GenericInfoController : ApiController
    {
        /// <summary>
        /// OBTENER LAS LISTAS DE:
        /// TIPOS DE REQUERIMIENTO
        /// NIVEL DE DOCUMENTACION
        /// PRIORIODAD DE REQUERIMIENTO
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("C0008G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0012_GCP18GCP19GCP20_LIST()
        {
            try
            {
                var oBe = new BEGenericInfoRequest();
                var oBr = new BRGenericInfoRequest();
                oBe.acci = 1;

                var oList = oBr.GCP0012_GCP18GCP19GCP20_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
