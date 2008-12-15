using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVGlib.Domain
{
    public class PrivateAbonent : Abonent
    {
        public virtual String   surname { get; set; }
        public virtual String   name { get; set; }
        public virtual String   patronymic { get; set; }
        public virtual String   passport_series { get; set; }
        public virtual DateTime passport_date { get; set; }
        public virtual String   passport_department { get; set; }
        public virtual DateTime birth_date { get; set; }
    }
}
