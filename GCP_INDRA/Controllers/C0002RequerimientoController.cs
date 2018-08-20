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
        [Route("C0002S0002")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0011_GR_Requerimiento_0001(BEGR_Requerimiento oBe)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                oBe.acci = 1;
                oBr.GCP0011_GR_Requerimiento(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// ACTUALIZAR DATOS DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("C0002S0003")]
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
        [HttpPost]
        [Route("C0002G0004")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0002_GR_Requerimiento_LIST_0002(BEGR_Requerimiento oBe)
        {
            try
            {
                var oBr = new BRGR_Requerimiento();
                oBe.acci = 2;

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
