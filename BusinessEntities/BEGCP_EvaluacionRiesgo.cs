using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGCP_EvaluacionRiesgo
    {
        public int acci { get; set; }
        public int evr_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public bool evr_Requiere { get; set; }
        public int pri_Codigo { get; set; }
        public string pri_Descripcion { get; set; }
        public string evr_Observacion { get; set; }
        public DateTime evr_FechaEnvio { get; set; }
        public int esr_Codigo { get; set; }
        public string esr_Descripcion { get; set; }
        public DateTime evr_FechaRespuesta { get; set; }
        public string evr_Informe { get; set; }
        public int imp_Codigo { get; set; }
        public string imp_Descripcion { get; set; }
        public string evr_Adjunto { get; set; }
        public bool evr_LineaBase { get; set; }
        public bool evr_Presupuesto { get; set; }
    }
}
