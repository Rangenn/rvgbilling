using FluentNHibernate.Mapping;
using RVGlib.Domain;

namespace RVGlib.Mappings
{
    public class CorporateAbonentMap : ClassMap<CorporateAbonent>
    {
        public CorporateAbonentMap()
        {
            this.TableName = "corporate_abonents";
            //WithTable("corporate_abonents");
            //Cache.AsReadWrite();
            Id(x => x.Id);
            Map(x => x.address);
            Map(x => x.phone);
            Map(x => x.mail_address);
            Map(x => x.creation_time);
            Map(x => x.last_calc_date);
            Map(x => x.balance);
            Map(x => x.dissolved);
            HasMany<Number>(x => x.Numbers)
                .WithKeyColumn("abonent_id")
                .Cascade.All().LazyLoad().IsInverse();

            Map(x => x.corporate_name);
            Map(x => x.INN);
        }
    }
}
