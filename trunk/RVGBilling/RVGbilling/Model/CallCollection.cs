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
            Strategy = new CallStrategy();
        }

        public CallCollection(List<DBAbstractObject> list)
            : base(list)
        {
            Strategy = new CallStrategy();
        }

        #region DBAbstractCollection Members

        public override void updateItem(DBAbstractObject item)
        {
            this.Strategy.updateItemToDB(item);
            Call call = ((Call)getItem(item.Id));
            Call tmp = (Call)item;
            call.Cost = tmp.Cost;
            call.Duration = tmp.Duration;
            call.NumberToCall = tmp.NumberToCall;
            call.StartTime = tmp.StartTime;
        }

        #endregion
    }
}
