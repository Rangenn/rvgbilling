using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    class CorporateAbonent : Abonent
    {
        #region <fields>

        protected string _CorporationName;

        #endregion

        #region <props>

        public string CorporationName
        {
            get { return _CorporationName; }
            set { _CorporationName = value; }
        }

        #endregion

        #region <constructors>

        public CorporateAbonent(int id)
            : base(id)
        {

        }

        public CorporateAbonent(CorporateAbonent obj)
            : base(obj)
        {
            _CorporationName = obj._CorporationName;
        }

        public CorporateAbonent(int id, string address, string phone, string mailAddress, DateTime regTime, 
            DateTime lastPayDate, Decimal balance, string corporationName) : base(id, address, phone, mailAddress, regTime, lastPayDate, balance)
        {
            _CorporationName = corporationName;
        }

        #endregion
    }
}
