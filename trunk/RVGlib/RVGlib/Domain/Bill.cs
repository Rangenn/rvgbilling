using System;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    public class Bill : Entity
    {
        public virtual Number   number  { get; set; }
        public virtual Decimal  money { get; set; }
        public virtual DateTime bill_date { get; set; }
    }
}
