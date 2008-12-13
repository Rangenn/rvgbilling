using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;

namespace RVGbilling.Model
{
    class DBConnector
    {
        private NpgsqlConnection _Connection;
        
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
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb["User ID"] = "postgres";
            sb["Password"] = "root";
            sb["Server"] = "localhost";
            sb["Database"] = "billing";
            _Connection = new NpgsqlConnection(sb.ConnectionString);
            logger.log(sb.ConnectionString);
        }

        /// <summary>
        /// получить ссылку на Connection
        /// </summary>
        public NpgsqlConnection Connection
        {
            get
            {
                if (_Connection == null)
                    EstablishConnection();// throw new Exception("Emana! кто закрыл connection???");
                return _Connection;
            }
        }

        /// <summary>
        /// ExecuteNonQuery command. not tested!
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="command"></param>
        public void executeCommand(NpgsqlCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed) _Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex) { logger.log(ex.ToString()); }
            finally
            {
                _Connection.Close();
            }
        }
    }
}
