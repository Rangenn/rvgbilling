using System;

using NUnit.Framework;
using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;

namespace RVGLibTest
{
    [TestFixture]
    public class PrivateAbonentFixture : BaseFixture
    {
        [Test]
        public void Can_Add_PrivateAbonent_To_Database_Revisited()
        {
            Decimal bal = 0;
            //DateTime date = DateTime.Today;
            new PersistenceSpecification<PrivateAbonent>(Session)
                .CheckProperty(x => x.address, "addr")
                .CheckProperty(x => x.phone, "123")
                .CheckProperty(x => x.mail_address, "q@mail.ru")
                .CheckProperty(x => x.reg_time, date)
                .CheckProperty(x => x.last_pay_date, date)
                .CheckProperty(x => x.balance, bal)
                //.CheckList<Number>(x => x.Numbers, numbers)
                .CheckProperty(x => x.name, "myname")
                .CheckProperty(x => x.surname, "mysurname")
                .CheckProperty(x => x.patronymic, "!отчество!")
                .CheckProperty(x => x.passport_series, "2004123456")
                .CheckProperty(x => x.passport_date, date)
                .CheckProperty(x => x.passport_department, "выдан РОВД...")
                .CheckProperty(x => x.birth_date, date)
                .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_PrivateAbonent_To_Database_WithNumbers()
        {
            Decimal bal = 1;
            //DateTime date = DateTime.Today;
            var Abonent = new PrivateAbonent
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                reg_time = date,
                last_pay_date = date,
                balance = bal,
                name = "nm",
                surname = "sn",
                patronymic = "otch",
                passport_series = "1111222222",
                passport_date = date,
                passport_department = "ROVD",
                birth_date = date
                
            };
            Session.Save(Abonent);

            Int64 rateid = 1;
            var Number = new Number { number = "111", abonent = Abonent, rate = Session.Get<Rate>(rateid) };
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
