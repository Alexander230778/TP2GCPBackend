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
    public class C0013GCP_ReunionController : ApiController
    {
        [HttpGet]
        [Route("Reunion/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0023_ReunionRFC_LIST(int id)
        {
            try
            {
                var oBr = new BRGCP_Reunion();
                var oBe = new BEGCP_Reunion();
                oBe.rfc_Codigo = id;

                var oList = oBr.GCP0023_ReunionRFC_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("Reunion")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0023_ReunionRFC(BEGCP_Reunion oBe)
        {
            try
            {
                var oBr = new BRGCP_Reunion();
                oBe.acci = 1;
                var _be = new BEGCP_Reunion();
                _be = oBr.GCP0023_ReunionRFC(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, _be);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
