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
    public class BRGCP_Persona
    {
        private DAGCP_Persona oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP_Persona()
        {
            oda = new DAGCP_Persona();
        }
        /// <summary>
        /// OBTENER LA LISTA DE PERSONAS
        /// INTERESADOS Y RESPONSABLES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_Persona> GCP0007_GCP_Persona_LIST(BEGCP_Persona oBe)
        {
            try
            {
                using (var odr = oda.GCP0007_GCP_Persona_LIST(oBe))
                {
                    var oList = new List<BEGCP_Persona>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_Persona>(odr);
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE LIDERES TÉCNICOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_Persona> GCPP0016_LiderTecnico_LIST()
        {
            try
            {
                using (var odr = oda.GCPP0016_LiderTecnico_LIST())
                {
                    var oList = new List<BEGCP_Persona>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_Persona>(odr);
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
