using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVGbilling.Model
{
    class PriceStrategy : IDBStrategy
    {
        #region IDBStrategy Members

        public void setConnection(Npgsql.NpgsqlConnection conn)
        {
            throw new NotImplementedException();
        }

        public List<DBAbstractObject> getFromDB(string query)
        {
            throw new NotImplementedException();
        }

        public int addItemToDB(DBAbstractObject item)
        {
            throw new NotImplementedException();
        }

        public void updateItemToDB(DBAbstractObject item)
        {
            throw new NotImplementedException();
        }

        public void removeItemFromDB(DBAbstractObject item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
