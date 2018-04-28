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
    public class DAGCP01_RFC
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGCP01_RFC()
        {
            //DatabaseProviderFactory factory = new DatabaseProviderFactory();
            odb = DatabaseFactory.CreateDatabase("CN");
            //odb = factory.Create("CN");
            ocn = odb.CreateConnection();
        }
        public IDataReader GCP0001_RFC_LIST(BEGCP01_RFC oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GCP0001_RFC_LIST", oBe.rfc_Codigo,oBe.acci);
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
