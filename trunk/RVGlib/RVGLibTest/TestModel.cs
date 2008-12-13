
namespace RVGLibTest
{

    public class TestModel : FluentNHibernate.PersistenceModel
    {
        public TestModel()
        {
            addMappingsFromAssembly(typeof(RVGlib.Mappings.AbonentMap).Assembly);
           
        }      
    }
}
