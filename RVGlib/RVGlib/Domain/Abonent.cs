using System;
using System.Collections.Generic;

using FluentNHibernate.Framework;
using System.ComponentModel;
//using Iesi.Collections.Generic;

namespace RVGlib.Domain
{
    /// <summary>
    /// Абонент
    /// </summary>
    public class Abonent : Entity
    {
        /// <summary>
        /// Адрес
        /// </summary>
        public virtual String   address { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public virtual String   phone { get; set; }
        /// <summary>
        /// E-mail
        /// </summary>
        public virtual String   mail_address { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public virtual DateTime reg_time { get; set; }
        /// <summary>
        /// Дата последнего платежа
        /// </summary>
        public virtual DateTime last_pay_date { get; set; }
        /// <summary>
        /// Баланс счета
        /// </summary>
        public virtual Decimal  balance { get; set; }

        /// <summary>
        /// Договор расторгнут
        /// </summary>
        public virtual Boolean dissolved { get; set; }

        [Bindable(false)]
        /// <summary>
        /// Номера
        /// </summary>
        public virtual IList<Number> Numbers { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Abonent()
        {
            Numbers = new List<Number>();
        }
    }
    
}
