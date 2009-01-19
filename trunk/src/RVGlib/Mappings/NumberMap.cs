using RVGlib.Domain;
using FluentNHibernate.Mapping;

namespace RVGlib.Mappings
{
    public class NumberMap : ClassMap<Number>
    {
        public NumberMap()
        {
            this.TableName = "numbers";
            //WithTable("numbers");
            //Cache.AsReadWrite();
            Id(x => x.Id);
            Map(x => x.number);
            //Map(x => x.abonent_id);
            References(x => x.rate);
            References(x => x.abonent);
            HasMany<Call>(x => x.Calls)
                .Cascade.All().LazyLoad().IsInverse();
            HasMany<Bill>(x => x.Bills)
                .Cascade.All().LazyLoad().IsInverse();
            //this.parentIsRequired = true;
        }
    }
}
