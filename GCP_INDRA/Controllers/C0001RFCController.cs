﻿using BusinessEntities;
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
        /// <summary>
        /// OBTENER LA LISTA DE RFCS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("C0001G0001")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GCP0001_RFC_LIST_0001(BEGCP01_RFC oBe)
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
        /// <summary>
        /// OBTENER UNA RFC CON LOS REQUISITOS DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("C0001G0002")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0001_RFC_LIST_0002(BEGCP01_RFC oBe)
        {
            try
            {
                var oBr = new BRGCP01_RFC();
                var oBeR = new BEGR_Requerimiento();
                var oBrR = new BRGR_Requerimiento();
                oBe.acci = 2;
                oBeR.acci = 1;
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
        /// <summary>
        /// INSERTAR DATOS DE RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("C0001S0003")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0006_RFC_0001(BEGCP01_RFC oBe)
        {
            try
            {
                var oBr = new BRGCP01_RFC();
                oBe.acci = 1;
                oBr.GCP0006_RFC(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// ACTUALIZAR LA RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("C0001S0004")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage GCP0006_RFC_0002(BEGCP01_RFC oBe)
        {
            try
            {
                var oBr = new BRGCP01_RFC();
                oBe.acci = 2;
                oBr.GCP0006_RFC(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}