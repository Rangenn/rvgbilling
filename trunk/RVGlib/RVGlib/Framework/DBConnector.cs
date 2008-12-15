using System;
using System.Collections.Generic;

using RVGlib.Domain;
using FluentNHibernate.Framework;
using Iesi.Collections.Generic;
using FluentNHibernate.Cfg;
using NHibernate;

namespace RVGlib.Framework
{
    public class DBConnector
    {
        protected FluentNHibernate.Framework.SessionSource SessionSource { get; set; }
        protected NHibernate.ISession Session { get; private set; }

        //protected DateTime date = DateTime.Today;
        public DBConnector()
        {
            SessionSource = new SessionSource(new Model());
            //Session = SessionSource.CreateSession();
        }

        public T Get<T>(Int64 id) where T:Entity
        {
            Session = SessionSource.CreateSession();
            Session.Flush();
            Session.Clear();
            T res=Session.Get<T>(id);
            Session.Close();
            return res;
        }

        public void Save<T>(Entity en) where T:Entity
        {
            Session = SessionSource.CreateSession();
            Session.Flush();
            Session.Clear();
            Session.Save(en);
            Session.Close();
        }

        public void Delete<T>(Entity en) where T : Entity
        {
            Session = SessionSource.CreateSession();
            Session.Flush();
            Session.Clear();
            Session.Delete(en);
            Session.Close();
        }

        public void Update<T>(Entity en) where T : Entity
        {
            Session = SessionSource.CreateSession();
            Session.Flush();
            Session.Clear();
            Session.Update(en);
            Session.Close();
        }

        public IList<T> GetAll<T>() where T : Entity
        {
            Session = SessionSource.CreateSession();
            Session.Flush();
            Session.Clear();
            ICriteria crit = Session.CreateCriteria(typeof(T));
            //if (SortBy != null) crit.addOrder(Order.asc(SortBy));
            IList<T> res = crit.List<T>();

            Session.Close();
            return res;
        }

    }
}
