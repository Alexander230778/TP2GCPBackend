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
        public IDataReader GCP0023_ReunionRFC_LIST(BEGCP_Reunion oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCP0023_ReunionRFC_LIST",oBe.rfc_Codigo);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteReader(ocmd);
                return (odr);
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
        public void GCP0023_ReunionRFC(BEGCP_Reunion oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            BEGCP_Reunion _be = new BEGCP_Reunion();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCP0023_ReunionRFC", 
                        oBe.rfc_Codigo,
                        oBe.reu_FechaReunion,
                        oBe.reu_HoraReunion,
                        oBe.reu_Lugar,
                        oBe.reu_Comentario,
                        oBe.reu_Codigo))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.reu_Codigo = Convert.ToInt32(odb.GetParameterValue(ocmd, "@reu_Codigo"));

                        //Detalle Reunión Participantes
                        DbCommand cmdo;
                        oBe.ReunionParticipante.ForEach(obj =>
                        {
                            cmdo = odb.GetStoredProcCommand("GCP0024_ReunionParticipanteRFC", 
                                oBe.reu_Codigo,
                                oBe.rfc_Codigo,
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
        }
    }
}
