using System;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    public class Call : Entity
    {
        public virtual Number number { get; set; }

        public virtual String   calling_number { get; set; }
        public virtual DateTime start_time { get; set; }
        public virtual Decimal  duration { get; set; }
        public virtual Decimal  cost { get; set; }
    }
}
