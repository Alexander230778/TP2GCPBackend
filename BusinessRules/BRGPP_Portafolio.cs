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
    public class BRGPP_Portafolio
    {
        private DAGPP_Portafolio oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGPP_Portafolio()
        {
            oda = new DAGPP_Portafolio();
        }
        /// <summary>
        /// OBTENER LA LISTA DE PORTAFOLIOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGPP_Portafolio> GPP0004_GPP_Portafolio_LIST(BEGPP_Portafolio oBe)
        {
            using (var odr = oda.GPP0004_GPP_Portafolio_LIST(oBe))
            {
                var oList = new List<BEGPP_Portafolio>();
                var iLst = oList;
                ((IList)iLst).LoadFromReader<BEGPP_Portafolio>(odr);
                return (oList);
            }
        }
    }
}
