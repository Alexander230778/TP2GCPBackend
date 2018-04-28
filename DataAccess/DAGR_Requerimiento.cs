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
    public class DAGR_Requerimiento
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGR_Requerimiento()
        {
            //DatabaseProviderFactory factory = new DatabaseProviderFactory();
            odb = DatabaseFactory.CreateDatabase("CN");
            //odb = factory.Create("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OTENER LA LISTA DE REQUERIMIENTOS DEL PROYECTO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader GCP0002_GR_Requerimiento_LIST(BEGR_Requerimiento oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCP0002_GR_Requerimiento_LIST", oBe.lir_Codigo, oBe.acci);
                ocmd.CommandTimeout = 2000;
                var odr = odb.ExecuteReader(ocmd);
                return (odr);
            }
            finally
            {
                ocn.Close();
            }
        }

    }
}
