using System;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    /// <summary>
    /// Платеж
    /// </summary>
    public class Bill : Entity
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        public virtual Number   number  { get; set; }
        /// <summary>
        /// Сумма платежа
        /// </summary>
        public virtual Decimal  money { get; set; }
        /// <summary>
        /// Дата оплаты
        /// </summary>
        public virtual DateTime bill_date { get; set; }
    }
}
