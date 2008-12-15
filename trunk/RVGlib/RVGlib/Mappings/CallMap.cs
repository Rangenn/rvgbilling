using FluentNHibernate.Mapping;
using RVGlib.Domain;

namespace RVGlib.Mappings
{
    public class CallMap : ClassMap<Call>
    {
        public CallMap()
        {            
            this.TableName = "calls";
            Id(x => x.Id);
            Map(x => x.calling_number);
            References(x => x.number);
            Map(x => x.start_time);
            Map(x => x.duration);
            Map(x => x.cost);
        }
    }
}
