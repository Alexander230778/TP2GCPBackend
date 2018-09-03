using System.Collections.Generic;

namespace BusinessEntities
{
    public class BEGCP_Reunion
    {
        public BEGCP_Reunion()
        {
            ReunionParticipante = new List<BEGCP_ReunionParticipante>();
        }
        public int key { get; set; }
        public int acci { get; set; }
        public int reu_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public string reu_FechaReunion { get; set; }
        public string reu_HoraReunion { get; set; }
        public string reu_Lugar { get; set; }
        public string reu_Comentario { get; set; }

        public List<BEGCP_ReunionParticipante> ReunionParticipante {get; set;}
    }

    public class BEResponseReunion
    {
        public BEResponseReunion()
        {
            data = new BEGCP_Reunion();
        }
        public bool success { get; set; }
        public BEGCP_Reunion data { get; set; }
    }
}
