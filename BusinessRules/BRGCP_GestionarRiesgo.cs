using System;
using System.Collections;
using System.Collections.Generic;
using ResultSetMappers;
using BusinessEntities;
using DataAccess;

namespace BusinessRules
{
    public class BRGCP_GestionarRiesgo
    {
        private DAGCP_GestionarRiesgo oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_GestionarRiesgo()
        {
            oda = new DAGCP_GestionarRiesgo();
        }
        /// <summary>
        /// OBTENER LA LISTA DE RIESGOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_GestionarRiesgo> GCP0025_GestionarRiesgo_LIST(BEGCP_GestionarRiesgo oBe)
        {
            try
            {
                using (var odr = oda.GCP0025_GestionarRiesgo_LIST(oBe))
                {
                    var oList = new List<BEGCP_GestionarRiesgo>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_GestionarRiesgo>(odr);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
