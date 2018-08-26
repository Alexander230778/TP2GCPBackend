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
    public class BRGCP_PrioridadRiesgo
    {
        private DAGCP_PrioridadRiesgo oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_PrioridadRiesgo()
        {
            oda = new DAGCP_PrioridadRiesgo();
        }
        /// <summary>
        /// OBTENER LA LISTA DE PRIODIDAD DE RIESGO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_PrioridadRiesgo> GCPP0017_PrioridadRiesgo_LIST()
        {
            try
            {
                using (var odr = oda.GCPP0017_PrioridadRiesgo_LIST())
                {
                    var oList = new List<BEGCP_PrioridadRiesgo>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_PrioridadRiesgo>(odr);
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
