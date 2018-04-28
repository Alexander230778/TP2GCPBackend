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
    public class C0001RFCController : ApiController
    {
        [HttpGet]
        [Route("C0001G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage P0004SHPR_TIPO_USUA_LIST_0001(BEGCP01_RFC oBe)
        {
            try
            {
                var oBr = new BRGCP01_RFC();
                oBe = new BEGCP01_RFC();
                oBe.acci = 1;

                var oList = oBr.GCP0001_RFC_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("C0001G0002")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage P0004SHPR_TIPO_USUA_LIST_0002(BEGCP01_RFC oBe)
        {
            try
            {
                var oBr = new BRGCP01_RFC();
                var oBeR = new BEGR_Requerimiento();
                var oBrR = new BRGR_Requerimiento();
                oBe.acci = 2;
                oBeR.acci=1;
                var oList = oBr.GCP0001_RFC_LIST(oBe);
                oBeR.lir_Codigo = oList[0].pro_Codigo;
                var oListR = oBrR.GCP0002_GR_Requerimiento_LIST(oBeR);

                var oBeReturn = oList[0];
                oBeReturn.LST_REQU = oListR;

                return Request.CreateResponse(HttpStatusCode.OK, oBeReturn);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
