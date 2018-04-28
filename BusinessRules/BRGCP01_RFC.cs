using BusinessEntities;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;

namespace BusinessRules
{
    public class BRGCP01_RFC
    {
        private DAGCP01_RFC oda;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BRGCP01_RFC()
        {
            oda = new DAGCP01_RFC();
        }
        /// <summary>
        /// OBTENER LA LISTA DE LAS RFC
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BEGCP01_RFC> GCP0001_RFC_LIST(BEGCP01_RFC oBe)
        {
            using (var odr = oda.GCP0001_RFC_LIST(oBe))
            {
                var oList = new List<BEGCP01_RFC>();
                var iLst = oList;
                ((IList)iLst).LoadFromReader<BEGCP01_RFC>(odr);
                return (oList);
            }
        }
    }
}
