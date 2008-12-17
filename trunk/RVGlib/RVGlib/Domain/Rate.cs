using System;

using FluentNHibernate.Framework;
using System.Collections.Generic;

namespace RVGlib.Domain
{
    /// <summary>
    /// Тарифный план
    /// </summary>
    public class Rate : Entity
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Rate()
        {
            Prices = new List<Price>();
        }
        /// <summary>
        /// Название
        /// </summary>
        public virtual String       name { get; set; }
        /// <summary>
        /// Список цен соединений
        /// </summary>
        public virtual IList<Price> Prices { get; private set; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
