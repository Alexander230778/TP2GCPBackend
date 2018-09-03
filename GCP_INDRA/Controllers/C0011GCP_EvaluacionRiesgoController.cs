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
    public class C0011GCP_EvaluacionRiesgoController : ApiController
    {
        /// <summary>
        /// OBTENER LA LISTA DE PRIORIDAD DE RIESGO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PrioridadRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0017_PrioridadRiesgo_LIST()
        {
            try
            {
                var oBe = new BEGCP_PrioridadRiesgo();
                var oBr = new BRGCP_PrioridadRiesgo();

                var oList = oBr.GCPP0017_PrioridadRiesgo_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE ESTADO DE RIESGO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EstadoRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0007_GCP_EstadoRiesgo_LIST()
        {
            try
            {
                var oBe = new BEGCP_EstadoRiesgo();
                var oBr = new BRGCP_EstadoRiesgo();

                var oList = oBr.GCPP0007_GCP_EstadoRiesgo_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE IMPACTO DE RIESGO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ImpactoRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0006_GCP_ImpactoRiesgo_LIST()
        {
            try
            {
                var oBe = new BEGCP_ImpactoRiesgo();
                var oBr = new BRGCP_ImpactoRiesgo();

                var oList = oBr.GCPP0006_GCP_ImpactoRiesgo_LIST();

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE RIESGO DEL RFC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EvaluacionRiesgo/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCPP0015_GCP_EvaluacionRiesgo_LIST(int id)
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
        /// <summary>
        /// INSERTAR DATOS DE RIESGO DEL RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EvaluacionRiesgo")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCPP0014_GCP_EvaluacionRiesgo(BEGCP_EvaluacionRiesgo oBe)
        {
            try
            {
                var oBr = new BRGCP_EvaluacionRiesgo();
                oBe.acci = 1;
                oBr.GCPP0014_GCP_EvaluacionRiesgo(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oBe);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// ACTUALIZAR DATOS DE RIESGO DEL RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EvaluacionRiesgoU")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCPP0014_GCP_EvaluacionRiesgoU(BEGCP_EvaluacionRiesgo oBe)
        {
            try
            {
                var oBr = new BRGCP_EvaluacionRiesgo();
                oBe.acci = 2;
                oBr.GCPP0014_GCP_EvaluacionRiesgo(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oBe);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
