using System;

using NUnit.Framework;
using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;
using System.Collections.Generic;

namespace RVGLibTest
{
    [TestFixture]
    public class RateFixture : BaseFixture
    {
        
        [Test]
        public void Can_Add_Rate_To_Database_Revisited()
        {
            new PersistenceSpecification<Rate>(Session)
            .CheckProperty(x => x.name, "RateName")
            .VerifyTheMappings();
        }

        [Test]
        public void Can_Add_Rate_To_Database_WithPrices()
        {
            var rate = new Rate() { name = "MyRate"};
            Session.Save(rate);
            Price[] prices =
            {
                new Price() { rate = rate, mask = "910", cost_per_minute = TestDecimal},
                new Price() { rate = rate, mask = "920", cost_per_minute = TestDecimal},
                new Price() { rate = rate, mask = "930", cost_per_minute = TestDecimal},
            };
            for (int i = 0; i < 3; i++)
            {
                //Session.Save(prices[i]);
                rate.Prices.Add(prices[i]);
            }
            Session.Update(rate);
            Session.Flush();
            Session.Clear();

            var fromDb = Session.Get<Rate>(rate.Id);

            Assert.AreEqual(fromDb.Prices.Count, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(fromDb.Prices[i].Id, rate.Prices[i].Id);
            }
            Session.Delete(fromDb);
        }
    }
}
