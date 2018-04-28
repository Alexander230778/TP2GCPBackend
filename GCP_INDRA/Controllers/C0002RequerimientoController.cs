using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessRules;
using BusinessEntities;

namespace GCP_INDRA.Controllers
{
    public class C0002RequerimientoController : ApiController
    {
        [HttpGet]
        [Route("C0002G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage P0004SHPR_TIPO_USUA_LIST(BEGR_Requerimiento oBe)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                oBe = new BEGR_Requerimiento();
                oBe.acci = 1;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
