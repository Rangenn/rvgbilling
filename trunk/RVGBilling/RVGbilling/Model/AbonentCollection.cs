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
            
        }

        public AbonentCollection(List<DBAbstractObject> list, IDBStrategy strategy)
            : base(list, strategy)
        {
            //try
            //{
                AbonentStrategy test = (AbonentStrategy)strategy;//проверка типов
            //}
            //catch (InvalidCastException ex)
            //{
            //    logger.log(ex.ToString());
                
            //}
        }

        public override void updateItem(DBAbstractObject item)
        {
            this.getStrategy().updateItemToDB(item);
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
