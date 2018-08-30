using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGCP_Reunion
    {
        public BEGCP_Reunion()
        {
            ReunionParticipante = new List<BEGCP_ReunionParticipante>();
        }

        public int acci { get; set; }
        public int reu_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public DateTime reu_FechaReunion { get; set; }
        public DateTime reu_HoraReunion { get; set; }
        public string reu_Lugar { get; set; }
        public string reu_Comentario { get; set; }

        public List<BEGCP_ReunionParticipante> ReunionParticipante {get; set;}
    }
}
