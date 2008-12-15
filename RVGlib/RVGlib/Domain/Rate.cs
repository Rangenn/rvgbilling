using System;

using FluentNHibernate.Framework;
using System.Collections.Generic;

namespace RVGlib.Domain
{
    public class Rate : Entity
    {
        public Rate()
        {
            Prices = new List<Price>();
        }

        public Rate(String name)
        {
            Prices = new List<Price>();
            this.name = name;
            
        }

        //public virtual int rate_id { get; set; }
        public virtual String       name { get; set; }
        public virtual IList<Price> Prices { get; private set; }
    }
}
