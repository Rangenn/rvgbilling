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
        IDBStrategy _Strategy;
        List<DBAbstractObject> _Items;
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
        public virtual DBAbstractObject getAt(int index)
        {
            return _Items[index];
        }
        /// <summary>
        /// получить элемент по ID
        /// </summary>
        public virtual DBAbstractObject getItem(int id)
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
        public virtual void addItem(DBAbstractObject item) { _Strategy.AddItemToDB(item); }
        /// <summary>
        /// обновить элемент
        /// </summary>
        public virtual void updateItem(DBAbstractObject item) { _Strategy.UpdateItemToDB(item); }
        /// <summary>
        /// удалить элемент
        /// </summary>
        public virtual void removeItem(DBAbstractObject item) { _Strategy.RemoveItemFromDB(item); }
        /// <summary>
        /// заполнить по запросу
        /// </summary>
        public virtual void fillByQuery(string query) { }


    }
}
