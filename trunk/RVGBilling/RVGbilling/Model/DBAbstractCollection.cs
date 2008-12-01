using System;
using System.Collections.Generic;
using System.Text;

namespace RVGbilling.Model
{
    /// <summary>
    /// Коллекция объектов, ассоциированная  с таблицой БД через стратегию
    /// </summary>
    public abstract class DBAbstractCollection
    {
        #region <fields>

        IDBStrategy _Strategy = null;
        List<DBAbstractObject> _Items;

        #endregion
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DBAbstractCollection()
        {
            _Items = new List<DBAbstractObject>();
        }
        /// <summary>
        /// Конструктор с заполнением массива элементов и выбором стратегии
        /// </summary>
        /// <param name="list"></param>
        /// <param name="strategy"></param>
        public DBAbstractCollection(List<DBAbstractObject> list, IDBStrategy strategy)
        {
            _Items = new List<DBAbstractObject>(list);
            setStrategy(strategy);
        }
        /// <summary>
        /// заполнить по запросу
        /// </summary>
        public void fillByQuery(string query)
        {
            _Items = _Strategy.getFromDB(query);
        }
        /// <summary>
        /// получить ссылку на стратегию
        /// </summary>
        public IDBStrategy getStrategy()
        {
            return _Strategy; 
        }
        /// <summary>
        /// Установить стратегию
        /// </summary>
        /// <param name="strategy"></param>
        public void setStrategy(IDBStrategy strategy) 
        {
            _Strategy = strategy;
        }
        /// <summary>
        /// получить элемент по индексу
        /// </summary>
        public DBAbstractObject getAt(int index)
        {
            return _Items[index];
        }
        /// <summary>
        /// получить элемент по ID
        /// </summary>
        public DBAbstractObject getItem(int id)
        {
            //IDBObject res = null;
            foreach (DBAbstractObject i in _Items)
            {
                if (i.getId() == id) return i;
            }
            return null;
        }     
        /// <summary>
        /// добавить элемент в коллекцию
        /// </summary>
        public void addItem(DBAbstractObject item)
        {
            _Strategy.AddItemToDB(item);
            //if no exception
            _Items.Add(item);
        }
        /// <summary>
        /// удалить элемент
        /// </summary>
        public void removeItem(DBAbstractObject item)
        {
            _Strategy.RemoveItemFromDB(item);
            _Items.Remove(item);
        }
        /// <summary>
        /// обновить элемент
        /// </summary>
        public virtual void updateItem(DBAbstractObject item)
        {
            _Strategy.UpdateItemToDB(item);
        }
    }
}
