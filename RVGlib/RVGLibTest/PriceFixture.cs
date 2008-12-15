using System;

using NUnit.Framework;
using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;

namespace RVGLibTest
{
    [TestFixture]
    public class PriceFixture : BaseFixture
    {

        [Test]
        public void Can_Add_Price_To_Database_Revisited()
        {
            var rate = new Rate() { name = "MyRate" };
            Session.Save(rate);
            new PersistenceSpecification<Price>(Session)
            .CheckProperty(x => x.rate, rate)
            .CheckProperty(x => x.mask, "920")
            .CheckProperty(x => x.cost_per_minute, TestDecimal)
            .VerifyTheMappings();
        }
    }
}
