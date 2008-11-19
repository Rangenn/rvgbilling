using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    /// <summary>
    /// Объект БД
    /// </summary>
    public abstract class DBAbstractObject
    {
        /// <summary>
        /// ID
        /// </summary>
        protected int id;
        /// <summary>
        /// Получить ID объекта
        /// </summary>
        /// <returns>ID</returns>
        public int getId() { return id; }
        //выяснить, нафига он такой нужен? см.ниже
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public DBAbstractObject(int id) { this.id = id; }
    }
}
