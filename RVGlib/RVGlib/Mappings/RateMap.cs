using RVGlib.Domain;
using FluentNHibernate.Mapping;

namespace RVGlib.Mappings
{
    public class RateMap : ClassMap<Rate>
    {
        public RateMap()
        {
            this.TableName = "rates";
            
            Id(x => x.Id);
            Map(x => x.name).CanNotBeNull().WithLengthOf(100);
            HasMany<Price>(x => x.Prices)
                .LazyLoad()
                .Cascade.All().IsInverse();
        }
    }
}
