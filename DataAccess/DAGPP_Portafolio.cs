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
    public class DAGPP_Portafolio
    {
        private Database odb;
        private DbConnection ocn;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAGPP_Portafolio()
        {
            odb = DatabaseFactory.CreateDatabase("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OBTENER LS LISTA DE PORTAFOLIOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader GPP0004_GPP_Portafolio_LIST(BEGPP_Portafolio oBe)
        {
            try
            {
                if (ocn.State == ConnectionState.Closed) ocn.Open();
                var ocmd = odb.GetStoredProcCommand("GPP0004_GPP_Portafolio_LIST", oBe.NumPortafolio, oBe.acci);
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
