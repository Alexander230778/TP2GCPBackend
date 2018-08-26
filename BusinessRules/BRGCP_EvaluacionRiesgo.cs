using BusinessEntities;
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
    public class BRGCP_EvaluacionRiesgo
    {
        private DAGCP_EvaluacionRiesgo oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_EvaluacionRiesgo()
        {
            oda = new DAGCP_EvaluacionRiesgo();
        }

        public List<BEGCP_EvaluacionRiesgo> GCPP0015_GCP_EvaluacionRiesgo_LIST(BEGCP_EvaluacionRiesgo oBe)
        {
            try
            {
                using (var odr = oda.GCPP0015_GCP_EvaluacionRiesgo_LIST(oBe))
                {
                    var oList = new List<BEGCP_EvaluacionRiesgo>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_EvaluacionRiesgo>(odr);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void GCPP0014_GCP_EvaluacionRiesgo(BEGCP_EvaluacionRiesgo oBe)
        {
            try
            {
                oda.GCPP0014_GCP_EvaluacionRiesgo(oBe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
