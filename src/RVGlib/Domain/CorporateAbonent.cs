using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Framework;

namespace RVGlib.Domain
{
    /// <summary>
    /// Абонент - юр.лицо
    /// </summary>
    public class CorporateAbonent : Abonent
    {
        /// <summary>
        /// Название юр.лица
        /// </summary>
        public virtual String corporate_name { get; set; }

        public virtual String INN { get; set; }
    }
}
