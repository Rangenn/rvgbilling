using FluentNHibernate.Mapping;
using RVGlib.Domain;

namespace RVGlib.Mappings
{
    public class BillMap : ClassMap<Bill>
    {
        public BillMap()
        {            
            this.TableName = "bills";
            //WithTable("bills");
           // Cache.AsReadWrite();
            Id(x => x.Id);
            Map(x => x.creation_time);
            Map(x => x.money);
            References(x => x.number);
        }
    }
}
