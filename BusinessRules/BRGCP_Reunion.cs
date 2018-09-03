using System;
using System.Collections;
using System.Collections.Generic;
using ResultSetMappers;
using BusinessEntities;
using DataAccess;

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
        /// OBTENER LA LISTA DE REUNIONES DEL RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_Reunion> GCP0023_ReunionRFC_LIST(BEGCP_Reunion oBe)
        {
            try
            {
                using (var odr = oda.GCP0023_ReunionRFC_LIST(oBe))
                {
                    var oList = new List<BEGCP_Reunion>();
                    var iLst = oList;
                    ((IList)iLst).LoadFromReader<BEGCP_Reunion>(odr);

                    if (odr.NextResult())
                    {
                        var oListParticipante = new List<BEGCP_ReunionParticipante>();
                        var iListParticipante = oListParticipante;
                        ((IList)iListParticipante).LoadFromReader<BEGCP_ReunionParticipante>(odr);

                        oList.ForEach(obj =>
                        {
                            oListParticipante.ForEach(objp=> {
                                if (objp.reu_Codigo == obj.reu_Codigo)
                                {
                                    obj.ReunionParticipante.Add(objp);
                                }
                            });                            
                        });
                    }
                    return (oList);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// MANTENIMIENTO DE REUNIONES DEL RFC
        /// </summary>
        /// <param name="oBe"></param>
        public void GCP0023_ReunionRFC(BEGCP_Reunion oBe)
        {
            try
            {
                oda.GCP0023_ReunionRFC(oBe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
