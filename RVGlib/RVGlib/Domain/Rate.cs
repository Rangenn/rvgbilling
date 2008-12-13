using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    public class Rate : Entity
    {
        public Rate() { }

        public Rate(String name)
        {
            this.name = name;
            
        }

        //public virtual int rate_id { get; set; }
        public virtual String name { get; set; }
    }
}
