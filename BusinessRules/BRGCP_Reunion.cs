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
    public class BRGCP_Reunion
    {
        private DAGCP_Reunion oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_Reunion()
        {
            oda = new DAGCP_Reunion();
        }
        /// <summary>
        /// OBTENER LA LISTA DE REQUERIMIENTOS DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_Reunion> GCP0023_ReunionRFC_LIST(BEGCP_Reunion oBe)
        {
            try
            {
                var oList = new List<BEGCP_Reunion>();
                
                return (oList);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// MANTENIMIENTO DE EVALUACIÓN DE RIESGO
        /// </summary>
        /// <param name="oBe"></param>
        public BEGCP_Reunion GCP0023_ReunionRFC(BEGCP_Reunion oBe)
        {
            try
            {
                return oda.GCP0023_ReunionRFC(oBe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
