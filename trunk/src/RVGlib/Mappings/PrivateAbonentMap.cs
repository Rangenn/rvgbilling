using FluentNHibernate.Mapping;
using RVGlib.Domain;

namespace RVGlib.Mappings
{
    public class PrivateAbonentMap : ClassMap<PrivateAbonent>
    {
        public PrivateAbonentMap()
        {
            this.TableName = "private_abonents";
            //WithTable("private_abonents");
            //Cache.AsReadWrite();
            Id(x => x.Id);
            Map(x => x.address);
            Map(x => x.phone);
            Map(x => x.mail_address);
            Map(x => x.creation_time);
            Map(x => x.last_pay_date);
            Map(x => x.balance);
            Map(x => x.dissolved);
            HasMany<Number>(x => x.Numbers)
                .WithKeyColumn("abonent_id") //!!!
                .Cascade.All().LazyLoad().IsInverse();

            Map(x => x.surname);
            Map(x => x.name);
            Map(x => x.patronymic);
            Map(x => x.passport_series).WithLengthOf(10);
            Map(x => x.passport_date);
            Map(x => x.passport_department);
            Map(x => x.birth_date);
        }
    }
}
