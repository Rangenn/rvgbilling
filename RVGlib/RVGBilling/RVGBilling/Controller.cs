using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RVGlib.Domain;
using RVGlib.Framework;

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

        public PrivateAbonent AddPrivateAbonent(string surname, string name, string patronymic, string passportSeria, string passportNumber, DateTime passportDate, string passportDepartament)
        {
            var abonent = new PrivateAbonent
            {
                address = "address",
                phone = "contact phone",
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
            connector.Save<PrivateAbonent>(abonent);
            return abonent;
        }

        public PrivateAbonent AddPrivateAbonent(string surname, string name, string patronymic, string passportSeria, string passportNumber, DateTime passportDate, string passportDepartament, string phonenumber)
        {
            var Abonent = this.AddPrivateAbonent(surname, name, patronymic, passportSeria, passportNumber, passportDate, passportDepartament);
            
            var number = new Number
            {
                abonent = Abonent,
                number = phonenumber,
                rate = GetDefaultRate()
            };
            Abonent.Numbers.Add(number);
            connector.Update<PrivateAbonent>(Abonent);
            formAbonent = new FormAbonent(this, Abonent);
            formAbonent.Show();
            return Abonent;
        }


        public FormAbonent fmAbonent
        {
            get { return formAbonent; }
        }

        public DBConnector conn
        {
            get { return connector; }
        }

    }
}
