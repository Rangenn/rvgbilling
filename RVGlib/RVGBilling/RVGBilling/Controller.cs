using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RVGlib.Domain;
using RVGlib.Framework;
using System.Windows.Forms;
using NHibernate;

namespace RVGBilling
{
    /// <summary>
    /// Main controller
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Главная форма
        /// </summary>
        FormMain formMain;
        /// <summary>
        /// Форма для работы с абонентами
        /// </summary>
        FormAbonent formAbonent;
        /// <summary>
        /// Объект для работы с базой данных
        /// </summary>
        DBConnector connector;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public Controller()
        {
            logger.log("Creating Controller...");
            connector = new DBConnector();
            formMain = new FormMain(this);
            formMain.Show();
            connector.GetAll<Abonent>();
            logger.log("Controller Created.");

        }
        
        public FormMain fmMain
        {
            get { return formMain; }
        }

        public FormAbonent fmAbonent
        {
            get { return formAbonent; }
        }

        public DBConnector conn
        {
            get { return connector; }
        }

        /// <summary>
        /// вызов диалога для добавления частного лица
        /// </summary>
        public void AddPerson()
        {
            PrivateAbonent ab = new PrivateAbonent();
            AddPrivateAbonentForm fm = new AddPrivateAbonentForm(ab);
            if (fm.ShowDialog() == DialogResult.OK)
            {                
                AddAbonent(ab);               
            }
        }

        /// <summary>
        /// вызов диалога для добавления юридического лица
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="Phone"></param>
        public void AddCorporate()
        {
            CorporateAbonent ab = new CorporateAbonent();
            AddCorporateAbonentForm fm = new AddCorporateAbonentForm(ab);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                AddAbonent(ab);
            }
        }

        public Abonent AddAbonent(Abonent abonent)
        {
            connector.Save(abonent);
            formAbonent = new FormAbonent(this, abonent);
            formAbonent.Show();
            return abonent;
        }

        /// <summary>
        /// Функция для пополнения баланса
        /// </summary>
        /// <param name="number"></param>
        /// <param name="summa"></param>
        public void Payment(string number, decimal summa)
        {
            Abonent abonent = connector.SearchByNumber(number);
            string s = "Пополнить баланс на сумму ";          
            if (abonent == null) 
            {
                MessageBox.Show("Данный номер не зарегистрирован");
                return;
            }
            s += summa.ToString() + " на имя: ";
            if (abonent is PrivateAbonent)
                s += ((PrivateAbonent)abonent).surname + " " + ((PrivateAbonent)abonent).name + " " + ((PrivateAbonent)abonent).patronymic + '?';
            if (abonent is CorporateAbonent)
                s += ((CorporateAbonent)abonent).corporate_name+'?';
            if (MessageBox.Show(s, "Пополнение баланса", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                abonent.balance += summa;
                connector.Update(abonent);
                //MessageBox.Show("Вы успешно пополнили баланс.\n Номер: " + number + "\n Сумма: " + summa.ToString());
            }
        }

        /// <summary>
        /// Поиск частных лиц
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passport"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public IList<PrivateAbonent> SearchPerson(string name, string passport, string phone)
        {
            return connector.SearchPerson(name, passport, phone);
        }

        public void ViewAbonent(Abonent ab)
        {
            formAbonent = new FormAbonent(this, ab);
            fmAbonent.ShowDialog();
        }

        /// <summary>
        /// выбор частного листа
        /// </summary>
        /// <param name="id"></param>
        public void SelectPerson(long id)
        {
            PrivateAbonent abonent = connector.Get<PrivateAbonent>(id);
            formAbonent = new FormAbonent(this, abonent);
            fmAbonent.ShowDialog();
        }

        /// <summary>
        /// поиск юричических лиц
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public IList<CorporateAbonent> SearchCoporate(string name, string address, string phone)
        {
            return connector.SearchCorporate(name, address, phone);
        }

        /// <summary>
        /// выбор юричического лица
        /// </summary>
        /// <param name="id"></param>
        public void SelectCorporate(int id)
        {
            CorporateAbonent abonent = connector.Get<CorporateAbonent>(id);
            formAbonent = new FormAbonent(this, abonent);
            fmAbonent.ShowDialog();
        }

        public IList<Call> GetCalls(Number number,DateTime start, DateTime end)
        {
            IList<Call> list = connector.GetCalls(number, start, end);
            return list;
        }

        public IList<Rate> GetRates()
        {
            return connector.GetAll<Rate>();
            //return connector.GetRates();
        }

        public void ViewRates()
        {
            FormRateList form = new FormRateList(this);
            form.Show();
        }

        public void AddPrice(Rate r)
        {
            Price p = new Price
            {
                rate = r,
                mask = "<Маска>",
                cost_per_minute = 1
            };
            FormPrice form = new FormPrice(p);
            if (form.ShowDialog() == DialogResult.OK)
            {
                r.Prices.Add(p);
                conn.Update(r);
            }
        }

        public void EditPrice(Price pr)
        {
            FormPrice form = new FormPrice(pr);
            if (form.ShowDialog() == DialogResult.OK)
            {
                conn.Update(pr);
            }
        }

        // не работает, зараза!
        public void DeletePrice(Price pr)
        {
            if (MessageBox.Show("Удалить маску " + pr.mask, "Удаление цены",
            MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) 
            {
                conn.Delete(pr);
            }
        }

    }
}
