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
    public class C0013GCP_ReunionController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE REUNIONES DEL RFC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// INSERTAR DATOS DE REUNIONES DEL RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Reunion")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0023_ReunionRFC(BEGCP_Reunion oBe)
        {
            var oBeR = new BEResponseReunion();
            try
            {
                var oBr = new BRGCP_Reunion();
                oBe.acci = 1;
                var _be = new BEGCP_Reunion();
                oBr.GCP0023_ReunionRFC(oBe);
                var oList = oBr.GCP0023_ReunionRFC_LIST(oBe);
                oBeR.success = true;
                oList.ForEach(obj=> {
                    if (obj.reu_Codigo == oBe.reu_Codigo)
                    {
                        oBeR.data = obj;
                    }
                });
                return Request.CreateResponse(HttpStatusCode.OK, oBeR);
            }
            catch (Exception ex)
            {
                oBeR.success = false;
                oBeR.data = new BEGCP_Reunion();
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
