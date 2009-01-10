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
            new PersistenceSpecification<Abonent>(Session)
                .CheckProperty(x => x.address, "addr")
                .CheckProperty(x => x.phone, "123")
                .CheckProperty(x => x.mail_address, "q@mail.ru")
                .CheckProperty(x => x.reg_time, TestDateTime)
                .CheckProperty(x => x.last_pay_date, TestDateTime)
                .CheckProperty(x => x.balance, TestDecimal)
                .CheckProperty(x => x.dissolved, TestBoolean)
                //.CheckList<Number>(x => x.Numbers, numbers)
                .VerifyTheMappings()
                ;
        }

        [Test]
        public void Can_Add_Abonent_To_Database_WithNumbers()
        {
            Abonent Abonent = new Abonent
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                reg_time = TestDateTime,
                last_pay_date = TestDateTime,
                balance = TestDecimal
            };
            Session.Save(Abonent);

            Rate rate = new Rate() { name = "MyRate" };
            Session.Save(rate);

            Number Number = new Number { number = "111", abonent = Abonent, rate = rate };
            //Session.Save(Number);
            Abonent.Numbers.Add(Number);
            Session.Update(Abonent);

            Number = new Number { number = "222", abonent = Abonent, rate = rate };
            //Session.Save(Number);
            Abonent.Numbers.Add(Number);
            Session.Update(Abonent);
            Session.Flush();
            Session.Clear();

            Abonent fromDb = Session.Get<Abonent>(Abonent.Id);

            Assert.AreEqual(fromDb.Numbers.Count, 2);

            Assert.AreEqual(fromDb.Numbers[1].Id, Number.Id);

        }
    }
}
