using System;
using System.Collections.Generic;
using System.Text;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    /// <summary>
    /// Телефонный номер
    /// </summary>
    public class Number : Entity
    { 
        /// <summary>
        /// Номер
        /// </summary>
        public virtual String number { get; set; }
        /// <summary>
        /// Абонент - владелец
        /// </summary>
        public virtual Abonent abonent { get; set; }
        /// <summary>
        /// Тариф подключения
        /// </summary>
        public virtual Rate rate { get; set; }
        /// <summary>
        /// Список совершенных соединений
        /// </summary>
        public virtual IList<Call> Calls { get; private set; }
        /// <summary>
        /// Список платежей
        /// </summary>
        public virtual IList<Bill> Bills { get; private set; }

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Number()
        {
            Calls = new List<Call>();
            Bills = new List<Bill>();
        }
    }
}
