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
    public class BRGPP_Proyecto
    {
        private DAGPP_Proyecto oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGPP_Proyecto()
        {
            oda = new DAGPP_Proyecto();
        }
        /// <summary>
        /// OBTENER LA LISTA DE LOS PROYECTOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGPP_Proyecto> GPP0005_GPP_Proyecto_LIST(BEGPP_Proyecto oBe)
        {
            try
            {
                using (var odr = oda.GPP0005_GPP_Proyecto_LIST(oBe))
                {
                    var oList = new List<BEGPP_Proyecto>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGPP_Proyecto>(odr);
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
