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
    public class BRGCP_TipoRecurso
    {
        private DAGCP_TipoRecurso oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_TipoRecurso()
        {
            oda = new DAGCP_TipoRecurso();
        }
        /// <summary>
        /// OBTENER LA LISTA DE RECURSOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_TipoRecurso> GCP0010_TipoRecurso_LIST(BEGCP_TipoRecurso oBe)
        {
            try
            {
                using (var odr = oda.GCP0010_TipoRecurso_LIST(oBe))
                {
                    var oList = new List<BEGCP_TipoRecurso>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_TipoRecurso>(odr);
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
