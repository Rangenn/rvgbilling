
namespace RVGlib.Framework
{
    /// <summary>
    /// Модель данных. загружает маппинг из сборки.
    /// </summary>
    public class Model : FluentNHibernate.PersistenceModel
    {
        public Model()
        {
            //addMapping(new AbonentMap());
            //addMapping(new PrivateAbonentMap());
            //addMapping(new PriceMap());
            //addMapping(new CorporateAbonentMap());
            //addMapping(new NumberMap());
            //addMapping(new RateMap());
            //addMapping(new BillMap());
            //addMapping(new CallMap());
            //this.Configure(
            //    new NHibernate.Cfg.Configuration().AddFile("hibernate.cfg.xml")
            //        );
            addMappingsFromAssembly(typeof(RVGlib.Mappings.AbonentMap).Assembly);
        }
    }
}
