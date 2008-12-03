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
            
        }

        public CorporateAbonentCollection(List<DBAbstractObject> list, IDBStrategy strategy)
            : base(list, strategy)
        {
            CorporateAbonentStrategy test = (CorporateAbonentStrategy)strategy;//проверка типов
        }

        public override void updateItem(DBAbstractObject item)
        {
            this.getStrategy().updateItemToDB(item);
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
