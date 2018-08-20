using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace DataAccess
{
    public class DAGenericInfoRequest
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGenericInfoRequest()
        {
            odb = DatabaseFactory.CreateDatabase("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OBTENER LAS LISTAS DE:
        /// TIPOS DE REQUERIMIENTO
        /// NIVEL DE DOCUMENTACION
        /// PRIORIODAD DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader GCP0012_GCP18GCP19GCP20_LIST(BEGenericInfoRequest oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCP0012_GCP18GCP19GCP20_LIST", oBe.acci);
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
