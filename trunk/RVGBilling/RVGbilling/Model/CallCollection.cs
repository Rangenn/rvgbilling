using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVGbilling.Model
{
    class CallCollection : DBAbstractCollection
    {
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public CallCollection()
        {
            throw new System.NotImplementedException();
        }
        #region IObjectCollection Members


        public DBAbstractObject getAt(int index)
        {
            throw new NotImplementedException();
        }

        public DBAbstractObject getItem(int id)
        {
            throw new NotImplementedException();
        }

        public override void addItem(DBAbstractObject item)
        {
            base.addItem(item);
            throw new NotImplementedException();
        }

        public void updateItem(DBAbstractObject item)
        {
            throw new NotImplementedException();
        }

        public void removeItem(DBAbstractObject item)
        {
            throw new NotImplementedException();
        }

        public void fillByQuery(string query)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
