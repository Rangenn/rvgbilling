using System;

using NUnit.Framework;
using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;

namespace RVGLibTest
{
    [TestFixture]
    public class AbonentFixture : BaseFixture
    {
        [Test]
        public void Can_Add_Abonent_To_Database_Revisited()
        {
            var numbers = new[]
                {
                    new Number { number = "333333333"},
                    new Number { number = "444"},
                    new Number { number = "555555"}
                };
            Decimal bal = 0;
            //DateTime time = DateTime.Now;
            new PersistenceSpecification<Abonent>(Session)
            .CheckProperty(x => x.address, "addr")
            .CheckProperty(x => x.phone, "123")
            .CheckProperty(x => x.mail_address, "q@mail.ru")
            //.CheckProperty(x => x.reg_time, time)
            //.CheckProperty(x => x.last_pay_date, time)
            .CheckProperty(x => x.balance, bal)
            .CheckList<Number>(x => x.Numbers, numbers)
            .VerifyTheMappings();
        }
    }
}
