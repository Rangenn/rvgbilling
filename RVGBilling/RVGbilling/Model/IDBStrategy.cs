using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RVGbilling.Model
{
    /// <summary>
    /// Стратегия работы с БД
    /// </summary>
    public interface IDBStrategy 
    {
        /// <summary>
        /// Установить ссылку на подключение к БД
        /// </summary>
        /// <param name="conn">Connection</param>
        void setConnection(SqlConnection conn);
        /// <summary>
        /// Получить из БД массив данных
        /// </summary>
        /// <param name="query">строка запроса</param>
        /// <returns>список выбранных объектов</returns>
        List<DBAbstractObject> getFromDB(string query);
        /// <summary>
        /// Добавить элемент в таблицу БД
        /// </summary>
        /// <param name="item">элемент</param>
        void AddItemToDB(DBAbstractObject item);
        /// <summary>
        /// Обновить элемент в таблице БД
        /// </summary>
        /// <param name="item">элемент</param>
        void UpdateItemToDB(DBAbstractObject item);
        /// <summary>
        /// Удалить элемент из таблицы БД
        /// </summary>
        /// <param name="item">элемент</param>
        void RemoveItemFromDB(DBAbstractObject item);
        

    }
}
