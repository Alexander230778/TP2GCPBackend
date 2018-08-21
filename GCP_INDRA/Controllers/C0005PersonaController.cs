using BusinessEntities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessRules;

namespace GCP_INDRA.Controllers
{
    public class C0005PersonaController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE INTERESADOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("C0005G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0007_GCP_Persona_LIST_0001()
        {
            try
            {
                var oBr = new BRGCP_Persona();
                var oBe = new BEGCP_Persona();
                oBe.acci = 1;

                var oList = oBr.GCP0007_GCP_Persona_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE RESPONSABLES
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("C0005G0002")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0007_GCP_Persona_LIST_0002()
        {
            try
            {
                var oBr = new BRGCP_Persona();
                var oBe = new BEGCP_Persona();
                oBe.acci = 2;

                var oList = oBr.GCP0007_GCP_Persona_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE LÍDERES TÉCNICOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LiderTecnico")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0016_LiderTecnico_LIST()
        {
            try
            {
                var oBr = new BRGCP_Persona();

                var oList = oBr.GCPP0016_LiderTecnico_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
