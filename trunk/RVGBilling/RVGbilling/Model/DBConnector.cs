using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RVGbilling.Model
{
    class DBConnector
    {
        private SqlConnection _Connection;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public DBConnector()
        {
            EstablishConnection();           
        }
        /// <summary>
        /// Установить соединение с БД
        /// </summary>
        void EstablishConnection()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb["User ID"] = "root";
            sb["Password"] = "postgre";
            sb["server"] = "localhost";
            _Connection = new SqlConnection(sb.ConnectionString);
        }

        /// <summary>
        /// получить ссылку на Connection
        /// </summary>
        public SqlConnection getConnection()
        {
            if (_Connection == null)
                EstablishConnection();// throw new Exception("Emana! кто закрыл connection???");
            return _Connection;
        }
        
    }
}
