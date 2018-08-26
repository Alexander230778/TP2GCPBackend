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
    public class BRGCP_Beneficio
    {
        private DAGCP_Beneficio oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_Beneficio()
        {
            oda = new DAGCP_Beneficio();
        }
        /// <summary>
        /// OBTENER LA LISTA DE BENEFICIOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_Beneficio> GCP0008_Beneficio_LIST(BEGCP_Beneficio oBe)
        {
            try
            {
                using (var odr = oda.GCP0008_Beneficio_LIST(oBe))
                {
                    var oList = new List<BEGCP_Beneficio>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_Beneficio>(odr);
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
