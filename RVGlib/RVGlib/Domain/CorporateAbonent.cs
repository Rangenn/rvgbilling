using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    public class CorporateAbonent : Abonent
    {
        public virtual String corporate_name { get; set; }
        //Abonent abonent;
    }
}
