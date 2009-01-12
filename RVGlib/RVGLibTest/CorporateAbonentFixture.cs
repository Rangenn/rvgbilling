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
                .CheckProperty(x => x.creation_time, TestDateTime)
                .CheckProperty(x => x.last_pay_date, TestDateTime)
                .CheckProperty(x => x.balance, TestDecimal)
                .CheckProperty(x =>  x.corporate_name, "corp.")
                .CheckProperty(x => x.dissolved, TestBoolean)
                .CheckProperty(x => x.INN, "1111111")
                //.CheckList<Number>(x => x.Numbers, numbers)
                .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_CorporateAbonent_To_Database_WithNumbers()
        {
            CorporateAbonent CorpAbonent = new CorporateAbonent()
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                creation_time = TestDateTime,
                last_pay_date = TestDateTime,
                balance = TestDecimal,
                corporate_name = "corp",
                INN = "123123"
            };
            Session.Save(CorpAbonent);

            Rate rate = new Rate() { name = "MyRate" };
            Session.Save(rate);
            long id = rate.Id;
            Number Number = new Number { number = "222", abonent = CorpAbonent, rate = rate };
            //Session.Save(Number);
            CorpAbonent.Numbers.Add(Number);
            Session.Update(CorpAbonent);
            Session.Flush();
            Session.Clear();

            CorporateAbonent fromDb = Session.Get<CorporateAbonent>(CorpAbonent.Id);

            Assert.AreEqual(fromDb.Numbers.Count, 1);

            Assert.AreEqual(fromDb.Numbers[0].Id, Number.Id);
            Session.Delete(fromDb);
            Session.Delete(Session.Get<Rate>(id));
            Session.Flush();
            Session.Clear();
        }
    }
}
