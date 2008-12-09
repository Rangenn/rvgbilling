using System;
using System.Collections.Generic;
using System.Text;


namespace RVGbilling.Model
{
    class AbonentCollection : DBAbstractCollection
    {

        public AbonentCollection()
            : base()
        {
            Strategy = new AbonentStrategy();
        }

        public AbonentCollection(List<DBAbstractObject> list)
            : base(list)
        {
            Strategy = new AbonentStrategy();
        }

        public override void updateItem(DBAbstractObject item)
        {
            this.Strategy.updateItemToDB(item);
            Abonent buf = (Abonent) this.getItem(item.Id);
            Abonent obj = (Abonent)item;
            buf.Address = obj.Address;
            buf.Phone = obj.Phone;
            buf.MailAddress = obj.MailAddress;
            buf.RegTime = obj.RegTime;
            buf.LastPayDate = obj.LastPayDate;
            buf.Balance = obj.Balance;
        }
    }
}
