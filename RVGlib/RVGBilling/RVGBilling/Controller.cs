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
    public class Controller
    {
        FormMain formMain;
        FormAbonent formAbonent;
        DBConnector connector;

        public Controller()
        {
            logger.log("Creating Controller...");
            connector = new DBConnector();
            formMain = new FormMain(this);
            formMain.Show();
            //Int64 id=5;
            //formAbonent = new FormAbonent(this,id);
            //formAbonent.Show();
            logger.log("Controller Created.");

        }
        
        public FormMain fmMain
        {
            get { return formMain; }
        }


        public Rate GetDefaultRate()
        {
            return (Rate)connector.Get<Rate>(1);
        }

        public void AddPerson()
        {
            AddPrivateAbonentForm fm = new AddPrivateAbonentForm(this);
            fm.Show();
        }

        public void AddCorporate(string Name, string Address, string Phone)
        {
            AddCorporateAbonentForm fm = new AddCorporateAbonentForm(this);
            fm.Show();
        }

        public PrivateAbonent AddPrivateAbonent(string surname, string name, string patronymic, string passportSeria, string passportNumber, DateTime passportDate, string passportDepartament, string phonenumber)
        {
            var abonent = new PrivateAbonent
            {
                address = "address",
                phone = phonenumber,
                mail_address = "e-mail",
                reg_time = DateTime.Today,
                last_pay_date = DateTime.Today,
                balance = new Decimal(100),
                name = name,
                surname = surname,
                patronymic = patronymic,
                passport_series = passportSeria,
                passport_date = passportDate,
                passport_department = passportDepartament,
                birth_date = DateTime.Today//добавить поле для ДР
            };
            connector.Save(abonent);
            formAbonent = new FormAbonent(this, abonent);
            formAbonent.Show();
            return abonent;
        }

        public FormAbonent fmAbonent
        {
            get { return formAbonent; }
        }

        public DBConnector conn
        {
            get { return connector; }
        }

        public CorporateAbonent AddCorporateAbonent(string Name, string Address, string Phone, string Email)
        {
            var abonent = new CorporateAbonent
            {
                address = Address,
                balance = 100,
                corporate_name = Name,
                last_pay_date = DateTime.Today,
                mail_address = Email,
                phone = Phone,
                reg_time = DateTime.Today
            };
            connector.Save(abonent);
            formAbonent = new FormAbonent(this, abonent);
            formAbonent.Show();
            return abonent;
        }

        public void Payment(string number, decimal summa)
        {
            Abonent abonent = connector.SearchByNumber(number);
            if (abonent == null)
            {
                MessageBox.Show("Данный номер не зарегистрирован");
                return;
            }
            abonent.balance += summa;
            connector.Update(abonent);
            MessageBox.Show("Вы успешно пополнили баланс.\n Номер: " + number + "\n Сумма: " + summa.ToString());
        }

        public IList<PrivateAbonent> SearchPerson(string name, string passport, string phone)
        {
            return connector.SearchPerson(name, passport, phone);
        }

        public void SelectPerson(long id)
        {
            PrivateAbonent abonent = connector.Get<PrivateAbonent>(id);
            formAbonent = new FormAbonent(this, abonent);
            fmAbonent.Show();
        }

        internal IList<CorporateAbonent> SearchCoporate(string name, string address, string phone)
        {
            return connector.SearchCorporate(name, address, phone);
        }

        internal void SelectCorporate(int id)
        {
            CorporateAbonent abonent = connector.Get<CorporateAbonent>(id);
            formAbonent = new FormAbonent(this, abonent);
            fmAbonent.Show();
        }
    }
}
