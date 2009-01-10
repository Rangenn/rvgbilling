using FluentNHibernate.Framework;
using FluentNHibernate.Cfg;
using NHibernate;
using NUnit.Framework;
using System;

namespace RVGLibTest
{
    public class BaseFixture
    {
        protected FluentNHibernate.Framework.SessionSource SessionSource { get; set; }
        protected NHibernate.ISession Session { get; private set; }

        protected DateTime TestDateTime = DateTime.Today;
        protected Decimal TestDecimal = new Decimal(1.123);
        protected Int64 TestInt64 = 1;
        protected Boolean TestBoolean = false;

        [SetUp]
        public void SetupContext()
        {
            BeforeEachTest();
        }

        [TearDown]
        public void TearDownContext()
        {
            AfterEachTest();
        }

        protected virtual void BeforeEachTest()
        {
            //var cfg = FluentNHibernate.Cfg.PostgreSQLConfiguration.
            //FluentNHibernate.Cfg.PostgreSQLConfiguration.Standard.ToProperties();
            //var _Connection = new NpgsqlConnection(sb.ConnectionString);
            //PostgreSQLConfiguration.PostgreSQL82.Dialect("NHibernate.Dialect.PostgreSQLDialect");
            //NHibernate.Cfg.Configuration c = new NHibernate.Cfg.Configuration();
            //Server=localhost;initial catalog=nhibernate;User ID=nhibernate;Password=********;

            //PostgreSQLConfiguration.PostgreSQL82.ConnectionString.Is("USER ID=postgres;PASSWORD=root;HOST=localhost;initial catalog=billing");
            //PostgreSQLConfiguration.PostgreSQL82.ToProperties(),

            SessionSource = new SessionSource(new RVGlib.Framework.Model());
            Session = SessionSource.CreateSession();
            //SessionSource.BuildSchema(Session);
            CreateInitialData(Session);
            Session.Flush(); 
            Session.Clear();
        }

        protected virtual void AfterEachTest()
        {
            Session.Close();
            Session.Dispose();
        }

        protected virtual void CreateInitialData(ISession session)
        {
        }
    }
}
