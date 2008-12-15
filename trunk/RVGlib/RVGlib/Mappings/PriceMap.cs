using FluentNHibernate.Mapping;
using RVGlib.Domain;


namespace RVGlib.Mappings
{
    public class PriceMap : ClassMap<Price>
    {
        public PriceMap()
        {            
            this.TableName = "prices";
            Id(x => x.Id);
            References(x => x.rate);
            Map(x => x.cost_per_minute);
            Map(x => x.mask);
        }
    }
}
