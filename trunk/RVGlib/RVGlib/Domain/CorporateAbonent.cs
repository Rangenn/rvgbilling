using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVGlib.Domain
{
    public class CorporateAbonent : Abonent
    {
        public virtual String corporate_name { get; set; }
    }
}
