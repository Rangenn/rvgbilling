using System;
using System.Collections.Generic;
using System.Text;
using RVGlib.Mappings;

namespace RVGlib.Framework
{
    /// <summary>
    /// Модель данных. загружает маппинг из сборки.
    /// </summary>
    public class Model : FluentNHibernate.PersistenceModel
    {
        public Model()
        {
            //addMapping(new AbonentMap());
            //addMapping(new PrivateAbonentMap());
            //addMapping(new PriceMap());
            //addMapping(new CorporateAbonentMap());
            //addMapping(new NumberMap());
            //addMapping(new RateMap());
            //addMapping(new BillMap());
            //addMapping(new CallMap());

            addMappingsFromAssembly(typeof(RVGlib.Mappings.AbonentMap).Assembly);
            

        }
    }
}
