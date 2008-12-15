using System;
using System.Collections.Generic;
using System.Text;

namespace RVGlib.Framework
{
    public class Model : FluentNHibernate.PersistenceModel
    {
        public Model()
        {
            addMappingsFromAssembly(typeof(RVGlib.Mappings.AbonentMap).Assembly);

        }
    }
}
