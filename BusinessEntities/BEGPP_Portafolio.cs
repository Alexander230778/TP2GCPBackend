using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGPP_Portafolio
    {
        public int NumPortafolio { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Prioridad { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public int acci { get; set; }
        public int value { get; set; }
        public string text { get; set; }
    }
}
