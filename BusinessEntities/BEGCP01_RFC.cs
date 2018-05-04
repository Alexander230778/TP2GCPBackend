using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGCP01_RFC
    {
        public BEGCP01_RFC()
        {
            LST_REQU = new List<BEGR_Requerimiento>();
            LST_BENE = new List<BEGCP_Beneficio>();
            bene_codigos = new List<int>();
        }
        public int rfc_Codigo { get; set; }
        public DateTime rfc_FechaSolicitud { get; set; }
        public int rfc_NivelImpacto { get; set; }
        public string rfc_Asunto { get; set; }
        public string rfc_Descripcion { get; set; }
        public int pro_Codigo { get; set; }
        public int per_Codigo { get; set; }
        public int GCP13_EncargadosRFC_per_Codigo { get; set; }
        public int est_Codigo { get; set; }
        public string est_Estado { get; set; }
        public string pro_Nombre { get; set; }
        public string por_Nombre { get; set; }
        public string per_Nombre { get; set; }
        public string per_Email { get; set; }
        public int NumPortafolio { get; set; }
        public string rfc_StrFechaSolicitud { get; set; }
        public List<BEGR_Requerimiento> LST_REQU { get; set; }
        public List<BEGCP_Beneficio> LST_BENE { get; set; }
        public List<int> bene_codigos { get; set; }
        public int acci { get; set; }
    }
}
