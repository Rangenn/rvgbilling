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

        ~DBConnector()
        {
            //SessionSource.
            //Session.Flush();
            //Session.Close();

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



        public Abonent SearchByNumber(string Number)
        {
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(Abonent))
                .CreateAlias("Numbers", "n")
                .Add(Expression.Like("n.number", Number, MatchMode.Anywhere));
            IList<Abonent> res = crit.List<Abonent>();
            trans.Commit();
            int i = 0;
            while (i < res.Count)
            {
                if (!((res[i] is PrivateAbonent) || (res[i] is CorporateAbonent)))
                {
                    res.Remove(res[i]);
                    i -= 1;
                }
                i += 1;
            }
            if (res.Count != 1) return null;
            return res[0];
        }

        public IList<PrivateAbonent> SearchPerson(string name, string passport, string phone)
        {
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(PrivateAbonent));

            if (name != "")
            {
                ICriterion cr1 = Expression.Or(
                Expression.Or(
                    Expression.Like("surname", name, MatchMode.Anywhere),
                    Expression.Like("name", name, MatchMode.Anywhere)),
                    Expression.Like("patronymic", name, MatchMode.Anywhere));
                crit.Add(cr1);
            }
            if (passport != "") crit.Add(Expression.Like("passport_series", passport, MatchMode.Anywhere));
            if (phone != "") crit.CreateAlias("Numbers", "n").Add(Expression.Like("n.number", phone, MatchMode.Anywhere));

            IList<PrivateAbonent> ab = crit.List<PrivateAbonent>();
            trans.Commit();
            return ab;
        }

        public IList<CorporateAbonent> SearchCorporate(string name, string address, string phone)
        {
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(CorporateAbonent));

            if (name != "")
            {
                crit.Add(Expression.Like("corporate_name", name, MatchMode.Anywhere));
            }
            if (address != "") crit.Add(Expression.Like("address", address, MatchMode.Anywhere));
            if (phone != "") crit.CreateAlias("Numbers", "n").Add(Expression.Like("n.number", phone, MatchMode.Anywhere));

            IList<CorporateAbonent> ab = crit.List<CorporateAbonent>();
            trans.Commit();
            return ab;
        }

        public IList<Call> GetCalls(Number number, DateTime start, DateTime end)
        {
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(Call));

            ICriterion cr =
                Expression.And(
                Expression.Eq("number", number),
                Expression.Between("start_time",start, end));
            crit.Add(cr);
            IList<Call> res = crit.List<Call>();
            trans.Commit();
            return res;
        }

        public IList<Rate> GetRates()
        {
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(Rate));
            IList<Rate> res = crit.List<Rate>();
            trans.Commit();
            return res;
        }
    }
}