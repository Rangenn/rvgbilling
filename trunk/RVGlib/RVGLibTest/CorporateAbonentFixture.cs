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
            Decimal bal = 0;
            //DateTime date = DateTime.Today;
            new PersistenceSpecification<CorporateAbonent>(Session)
                .CheckProperty(x => x.address, "addr")
                .CheckProperty(x => x.phone, "123")
                .CheckProperty(x => x.mail_address, "q@mail.ru")
                .CheckProperty(x => x.reg_time, date)
                .CheckProperty(x => x.last_pay_date, date)
                .CheckProperty(x => x.balance, bal)
                .CheckProperty(x =>  x.corporate_name, "corp.")
                //.CheckList<Number>(x => x.Numbers, numbers)
                .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_CorporateAbonent_To_Database_WithNumbers()
        {
            Decimal bal = 1;
            //DateTime date = DateTime.Today;
            var CorpAbonent = new CorporateAbonent
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                reg_time = date,
                last_pay_date = date,
                balance = bal,
                corporate_name = "corp"
            };
            Session.Save(CorpAbonent);
            Session.Flush();

            Int64 rateid = 1;
            //Abonent Ab = Session.Get<Abonent>(CorpAbonent.Id);
            var Number = new Number { number = "222", abonent = CorpAbonent, rate = Session.Get<Rate>(rateid) };
            Session.Save(Number);
            CorpAbonent.Numbers.Add(Number);
            Session.Update(CorpAbonent);
            Session.Flush();
            Session.Clear();
            //throw new Exception();
            var fromDb = Session.Get<CorporateAbonent>(CorpAbonent.Id);

            Assert.AreEqual(fromDb.Numbers.Count, 1);

            Assert.AreEqual(fromDb.Numbers[0].Id, Number.Id);
        }
    }
}
