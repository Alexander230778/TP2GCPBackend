using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BusinessEntities;

namespace DataAccess
{
    public class DAGCP_GestionarRiesgo
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGCP_GestionarRiesgo()
        {
            odb = DatabaseFactory.CreateDatabase("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OBTENER LA LISTA DE RIESGOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader GCP0025_GestionarRiesgo_LIST(BEGCP_GestionarRiesgo oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCP0025_GestionarRiesgo_LIST", oBe.esr_Codigo);
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
    }
}
