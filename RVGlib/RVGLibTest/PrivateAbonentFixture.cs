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
            new PersistenceSpecification<PrivateAbonent>(Session)
                .CheckProperty(x => x.address, "addr")
                .CheckProperty(x => x.phone, "123")
                .CheckProperty(x => x.mail_address, "q@mail.ru")
                .CheckProperty(x => x.reg_time, TestDateTime)
                .CheckProperty(x => x.last_pay_date, TestDateTime)
                .CheckProperty(x => x.balance, TestDecimal)
                //.CheckList<Number>(x => x.Numbers, numbers)
                .CheckProperty(x => x.name, "myname")
                .CheckProperty(x => x.surname, "mysurname")
                .CheckProperty(x => x.patronymic, "!отчество!")
                .CheckProperty(x => x.passport_series, "2004123456")
                .CheckProperty(x => x.passport_date, TestDateTime)
                .CheckProperty(x => x.passport_department, "выдан РОВД...")
                .CheckProperty(x => x.birth_date, TestDateTime)
                .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_PrivateAbonent_To_Database_With_All_Fields()
        {
            var Abonent = new PrivateAbonent
            {
                address = "a",
                phone = "p",
                mail_address = "m",
                reg_time = TestDateTime,
                last_pay_date = TestDateTime,
                balance = TestDecimal,
                name = "nm",
                surname = "sn",
                patronymic = "otch",
                passport_series = "1111222222",
                passport_date = TestDateTime,
                passport_department = "ROVD",
                birth_date = TestDateTime
                
            };
            Session.Save(Abonent);

            var rate = new Rate() { name = "MyRate" };
            Session.Save(rate);

            var Number = new Number { number = "111", abonent = Abonent, rate = rate };
            Bill[] bills =
                {
                    new Bill() { bill_date = TestDateTime, number = Number, money = TestDecimal},
                    new Bill() { bill_date = TestDateTime, number = Number, money = TestDecimal},
                    new Bill() { bill_date = TestDateTime, number = Number, money = TestDecimal},
                };
            Call[] calls =
                {
                    new Call() { calling_number = "1", number = Number, start_time = TestDateTime, duration = 1, cost = TestDecimal},
                    new Call() { calling_number = "1", number = Number, start_time = TestDateTime, duration = 1, cost = TestDecimal},
                    new Call() { calling_number = "1", number = Number, start_time = TestDateTime, duration = 1, cost = TestDecimal},
                };
            for (int i = 0; i < 3; i++)
            {
                Number.Bills.Add(bills[i]);
            }

            Abonent.Numbers.Add(Number);
            Session.Update(Abonent);
            Session.Flush();
            Session.Clear();

            var fromDb = Session.Get<PrivateAbonent>(Abonent.Id);

            Assert.AreEqual(fromDb.Numbers.Count, 1);

            Assert.AreEqual(fromDb.Numbers[0].Id, Number.Id);
        }
    }
}
