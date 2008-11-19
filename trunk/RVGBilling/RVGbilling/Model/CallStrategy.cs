using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace RVGbilling.Model
{
    public class CallStrategy : IDBStrategy
    {
        private SqlConnection _Connection;
        string query = "select * from calls where ";

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public CallStrategy()
        {
            //throw new System.NotImplementedException();
        }


        public void setConnection(SqlConnection conn) { }

        public List<DBAbstractObject> getFromDB(string query) { return null; }

        public void AddItemToDB(DBAbstractObject item) { }

        public void UpdateItemToDB(DBAbstractObject item) { }

        public void RemoveItemFromDB(DBAbstractObject item) { }
    }
}
