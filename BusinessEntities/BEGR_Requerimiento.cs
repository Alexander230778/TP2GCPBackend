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
        public DateTime lir_FechaCreacion { get; set; }
        public string lir_FechaEntrega { get; set; }
        public bool lir_EsFuncional { get; set; }
        public bool lir_RequiereDocumentar { get; set; }
        public int GPP_Proyecto_pro_Codigo { get; set; }
        public string est_Estado { get; set; }
        public int lir_Prioridad { get; set; }
        public List<BEGCP9_Recurso> LST_RECU { get; set; }
        public int acci { get; set; }
    }
    public class requerimentRequest
    {
        public string title { get; set; }
        public string delivery { get; set; }
        public string description { get; set; }
        public int prioridad { get; set; }
        public bool isFunctional { get; set; }
        public bool requireDocumentation { get; set; }
        public int rfc_Codigo { get; set; }
    }
    public class requirementResponse
    {
        public bool success { get; set; }
        public BEGR_Requerimiento data { get; set; }
        public string message { get; set; }
    }
}
