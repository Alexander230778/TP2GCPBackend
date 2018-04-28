﻿using BusinessEntities;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;

namespace BusinessRules
{
    public class BRGR_Requerimiento
    {
        private DAGR_Requerimiento oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGR_Requerimiento()
        {
            oda = new DAGR_Requerimiento();
        }
        /// <summary>
        /// OBTENER LA LISTA DE LAS RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGR_Requerimiento> GCP0002_GR_Requerimiento_LIST(BEGR_Requerimiento oBe)
        {
            using (var odr = oda.GCP0002_GR_Requerimiento_LIST(oBe))
            {
                var oList = new List<BEGR_Requerimiento>();
                var iLst = oList;
                ((IList)iLst).LoadFromReader<BEGR_Requerimiento>(odr);
                return (oList);
            }
        }
    }
}