﻿using System;
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
        [Route("Requerimiento/update")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0011_GR_Requerimiento_0002(requerimentRequest oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBeSend = new BEGR_Requerimiento();
                oBeSend.acci = 2;

                oBeSend.lir_Codigo = oBe.lir_Codigo;
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
        [HttpPost]
        [Route("RequerimientoPLanificar/update")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCPGR_Requerimiento_planificar(BEGR_Requerimiento oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();

                oBr.GCPGR_Requerimiento_planificar(oBe);

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
        /// <summary>
        /// OBTENER LISTA DE REQUERIMIENTOS PENDIENTES DE EVALUACION POR TECNICO
        /// </summary>
        /// <param name="rfc_Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RequerimientoTecnicoPendiente/{lit_Codigo}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0005(int lit_Codigo)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBe = new BEGR_Requerimiento();
                oBe.lit_Codigo = lit_Codigo;
                oBe.acci = 5;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LISTA DE REQUERIMIENTOS POR TECNICO
        /// </summary>
        /// <param name="rfc_Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RequerimientoTecnico/{lit_Codigo}")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0006(int lit_Codigo)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBe = new BEGR_Requerimiento();
                oBe.lit_Codigo = lit_Codigo;
                oBe.acci = 6;

                var oList = oBr.GCP0002_GR_Requerimiento_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// ACTUALIZAR DATOS DE REQUERIMIENTO TECNICO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RequerimientoTecnico/update")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0011_GR_Requerimiento_0003(requerimentRequest oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBeSend = new BEGR_Requerimiento();
                oBeSend.acci = 3;

                oBeSend.lir_Codigo = oBe.lir_Codigo;
                oBeSend.lit_Codigo = oBe.lit_Codigo;

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
        /// ACTUALIZAR DATOS DE REQUERIMIENTO TECNICO EVALUAR
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RequerimientoTecnicoEvaluar/update")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0011_GR_Requerimiento_0004(requerimentRequest oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();
                var oBeSend = new BEGR_Requerimiento();
                oBeSend.acci = 4;

                oBeSend.lir_Codigo = oBe.lir_Codigo;
                oBeSend.est_Codigo = oBe.est_Codigo;
                oBeSend.lir_TiempoDesarrollo = oBe.lir_TiempoDesarrollo;
                oBeSend.RequerimientoRecurso = oBe.RequerimientoRecurso;

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
        [HttpPost]
        [Route("Requerimiento/Eliminar")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCPGR_Requerimiento_0002(BEGR_Requerimiento oBe)
        {
            var oBeResponse = new requirementResponse();
            try
            {
                var oBr = new BRGR_Requerimiento();
                oBe.acci = 2;
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
