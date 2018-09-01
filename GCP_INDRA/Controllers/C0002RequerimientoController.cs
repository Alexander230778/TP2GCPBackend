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
        /// <summary>
        /// OBTENER LA LISTA DE REQUERIMIENTOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("C0002G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0001()
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBe = new BEGR_Requerimiento();
                oBe.acci = 1;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// INSERTAR DATOS DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Requerimiento")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0011_GR_Requerimiento_0001(requerimentRequest oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBeSend = new BEGR_Requerimiento();
                oBeSend.acci = 1;

                oBeSend.lir_Nombre = oBe.title;
                oBeSend.lir_FechaEntrega = oBe.delivery;
                oBeSend.lir_Resumen = oBe.description;
                oBeSend.lir_Prioridad = oBe.prioridad;
                oBeSend.lir_EsFuncional = oBe.isFunctional;
                oBeSend.lir_RequiereDocumentar = oBe.requireDocumentation;
                oBeSend.rfc_Codigo = oBe.rfc_Codigo;

                oBr.GCP0011_GR_Requerimiento(oBeSend);

                oBeSend.key = oBeSend.lir_Codigo;

                oBeResponse.success = true;
                oBeResponse.data = oBeSend;
                oBeResponse.message = "";
                return Request.CreateResponse(HttpStatusCode.OK, oBeResponse);
            }
            catch (Exception ex)
            {
                oBeResponse.success = false;
                oBeResponse.message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.OK, oBeResponse);
            }
        }
        /// <summary>
        /// ACTUALIZAR DATOS DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Requerimiento/Update")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0011_GR_Requerimiento_0002(BEGR_Requerimiento oBe)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                oBe.acci = 2;
                oBr.GCP0011_GR_Requerimiento(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE REQUERIMIENTOS MODIFICADOS Y AGREGADOS EN UNA RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Rfc/{idRfc}/nuevosRequerimientos")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0002(int idRfc)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBe = new BEGR_Requerimiento();
                oBe.rfc_Codigo = idRfc;
                oBe.acci = 2;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// LISTA DE REQUERIMIENTOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EvaluarRequerimientos/{rfc_Codigo}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0003(int rfc_Codigo)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBe = new BEGR_Requerimiento();
                oBe.rfc_Codigo = rfc_Codigo;
                oBe.acci = 3;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE REQUERIMIENTOS
        /// </summary>
        /// <param name="rfc_Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PlanificarRequerimientos/{rfc_Codigo}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0004(int rfc_Codigo)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBe = new BEGR_Requerimiento();
                oBe.rfc_Codigo = rfc_Codigo;
                oBe.acci = 4;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// INSERTAR DATOS DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RequerimientoPlanificado")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCPGR_Requerimiento(BEGR_Requerimiento oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();

                oBr.GCPGR_Requerimiento(oBe);

                oBeResponse.success = true;
                oBeResponse.message = "";
                return Request.CreateResponse(HttpStatusCode.OK, oBeResponse);
            }
            catch (Exception ex)
            {
                oBeResponse.success = false;
                oBeResponse.message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.OK, oBeResponse);
            }
        }
    }
}
