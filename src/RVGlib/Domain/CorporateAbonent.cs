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

        public override string[] ToStringArray()
        {
            string[] res = new string[] { corporate_name, INN };
            string[] buf = base.ToStringArray();
            Array.Resize(ref res, res.Length + buf.Length);
            for (int i = 0; i < buf.Length; i++)
            {
                res[res.Length - i - 1] = buf[buf.Length - i - 1];
            }
            return res;
        }
    }
}
