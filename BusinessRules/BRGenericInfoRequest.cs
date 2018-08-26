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
    public class BRGenericInfoRequest
    {
        private DAGenericInfoRequest oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGenericInfoRequest()
        {
            oda = new DAGenericInfoRequest();
        }
        /// <summary>
        /// OBTENER LAS LISTAS DE:
        /// TIPOS DE REQUERIMIENTO
        /// NIVEL DE DOCUMENTACION
        /// PRIORIODAD DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public BEGenericInfoRequest GCP0012_GCP18GCP19GCP20_LIST(BEGenericInfoRequest oBe)
        {
            try
            {
                using (var odr = oda.GCP0012_GCP18GCP19GCP20_LIST(oBe))
                {
                    var oListNivel = new List<BEGCP18_NivelDocumento>();
                    var oListTipo = new List<BEGCP19_TipoRequerimiento>();
                    var oListPrio = new List<BEGCP20_PriodidadRequerimiento>();
                    var iLstNivel = oListNivel;

                    ((IList)iLstNivel).LoadFromReader<BEGCP18_NivelDocumento>(odr);

                    if (odr.NextResult())
                    {
                        var iLstTipo = oListTipo;
                        ((IList)iLstTipo).LoadFromReader<BEGCP19_TipoRequerimiento>(odr);
                    }

                    if (odr.NextResult())
                    {
                        var iLstPrio = oListPrio;
                        ((IList)iLstPrio).LoadFromReader<BEGCP20_PriodidadRequerimiento>(odr);
                    }

                    oBe.LST_NIVE = oListNivel;
                    oBe.LST_TIPO = oListTipo;
                    oBe.LST_PRIO = oListPrio;

                    return (oBe);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
