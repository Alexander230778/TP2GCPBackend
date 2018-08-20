using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGR_Requerimiento
    {
        public BEGR_Requerimiento()
        {
            LST_RECU = new List<BEGCP9_Recurso>();
        }
        public int key { get; set; }
        public int lir_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public string lir_Nombre { get; set; }
        public string lir_Resumen { get; set; }
        public DateTime lir_Fecha { get; set; }
        public int lir_NivelDoc { get; set; }
        public int lir_TipoPublicacion { get; set; }
        public string lir_semanaMax { get; set; }
        public decimal lir_Presupuesto { get; set; }
        public int GPP_Proyecto_pro_Codigo { get; set; }
        public string est_Estado { get; set; }
        public int lir_Prioridad { get; set; }
        public List<BEGCP9_Recurso> LST_RECU { get; set; }
        public int acci { get; set; }
    }
}
