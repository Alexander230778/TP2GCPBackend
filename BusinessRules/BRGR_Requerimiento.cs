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
    public class BRGR_Requerimiento
    {
        private DAGR_Requerimiento oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGR_Requerimiento()
        {
            oda = new DAGR_Requerimiento();
        }
        /// <summary>
        /// OBTENER LA LISTA DE LOS REQUERIMIENTOS DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGR_Requerimiento> GCP0002_GR_Requerimiento_LIST(BEGR_Requerimiento oBe)
        {
            try
            {
                using (var odr = oda.GCP0002_GR_Requerimiento_LIST(oBe))
                {
                    var oList = new List<BEGR_Requerimiento>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGR_Requerimiento>(odr);
                    oList.ForEach(obj=> {
                        obj.key = obj.lir_Codigo;
                    });
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// MANTENIMIENTO DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        public void GCP0011_GR_Requerimiento(BEGR_Requerimiento oBe)
        {
            try
            {
                oda.GCP0011_GR_Requerimiento(oBe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// MANTENIMIENTO DE REQUERIMIENTOS EVALUADOS
        /// </summary>
        /// <param name="oBe"></param>
        public void GCPGR_Requerimiento(BEGR_Requerimiento oBe)
        {
            try
            {
                oda.GCPGR_Requerimiento(oBe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
