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
        public virtual DateTime creation_time { get; set; }

        public virtual string[] ToStringArray()
        {
            return new string[] { number.number, money.ToString(), creation_time.ToString() };
        }
    }
}
