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
        public void Can_Add_Private_Abonent_To_Database_Revisited()
        {
            //var numbers = new[]
            //    {
            //        new Number { number = "333333333"},
            //        new Number { number = "444"},
            //        new Number { number = "555555"}
            //    };
            Decimal bal = 0;
            //DateTime time = DateTime.Now;
        new PersistenceSpecification<PrivateAbonent>(Session)
            .CheckProperty(x => x.address, "addr")
            .CheckProperty(x => x.phone, "123")
            .CheckProperty(x => x.mail_address, "q@mail.ru")
                //.CheckProperty(x => x.reg_time, time)
                //.CheckProperty(x => x.last_pay_date, time)
            .CheckProperty(x => x.balance, bal)
                //.CheckList<Number>(x => x.Numbers, numbers)
                .CheckProperty(x => x.name, "myname")
                .CheckProperty(x => x.surname, "mysurname")
                .CheckProperty(x => x.patronymic, "!отчество!")
                .CheckProperty(x => x.passport_series, "2004123456")
                .CheckProperty(x => x.passport_date, DateTime.Today)
                .CheckProperty(x => x.passport_department, "выдан РОВД...")
                .CheckProperty(x => x.birth_date, DateTime.Today)
            .VerifyTheMappings();
        }
    }
}
