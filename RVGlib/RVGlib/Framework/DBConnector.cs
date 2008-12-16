using System;
using System.Collections.Generic;

using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace RVGlib.Framework
{
    public class DBConnector
    {
        protected SessionSource SessionSource { get; set; }
        protected ISession session;
        public ISession Session { 
            get 
            {
                if (session == null)
                    session=SessionSource.CreateSession();
                return session;
            }
            set
            {
                session = value;
            }
        }

        public DBConnector()
        {
            SessionSource = new SessionSource(new Model());
            Session = SessionSource.CreateSession();
        }

        public T Get<T>(Int64 id) where T:Entity
        {
            ITransaction trans=Session.BeginTransaction();
            T res=Session.Get<T>(id);
            trans.Commit();
            return res;
        }

        public void Save(Entity en)
        {
            ITransaction trans = Session.BeginTransaction();
            Session.Save(en);
            trans.Commit();
        }

        public void Delete(Entity en)
        {
            //Session = SessionFactory.GetCurrentSession();
            ITransaction trans = Session.BeginTransaction();
            Session.Delete(en);
            trans.Commit();
        }

        public void Update(Entity en)
        {
            //Session = SessionFactory.GetCurrentSession();
            ITransaction trans = Session.BeginTransaction();
            Session.Update(en);
            trans.Commit();
        }

        public IList<T> GetAll<T>() where T : Entity
        {
            //Session = SessionFactory.GetCurrentSession();
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(T));
            //if (SortBy != null) crit.addOrder(Order.asc(SortBy));
            IList<T> res = crit.List<T>();

            trans.Commit();
            return res;
        }

        /*public Abonent SearchByNumber(string Number)
        {
            Session = SessionSource.CreateSession();
            Session.Flush();
            Session.Clear();
            ICriteria crit = Session.CreateCriteria(typeof(Abonent))
                .CreateAlias("Numbers", "n")
                .Add(Expression.Like("n.number", Number, MatchMode.Anywhere));
            IList<Abonent> res = crit.List<Abonent>();
            if (res.Count != 1) return null;
            return res[0];
            ISessionFactory 
        }*/

    }
}
