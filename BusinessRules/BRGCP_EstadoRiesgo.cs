using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessEntities;
using System.Collections;
using ResultSetMappers;

namespace BusinessRules
{
    public class BRGCP_EstadoRiesgo
    {
        private DAGCP_EstadoRiesgo oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_EstadoRiesgo()
        {
            oda = new DAGCP_EstadoRiesgo();
        }
        /// <summary>
        /// OBTENER LA LISTA DE ESTADO DE RIESGO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_EstadoRiesgo> GCPP0007_GCP_EstadoRiesgo_LIST()
        {
            try
            {
                using (var odr = oda.GCPP0007_GCP_EstadoRiesgo_LIST())
                {
                    var oList = new List<BEGCP_EstadoRiesgo>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_EstadoRiesgo>(odr);
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
