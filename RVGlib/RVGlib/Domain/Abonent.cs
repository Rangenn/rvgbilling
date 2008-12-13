using System;
using System.Collections.Generic;

using FluentNHibernate.Framework;
//using Iesi.Collections.Generic;

namespace RVGlib.Domain
{
    public class Abonent : Entity
    {
        //public virtual int abonent_id { get; set; }
        public virtual String address { get; set; }
        public virtual String phone { get; set; }
        public virtual String mail_address { get; set; }
        public virtual DateTime reg_time { get; set; }
        public virtual DateTime last_pay_date { get; set; }
        public virtual Decimal balance { get; set; }

        //public Number NumbersAssociation { get; set; }
        public virtual IList<Number> Numbers { get; private set; }

        //public virtual IList<Number> NumbersAssociation { get; set; }

        public Abonent()
        {
            Numbers = new List<Number>();
        }
    }
    
}
