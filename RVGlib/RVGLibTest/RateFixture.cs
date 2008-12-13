using System;

using NUnit.Framework;
using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;

namespace RVGLibTest
{

    public class RateFixture : BaseFixture
    {
        
        [Test]
        public void Can_Add_Rate_To_Database_Revisited()
        {

            new PersistenceSpecification<Rate>(Session)
            .CheckProperty(x => x.name, "RateName")
            .VerifyTheMappings();
        }
    }
}
