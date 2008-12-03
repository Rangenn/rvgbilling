using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;

namespace RVGbilling.Model
{
    public class CallStrategy : IDBStrategy
    {
        private NpgsqlConnection _Connection;
        string query = "select * from calls where ";

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public CallStrategy()
        {
            //throw new System.NotImplementedException();
        }


        public void setConnection(NpgsqlConnection conn) { }

        public List<DBAbstractObject> getFromDB(string query) { return null; }

        public int addItemToDB(DBAbstractObject item) { return -1; }

        public void updateItemToDB(DBAbstractObject item) { }

        public void removeItemFromDB(DBAbstractObject item) { }
        //Model.DBConnector dbc= new Model.DBConnector();
        //    Npgsql.NpgsqlConnection conn = dbc.getConnection();
        //    conn.Open();
        //    Npgsql.NpgsqlCommand command = conn.CreateCommand();
        //    command.CommandText = "select count(*) from customers";
        //    Npgsql.NpgsqlDataReader dr = command.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        for (int i = 0; i < dr.FieldCount; i++)
        //        {
        //            label6.Text = dr[i].ToString(); //.Write("{0} \t", dr[i]);
        //        }
        //        Console.WriteLine();
        //    }
        //    conn.Close();
    }
}
