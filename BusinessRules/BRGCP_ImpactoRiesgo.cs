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
    public class BRGCP_ImpactoRiesgo
    {
        private DAGCP_ImpactoRiesgo oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_ImpactoRiesgo()
        {
            oda = new DAGCP_ImpactoRiesgo();
        }
        /// <summary>
        /// OBTENER LA LISTA DE IMPACTO DE RIESGO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_ImpactoRiesgo> GCPP0006_GCP_ImpactoRiesgo_LIST()
        {
            try
            {
                using (var odr = oda.GCPP0006_GCP_ImpactoRiesgo_LIST())
                {
                    var oList = new List<BEGCP_ImpactoRiesgo>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_ImpactoRiesgo>(odr);
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
