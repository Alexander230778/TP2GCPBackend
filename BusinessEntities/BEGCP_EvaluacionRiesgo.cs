using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGCP_EvaluacionRiesgo
    {
        public int evr_Codigo { get; set; }
        public bool evr_Requiere { get; set; }
        public DateTime evr_FechaEnvio { get; set; }
        public string evr_Estado { get; set; }
        public DateTime evr_FechaRespuesta { get; set; }
        public string evr_Informe { get; set; }
        public string evr_Impacto { get; set; }
        public string evr_Adjunto { get; set; }
        public int rfc_Codigo { get; set; }
        public int acci { get; set; }
    }
}
