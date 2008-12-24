using RVGlib.Domain;
using FluentNHibernate.Mapping;

namespace RVGlib.Mappings
{
    public class NumberMap : ClassMap<Number>
    {
        public NumberMap()
        {
            this.TableName = "numbers";
            Id(x => x.Id);
            Map(x => x.number);
            //Map(x => x.abonent_id);
            References(x => x.rate);
            References(x => x.abonent);
            HasMany<Call>(x => x.Calls)
                .AsList()
                .Cascade.All().LazyLoad();
            HasMany<Bill>(x => x.Bills)
                .AsList()
                .Cascade.All().LazyLoad();
            //this.parentIsRequired = true;
        }
    }
}
