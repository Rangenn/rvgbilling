using FluentNHibernate.Mapping;
using RVGlib.Domain;

namespace RVGlib.Mappings
{
    public class PrivateAbonentMap : ClassMap<PrivateAbonent>
    {
        public PrivateAbonentMap()
        {
            //this.
            this.TableName = "private_abonents";
            Id(x => x.Id);
            Map(x => x.address);
            Map(x => x.phone);
            Map(x => x.mail_address);
            Map(x => x.reg_time);
            Map(x => x.last_pay_date);
            Map(x => x.balance);
            Map(x => x.dissolved);
            HasMany<Number>(x => x.Numbers)
                .WithKeyColumn("abonent_id") //!!!
                .AsList()
                .Cascade.All().LazyLoad();

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
