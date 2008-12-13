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
            //var numbers = new[]
            //    {
            //        new Number { number = "333333333"},
            //        new Number { number = "444"},
            //        new Number { number = "555555"}
            //    };
            Decimal bal = 0;
            //DateTime time = DateTime.Now;
            new PersistenceSpecification<Abonent>(Session)
            .CheckProperty(x => x.address, "addr")
            .CheckProperty(x => x.phone, "123")
            .CheckProperty(x => x.mail_address, "q@mail.ru")
            //.CheckProperty(x => x.reg_time, time)
            //.CheckProperty(x => x.last_pay_date, time)
            .CheckProperty(x => x.balance, bal)
            //.CheckList<Number>(x => x.Numbers, numbers)
            .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_Abonent_To_Database_WithNumbers()
        {
            Decimal bal = 1;
            var Abonent = new Abonent
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                reg_time = DateTime.Today,
                last_pay_date = DateTime.Now,
                balance = bal
            };
            Session.Save(Abonent);

            Int64 myid = 1;
            var Number = new Number { number = "111", abonent = Abonent, rate = Session.Get<Rate>(myid) };
            Abonent.Numbers.Add(Number);
            Session.Update(Abonent);
            Session.Flush();
            Session.Clear();

            var fromDb = Session.Get<Abonent>(Abonent.Id);

            Assert.AreEqual(fromDb.Numbers.Count, 1);

            Assert.AreEqual(fromDb.Numbers[0].Id, Number.Id);
        }
    }
}
