using System;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    /// <summary>
    /// Цена
    /// </summary>
    public class Price : Entity
    {
        /// <summary>
        /// Тариф
        /// </summary>
        public virtual Rate     rate { get; set; }
        /// <summary>
        /// Стоимость минуты соединения
        /// </summary>
        public virtual Decimal  cost_per_minute { get; set; }
        /// <summary>
        /// Маска телефонных номеров
        /// </summary>
        public virtual String   mask { get; set; }
    }
}
