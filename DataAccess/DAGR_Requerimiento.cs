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
            odb = DatabaseFactory.CreateDatabase("CN");
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
                var ocmd = odb.GetStoredProcCommand("GCP0002_GR_Requerimiento_LIST",oBe.rfc_Codigo, oBe.lir_Codigo, oBe.acci);
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
        /// MANTENIMIENTO DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        public void GCP0011_GR_Requerimiento(BEGR_Requerimiento oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCP0011_GR_Requerimiento", oBe.lir_Codigo,
                                                                                            oBe.lir_Nombre,
                                                                                            oBe.lir_Resumen,
                                                                                            oBe.lir_FechaEntrega,
                                                                                            oBe.lir_EsFuncional,
                                                                                            oBe.lir_RequiereDocumentar,
                                                                                            oBe.rfc_Codigo,
                                                                                            oBe.lir_Prioridad,
                                                                                            oBe.acci))
                    {
                        ocmd.CommandTimeout = 2000;
                        odb.ExecuteNonQuery(ocmd, obts);
                        oBe.lir_Codigo = Convert.ToInt32(odb.GetParameterValue(ocmd, "@lir_Codigo"));
                        oBe.lir_FechaEntrega = Convert.ToString(odb.GetParameterValue(ocmd, "@lir_FechaEntrega"));

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
        /// <summary>
        /// MANTENIMIENTO DE REQUERIMIENTO
        /// </summary>
        /// <param name="oBe"></param>
        public void GCPGR_Requerimiento(BEGR_Requerimiento oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCPGR_Requerimiento",
                                                                                    oBe.lir_Codigo,
                                                                                    oBe.lir_Aprobado,
                                                                                    oBe.lir_ImpactoRiesgo,
                                                                                    oBe.lir_Dias,
                                                                                    oBe.pri_Prioridad,
                                                                                    oBe.lir_CostoAsignado))
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
        public void GCPGR_Requerimiento_planificar(BEGR_Requerimiento oBe)
        {
            if (ocn.State == ConnectionState.Closed) ocn.Open();
            using (var obts = ocn.BeginTransaction())
            {
                try
                {
                    using (var ocmd = odb.GetStoredProcCommand("GCPGR_Requerimiento_planificar",
                                                                                    oBe.lir_Codigo,
                                                                                    oBe.lir_Esfuerzo,
                                                                                    oBe.lir_Desde))
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
