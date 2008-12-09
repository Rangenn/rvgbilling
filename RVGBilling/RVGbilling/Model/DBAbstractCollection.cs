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
        public DBAbstractCollection(List<DBAbstractObject> list)
        {
            _Items = new List<DBAbstractObject>(list);
            //setStrategy(strategy);
        }
        /// <summary>
        /// заполнить по запросу
        /// </summary>
        public void fillByQuery(string query)
        {
            _Items = _Strategy.getFromDB(query);
        }
        /// <summary>
        /// Стратегия
        /// </summary>
        public IDBStrategy Strategy
        {
            get { return _Strategy; }
            set { _Strategy = value; }
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
                if (i.Id == id) return i;
            }
            return null;
        }
        /// <summary>
        /// проверить элемент на вхождение в коллекцию
        /// </summary>
        public bool containsItem(DBAbstractObject item)
        {
            foreach (DBAbstractObject i in _Items)
            {
                if (i.Equals(item)) return true;
            }
            return false;
        }
        /// <summary>
        /// добавить элемент в коллекцию
        /// </summary>
        public void addItem(DBAbstractObject item)
        {
            if (containsItem(item)) return;
            item.Id =_Strategy.addItemToDB(item);//получаем id, сгенерированный СУБД при добавлении записи
            //if no exception
            _Items.Add(item);
        }
        /// <summary>
        /// удалить элемент
        /// </summary>
        public void removeItem(DBAbstractObject item)
        {
            if (!containsItem(item)) return;
            _Strategy.removeItemFromDB(item);
            _Items.Remove(item);
        }
        /// <summary>
        /// обновить элемент
        /// </summary>
        public virtual void updateItem(DBAbstractObject item)
        {
            if (!containsItem(item)) return;
            _Strategy.updateItemToDB(item);
        }
    }
}
