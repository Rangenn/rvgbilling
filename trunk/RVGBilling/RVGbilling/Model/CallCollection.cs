using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    class CallCollection : DBAbstractCollection
    {

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public CallCollection()
            : base()
        {
            
        }

        public CallCollection(List<DBAbstractObject> list, IDBStrategy strategy)
            : base(list, strategy)
        {

        }

        #region DBAbstractCollection Members

        public override void updateItem(DBAbstractObject item)
        {
            base.updateItem(item);
            Call call = ((Call)getItem(item.Id));
            Call tmp = (Call)item;
            call.setCost(tmp.getCost());
            call.setDuration(tmp.getDuration());
            call.setNumberToCall(tmp.getNumberToCall());
            call.setStartTime(tmp.getStartTime());
        }

        #endregion
    }
}
