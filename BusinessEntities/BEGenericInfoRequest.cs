using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGenericInfoRequest
    {
        public BEGenericInfoRequest()
        {
            LST_NIVE = new List<BEGCP18_NivelDocumento>();
            LST_PRIO = new List<BEGCP20_PriodidadRequerimiento>();
            LST_TIPO = new List<BEGCP19_TipoRequerimiento>();
        }
        public List<BEGCP18_NivelDocumento> LST_NIVE { get; set; }
        public List<BEGCP19_TipoRequerimiento> LST_TIPO { get; set; }
        public List<BEGCP20_PriodidadRequerimiento> LST_PRIO { get; set; }
        public int acci { get; set; }
    }
}
