using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    class CorporateAbonentCollection : AbonentCollection
    {
        public CorporateAbonentCollection()
            : base()
        {
            Strategy = new CorporateAbonentStrategy();
        }

        public CorporateAbonentCollection(List<DBAbstractObject> list)
            : base(list)
        {
            Strategy = new CorporateAbonentStrategy();
        }

        public override void updateItem(DBAbstractObject item)
        {
            this.Strategy.updateItemToDB(item);
            CorporateAbonent buf = (CorporateAbonent)this.getItem(item.Id);
            CorporateAbonent obj = (CorporateAbonent)item;
            buf.Address = obj.Address;
            buf.Phone = obj.Phone;
            buf.MailAddress = obj.MailAddress;
            buf.RegTime = obj.RegTime;
            buf.LastPayDate = obj.LastPayDate;
            buf.Balance = obj.Balance;
            buf.CorporationName = obj.CorporationName;
        }
    }
}
