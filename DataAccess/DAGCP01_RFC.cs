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
            odb = DatabaseFactory.CreateDatabase("CN");
            ocn = odb.CreateConnection();
        }
        /// <summary>
        /// OBTENER LA LISTA DE LAS RFCS O UNA RFC INDIVIDUAL
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
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
        /// <summary>
        /// OPERACIONES DE MANTANIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        public void GCP0006_RFC(BEGCP01_RFC oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCP0006_RFC", oBe.rfc_Codigo,
	                                                                            oBe.rfc_FechaSolicitud,
	                                                                            oBe.rfc_NivelImpacto,
	                                                                            oBe.rfc_Asunto,
	                                                                            oBe.rfc_Descripcion,
	                                                                            oBe.pro_Codigo,
	                                                                            oBe.per_Codigo,
	                                                                            oBe.GCP13_EncargadosRFC_per_Codigo,
	                                                                            oBe.est_Codigo,
	                                                                            oBe.acci))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
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
