using System;
using System.Collections.Generic;
using System.Linq;
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
                //session = value;
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
            Session.Flush();
            Session.Clear();
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
            Session.Flush();
            Session.Clear();
        }

        public IList<T> GetAll<T>() where T : Entity
        {
            //Session = SessionFactory.GetCurrentSession();
            //Session.CreateQuery("from Abonent").
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(T));
        
            //if (SortBy != null) crit.addOrder(Order.asc(SortBy));
            //IList<T> res = crit.List<T>();
            IList<T> res = crit.List<T>();


            trans.Commit();
            return res;
        }

        public Number GetNumber(string phoneNumber)
        {
            //Session = SessionFactory.GetCurrentSession();
            //Session.CreateQuery("from Abonent").
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(Number)).Add(Expression.Eq("number", phoneNumber));

            //if (SortBy != null) crit.addOrder(Order.asc(SortBy));
            //IList<T> res = crit.List<T>();
            IList<Number> res = crit.List<Number>();

            trans.Commit();
            if (res.Count == 0 || res[0] == null) throw new SearchByNumberException("Не найдено совпадений, номер незарегистрирован.");
            if (res.Count > 1) throw new SearchByNumberException("Найдено несколько совпадений, номер задан некорректно.");
            return res[0];
        }

        //DEPRECATED
        //public Abonent SearchByNumber(string Number)
        //{
        //    //SearchByNumberException.if (Number.Length != 10) throw new SearchByNumberException("Некорректная длина номера.");
        //    ITransaction trans = Session.BeginTransaction();
        //    ICriteria crit = Session.CreateCriteria(typeof(Abonent))
        //        .CreateAlias("Numbers", "n")
        //        .Add(Expression.Like("n.number", Number, MatchMode.Anywhere));
        //    IList<Abonent> res = crit.List<Abonent>();
        //    trans.Commit();
        //    int i = 0;
        //    while (i < res.Count)
        //    {
        //        if (!((res[i] is PrivateAbonent) || (res[i] is CorporateAbonent)))
        //        {
        //            res.Remove(res[i]);
        //            i -= 1;
        //        }
        //        i += 1;
        //    }
        //    if (res.Count == 0 || res[0] == null) throw new SearchByNumberException("Не найдено совпадений, номер незарегистрирован.");
        //    if (res.Count > 1) throw new SearchByNumberException("Найдено несколько совпадений, номер задан некорректно.");
        //    return res[0];
        //}

        /// <summary>
        /// Исключение поиска абонента по номеру.
        /// </summary>
        public class SearchByNumberException : Exception
        {
            public String Message { get { return msg; } }
            private string msg = "Ошибка при поиске по номеру.\n";

            public SearchByNumberException()
                : base()
            {
 
            }

            public SearchByNumberException(string message)
                : base(message)
            {
                this.msg += message;
            }

            public SearchByNumberException(string message, Exception InnerException)
                : base(message, InnerException)
            {
                this.msg += message;
            }

        }

        public IList<PrivateAbonent> SearchPerson(string name, string passport, string phone)
        {
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(PrivateAbonent));
            //crit.SetProjection(Projections.Distinct(Projections.Property("id")));
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
            //crit.SetProjection(Projections.);

            IList<PrivateAbonent> ab = crit.List<PrivateAbonent>().Distinct<PrivateAbonent>().ToList<PrivateAbonent>();
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

            IList<CorporateAbonent> ab = crit.List<CorporateAbonent>().Distinct<CorporateAbonent>().ToList<CorporateAbonent>();
            trans.Commit();
            return ab;
        }

        public IList<Call> GetCalls(Number number, DateTime start, DateTime end)
        {
            return GetDetails<Call>(number, start, end);
        }

        public IList<Bill> GetBills(Number number, DateTime start, DateTime end)
        {
            return GetDetails<Bill>(number, start, end);
        }

        /// <summary>
        /// Метод для детализации. Допустимые значения Т: Call, Bill.
        /// В целях безопасности сделан приватным.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private IList<T> GetDetails<T>(Number number, DateTime start, DateTime end)
        {
            //T test = new T();
            //if (!(test is Call || test is Bill)) throw new InvalidCastException();
            ITransaction trans = Session.BeginTransaction();
            ICriteria crit = Session.CreateCriteria(typeof(T));

            ICriterion cr =
                Expression.And(
                Expression.Eq("number", number),
                Expression.Between("creation_time", start, end));
            crit.Add(cr);
            IList<T> res = crit.List<T>();
            trans.Commit();
            return res;
        }

        public void calculate_call_cost(long call_id)
        {
            ITransaction trans = Session.BeginTransaction();
            Session.CreateSQLQuery("SELECT calculate_call_cost_function(" + call_id.ToString() + ");");
            trans.Commit();
        }

        public void add_bill_money(long bill_id)
        {
            ITransaction trans = Session.BeginTransaction();
            //Session.cre
            Session.CreateSQLQuery("SELECT add_bill_money(" + bill_id.ToString() + ");").ExecuteUpdate();
            trans.Commit();
        }
    }
}