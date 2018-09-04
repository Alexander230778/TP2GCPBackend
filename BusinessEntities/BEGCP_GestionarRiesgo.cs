using System;

namespace BusinessEntities
{
    public class BEGCP_GestionarRiesgo
    {
        public int evr_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public string evr_FechaEnvio { get; set; }
        public string evr_FechaLimite { get; set; }
        public string evr_FechaRespuesta { get; set; }
        public string evr_Limite { get; set; }
        public string rfc_Asunto { get; set; }
        public int pri_Codigo { get; set; }
        public string pri_Descripcion { get; set; }
        public int esr_Codigo { get; set; }
        public string esr_Descripcion { get; set; }
    }
}
