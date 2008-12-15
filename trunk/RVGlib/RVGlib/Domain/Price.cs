using System;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    public class Price : Entity
    {
        public virtual Rate     rate { get; set; }
        public virtual Decimal  cost_per_minute { get; set; }
        public virtual String   mask { get; set; }
    }
}
