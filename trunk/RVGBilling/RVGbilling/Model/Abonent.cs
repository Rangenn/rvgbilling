using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    class Abonent : DBAbstractObject
    {
        #region <fields>

        protected string    _Address;
        protected string    _Phone;
        protected string    _MailAddress;
        protected DateTime  _RegTime;
        protected DateTime  _LastPayDate;
        protected Decimal     _Balance;

        #endregion

        #region <props>

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string MailAddress
        {
            get { return _MailAddress; }
            set { _MailAddress = value; }
        }
        public DateTime RegTime
        {
            get { return _RegTime; }
            set { _RegTime = value; }
        }
        public DateTime LastPayDate
        {
            get { return _LastPayDate; }
            set { _LastPayDate = value; }
        }
        public Decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        #endregion

        #region <constructors>

        public Abonent()
            : base()
        {

        }

        public Abonent(int id)
            : base(id)
        {

        }

        public Abonent(Abonent obj)
            : base(obj)
        {
            //this(obj._id, obj._Address, obj._Phone, obj._MailAddress, obj._RegTime, obj._LastPayDate, obj._Balance);
            _Address = obj._Address;
            _Phone = obj._Phone;
            _MailAddress = obj._MailAddress;
            _RegTime = obj._RegTime;
            _LastPayDate = obj._LastPayDate;
            _Balance = obj._Balance;
        }

        public Abonent(int id, string address,string phone, string mailAddress, DateTime regTime, 
            DateTime lastPayDate, Decimal balance)
        {
            Id = id;
            _Address = address;
            _Phone = phone;
            _MailAddress = mailAddress;
            _RegTime = regTime;
            _LastPayDate = lastPayDate;
            _Balance = balance;

        }

        #endregion

        /// <summary>
        /// Сравнить с объектом
        /// </summary>
        public override bool Equals(object obj)
        {
            try
            {
                Abonent item = (Abonent)obj;           
                return Id.Equals(item.Id) && _Address.Equals(item.Address) && _Phone.Equals(item.Phone)
                     && _MailAddress.Equals(item.MailAddress) && _RegTime.Equals(item.RegTime)
                     && _LastPayDate.Equals(item.LastPayDate) && _Balance.Equals(item.Balance);
            }
            catch (InvalidCastException ex)
            {
                logger.log(ex.ToString());
                return false;
            }
        }
    }
}
