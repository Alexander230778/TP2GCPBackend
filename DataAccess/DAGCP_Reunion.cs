using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using ResultSetMappers;

namespace DataAccess
{
    public class DAGCP_Reunion
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGCP_Reunion()
        {
            odb = DatabaseFactory.CreateDatabase("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OBTENER LA LISTA DE REUNIONES DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP_Reunion> GCP0023_ReunionRFC_LIST(BEGCP_Reunion oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCP0023_ReunionRFC_LIST", oBe.rfc_Codigo);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteReader(ocmd);
                
                var oList = new List<BEGCP_Reunion>();
                var iLst = oList;
                ((IList)iLst).LoadFromReader<BEGCP_Reunion>(odr);

                //Detalle Reunión Participantes
                DbCommand cmdo;
                oList.ForEach(obj =>
                {
                    cmdo = odb.GetStoredProcCommand("GCP0023_ReunionParticipanteRFC_LIST", obj.reu_Codigo);
                    cmdo.CommandTimeout = 2000;
                    var odrD = odb.ExecuteReader(cmdo);

                    var oListD = new List<BEGCP_ReunionParticipante>();
                    var iLstD = oListD;
                    ((IList)iLstD).LoadFromReader<BEGCP_ReunionParticipante>(odrD);

                    obj.ReunionParticipante = oListD;
                });

                return (oList);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                ocn.Close();
            }
        }
        /// <summary>
        /// MANTENIMIENTO DE REUNIONES DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        public BEGCP_Reunion GCP0023_ReunionRFC(BEGCP_Reunion oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            BEGCP_Reunion _be = new BEGCP_Reunion();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCP0023_ReunionRFC", oBe.acci,
                        oBe.rfc_Codigo,
                        oBe.reu_FechaReunion,
                        oBe.reu_HoraReunion,
                        oBe.reu_Lugar,
                        oBe.reu_Comentario))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.reu_Codigo = Convert.ToInt32(odb.GetParameterValue(ocmd, "@reu_Codigo"));

                        //Detalle Reunión Participantes
                        DbCommand cmdo;
                        oBe.ReunionParticipante.ForEach(obj =>
                        {
                            cmdo = odb.GetStoredProcCommand("GCP0023_ReunionParticipanteRFC", oBe.reu_Codigo,
                                obj.rfc_Codigo,
                                obj.per_Codigo);
                            cmdo.CommandTimeout = 2000;
                            odb.ExecuteNonQuery(cmdo, obts);
                        });

                        obts.Commit();
                        _be = oBe;
                    }
                }
                catch (Exception ex)
                {
                    obts.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    ocn.Close();
                }
            }
            return _be;
        }
    }
}
