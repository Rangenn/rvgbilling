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
        protected int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        ///// <summary>
        ///// Получить ID объекта
        ///// </summary>
        ///// <returns>ID</returns>
        //public int getId() { return _id; }
        ///// <summary>
        ///// Установить ID объекта
        ///// </summary>
        ///// <returns>ID</returns>
        //public void setId(int value) { _id = value; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public DBAbstractObject()
        {
            _id = -1;//?!
        }

        public DBAbstractObject(int id)
        {
            this._id = id;
        }
        public DBAbstractObject(DBAbstractObject obj)
        {
            //this(id);
            this._id = obj._id;
        }
        ///// <summary>
        ///// Сравнить с объектом
        ///// </summary>
        //public override bool Equals(object obj)
        //{
        //    //return base.Equals(obj);
        //    try
        //    {
        //        return _id.Equals(((DBAbstractObject)obj).getId());
        //    }
        //    catch (InvalidCastException ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
