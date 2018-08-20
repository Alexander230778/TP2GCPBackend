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
    public class C0011GCP_EvaluacionRiesgoController : ApiController
    {
        [HttpPost]
        [Route("EvaluacionRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCPP0007_GCP_EstadoRiesgo_LIST(BEGCP_EvaluacionRiesgo oBe)
        {
            try
            {
                var oBr = new BRGCP_EvaluacionRiesgo();

                oBr.GCPP0014_GCP_EvaluacionRiesgo(oBe);

                var oList = oBr.GCPP0015_GCP_EvaluacionRiesgo_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("EvaluacionRiesgo/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0007_GCP_EstadoRiesgo_LIST(int id)
        {
            try
            {
                var oBr = new BRGCP_EvaluacionRiesgo();
                var oBe = new BEGCP_EvaluacionRiesgo();
                oBe.rfc_Codigo = id;

                var oList = oBr.GCPP0015_GCP_EvaluacionRiesgo_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
