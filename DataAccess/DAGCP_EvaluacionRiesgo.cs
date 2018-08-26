using BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAGCP_EvaluacionRiesgo
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGCP_EvaluacionRiesgo()
        {
            odb = DatabaseFactory.CreateDatabase("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OTENER LA LISTA DE REQUERIMIENTOS DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader GCPP0015_GCP_EvaluacionRiesgo_LIST(BEGCP_EvaluacionRiesgo oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCPP0015_GCP_EvaluacionRiesgo_LIST", oBe.rfc_Codigo);
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
        /// MANTENIMIENTO DE EVALUACIÓN DE RIESGO
        /// </summary>
        /// <param name="oBe"></param>
        public void GCPP0014_GCP_EvaluacionRiesgo(BEGCP_EvaluacionRiesgo oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCPP0014_GCP_EvaluacionRiesgo", oBe.evr_Codigo,
                                                                                                oBe.evr_Requiere,
                                                                                                oBe.evr_Estado,
                                                                                                oBe.rfc_Codigo,
                                                                                                oBe.evr_Observacion,
                                                                                                oBe.pri_Codigo,
                                                                                                oBe.acci))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.evr_Codigo = Convert.ToInt32(odb.GetParameterValue(ocmd, "@evr_Codigo"));

                        obts.Commit();
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
