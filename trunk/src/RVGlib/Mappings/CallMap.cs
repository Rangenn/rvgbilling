using FluentNHibernate.Mapping;
using RVGlib.Domain;

namespace RVGlib.Mappings
{
    public class CallMap : ClassMap<Call>
    {
        public CallMap()
        {            
            this.TableName = "calls";
            //WithTable("calls");
           // Cache.AsReadWrite();
            Id(x => x.Id);
            Map(x => x.calling_number);
            References(x => x.number);
            Map(x => x.creation_time);
            Map(x => x.duration);
            Map(x => x.cost);
        }
    }
}
