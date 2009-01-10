using System;

using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    /// <summary>
    /// Телефонное оединение
    /// </summary>
    public class Call : Entity
    {
        /// <summary>
        /// Номер исходящего
        /// </summary>
        public virtual Number number { get; set; }
        /// <summary>
        /// Номер входящего
        /// </summary>
        public virtual String   calling_number { get; set; }
        /// <summary>
        /// Время начала соединения
        /// </summary>
        public virtual DateTime creation_time { get; set; }
        /// <summary>
        /// Длительность, сек
        /// </summary>
        public virtual int  duration { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public virtual Decimal  cost { get; set; }
    }
}
