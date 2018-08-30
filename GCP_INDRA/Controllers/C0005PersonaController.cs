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
        [Route("Interesado")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0007_GCP_Persona_LIST_0001()
        {
            //C0005G0001 - Interesado
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
        [Route("Responsable")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0007_GCP_Persona_LIST_0002()
        {
            //C0005G0002 - Responsable
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
        /// OBTENER LA LISTA DE LIDERES TECNICOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LiderTecnico")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0007_GCP_Persona_LIST_0003()
        {
            try
            {
                var oBr = new BRGCP_Persona();
                var oBe = new BEGCP_Persona();
                oBe.acci = 3;

                var oList = oBr.GCP0007_GCP_Persona_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE PARTICIPANTES
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Participante")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0007_GCP_Persona_LIST_0004()
        {
            try
            {
                var oBr = new BRGCP_Persona();
                var oBe = new BEGCP_Persona();
                oBe.acci = 4;

                var oList = oBr.GCP0007_GCP_Persona_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
