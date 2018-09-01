using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGCP_ReunionParticipante
    {
        public int key { get; set; }
        public int reu_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public int per_Codigo { get; set; }
        public string per_Nombre { get; set; }
        public string per_Email { get; set; }
        public int per_Telefono { get; set; }
        public string par_Cargo { get; set; }
    }
}
