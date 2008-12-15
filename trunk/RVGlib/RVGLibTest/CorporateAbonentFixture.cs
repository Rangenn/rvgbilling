using System;

using NUnit.Framework;
using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;

namespace RVGLibTest
{
    [TestFixture]
    public class CorporateAbonentFixture : BaseFixture
    {
        [Test]
        public void Can_Add_CorporateAbonent_To_Database_Revisited()
        {
            new PersistenceSpecification<CorporateAbonent>(Session)
                .CheckProperty(x => x.address, "addr")
                .CheckProperty(x => x.phone, "123")
                .CheckProperty(x => x.mail_address, "q@mail.ru")
                .CheckProperty(x => x.reg_time, TestDateTime)
                .CheckProperty(x => x.last_pay_date, TestDateTime)
                .CheckProperty(x => x.balance, TestDecimal)
                .CheckProperty(x =>  x.corporate_name, "corp.")
                //.CheckList<Number>(x => x.Numbers, numbers)
                .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_CorporateAbonent_To_Database_WithNumbers()
        {
            var CorpAbonent = new CorporateAbonent
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                reg_time = TestDateTime,
                last_pay_date = TestDateTime,
                balance = TestDecimal,
                corporate_name = "corp"
            };
            Session.Save(CorpAbonent);

            var rate = new Rate() { name = "MyRate" };
            Session.Save(rate);

            var Number = new Number { number = "222", abonent = CorpAbonent, rate = rate };
            Session.Save(Number);
            CorpAbonent.Numbers.Add(Number);
            Session.Update(CorpAbonent);
            Session.Flush();
            Session.Clear();

            var fromDb = Session.Get<CorporateAbonent>(CorpAbonent.Id);

            Assert.AreEqual(fromDb.Numbers.Count, 1);

            Assert.AreEqual(fromDb.Numbers[0].Id, Number.Id);
        }
    }
}
