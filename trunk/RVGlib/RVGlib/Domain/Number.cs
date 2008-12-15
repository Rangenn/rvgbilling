using System;
using System.Collections.Generic;
using System.Text;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    public class Number : Entity
    {
        public Number()
        {
            Calls = new List<Call>();
            Bills = new List<Bill>();
        }

        //public Number(String number)
        //{
        //    this.number = number;
        //    //RateAssociation = rate;
        //}


        public virtual String number { get; set; }

        public virtual Abonent abonent { get; set; }
        public virtual Rate rate { get; set; }
        public virtual IList<Call> Calls { get; private set; }
        public virtual IList<Bill> Bills { get; private set; }
    }
}
