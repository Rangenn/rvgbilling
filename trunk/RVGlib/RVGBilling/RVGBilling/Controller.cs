using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RVGlib.Domain;
using RVGlib.Framework;
using System.Windows.Forms;
using NHibernate;
using FluentNHibernate.Framework;

using ExcelWorkLib;
using RVGlib.Import;

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
        private DBConnector _connector;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public Controller()
        {
            logger.log("Creating Controller...");
            _connector = new DBConnector();
            formMain = new FormMain(this);
            formMain.Show();
            _connector.GetAll<Abonent>();
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

        public DBConnector Connector
        {
            get { return _connector; }
        }

        /// <summary>
        /// вызов диалога для добавления частного лица
        /// </summary>
        public void AddPrivateAbonent()
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
        public void AddCorporateAbonent()
        {
            CorporateAbonent ab = new CorporateAbonent();
            AddCorporateAbonentForm fm = new AddCorporateAbonentForm(ab);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                AddAbonent(ab);
            }
        }

        protected void AddAbonent(Abonent ab)
        {
            bool err = false;
            if (ab is PrivateAbonent)
            {
                PrivateAbonent buf = (PrivateAbonent)ab;
                err = buf.name == "" || buf.surname == "" || buf.patronymic == "" ||
                    buf.passport_series == "";
            }
            if (ab is CorporateAbonent)
            {
                CorporateAbonent buf = (CorporateAbonent)ab;
                err = buf.corporate_name == "" || buf.INN == "";
            }
            if (err) MessageBox.Show("Введены некорректные данные.");
            else
            {
                _connector.Save(ab);
                ViewAbonent(ab);
            }
        }

        public void ViewAbonent(Abonent ab)
        {
            formAbonent = new FormAbonent(this, ab);
            fmAbonent.ShowDialog();
        }
        /// <summary>
        /// Функция для пополнения баланса
        /// </summary>
        /// <param name="number"></param>
        /// <param name="summa"></param>
        public void Payment(string number, decimal summa)
        {
            Number num = Connector.GetNumber(number);
            Abonent abonent = num.abonent;
            //try
            //{
            //    abonent = Connector.SearchByNumber(number);
            //}
            //catch (DBConnector.SearchByNumberException ex) { MessageBox.Show(ex.Message); return; }
            
            string s = "Пополнить баланс на сумму " + summa.ToString() + " на имя: ";
            if (abonent is PrivateAbonent)
                s += ((PrivateAbonent)abonent).surname + " " + ((PrivateAbonent)abonent).name + " " + ((PrivateAbonent)abonent).patronymic + '?';
            else if (abonent is CorporateAbonent)
                s += ((CorporateAbonent)abonent).corporate_name + '?';
            else return;

            if (MessageBox.Show(s, "Пополнение баланса", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //abonent.balance += summa;
                Bill b = new Bill()
                    {
                        creation_time = DateTime.Now,
                        money = summa,
                        number = num//abonent.Numbers[0]
                    };

                num.Bills.Add(b);
                //abonent.Numbers[0].Bills.Add(b);
                Connector.Update(num);
                Connector.add_bill_money(b.Id);
                //abonent = Connector.Get<Abonent>(abonent.Id);//refreshing нет смысла обновлять абонента, который объявлен локально
            }
        }

        /// <summary>
        /// Поиск частных лиц
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passport"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public IList<PrivateAbonent> SearchPrivateAbonent(string name, string passport, string phone)
        {
            return _connector.SearchPerson(name, passport, phone);
        }


        /// <summary>
        /// выбор частного листа
        /// </summary>
        /// <param name="id"></param>
        public void SelectPerson(long id)
        {
            PrivateAbonent abonent = _connector.Get<PrivateAbonent>(id);
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
        public IList<CorporateAbonent> SearchCorporateAbonent(string name, string address, string phone)
        {
            return _connector.SearchCorporate(name, address, phone);
        }

        /// <summary>
        /// выбор юричического лица
        /// </summary>
        /// <param name="id"></param>
        public void SelectCorporate(long id)
        {
            CorporateAbonent abonent = _connector.Get<CorporateAbonent>(id);
            formAbonent = new FormAbonent(this, abonent);
            fmAbonent.ShowDialog();
        }

        public IList<Call> GetCalls(Number number,DateTime start, DateTime end)
        {
            IList<Call> list = _connector.GetCalls(number, start, end);
            return list;
        }

        public IList<Bill> GetBills(Number number, DateTime start, DateTime end)
        {
            IList<Bill> list = _connector.GetBills(number, start, end);
            return list;
        }

        public IList<Rate> GetRates()
        {
            return _connector.GetAll<Rate>();
        }

        public void ViewRates()
        {
            FormRateList form = new FormRateList(this);
            form.Show();
        }

        public void AddNumber(Abonent ab, BindingSource bs)
        {
            Number num = new Number
            {
                abonent = ab
            };
            FormAddNumber form = new FormAddNumber(num,bs);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ab.Numbers.Add(num);
                //Connector.Save(num);
                Connector.Update(ab);
            }
        }

        public bool AddPrice(Rate r)
        {
            bool res = false;
            Price p = new Price
            {
                rate = r,
                mask = "<Маска>",
                cost_per_minute = 1
            };
            FormPrice form = new FormPrice(p);

            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {


                    if (r.Prices.Contains<Price>(p, new PriceComparer()))
                    {
                        MessageBox.Show("Маска \"" + p.mask + "\" уже существует.");
                    }
                    else
                    {
                        r.Prices.Add(p);
                        Connector.Update(r);
                        res = true;
                    }
                }
            }
            catch (NHibernate.Exceptions.GenericADOException ex) { MessageBox.Show(ex.Message); }
            return res;
        }

        public void EditPrice(Price pr)
        {
            FormPrice form = new FormPrice(pr);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Connector.Update(pr);
            }
        }

        //работает! 
        public bool DeletePriceFromRate(Rate r, Price pr)
        {
            bool res = MessageBox.Show("Удалить маску " + pr.mask + " из тарифа \"" + r.name + "\" ?", "Удаление цены",
            MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK;
            if (res) 
            {
                r.Prices.Remove(pr);
                //conn.Update(r);
                Connector.Delete(pr);
            }
            return res;
        }

        public Rate AddRate()
        {
            Rate r = new Rate
            {
                name = "<Название>"
            };
            FormRate form = new FormRate(r);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Connector.Save(r);
            }
            return r;
        }

        public void EditRate(Rate r)
        {
            FormRate form = new FormRate(r);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Connector.Update(r);
            }
        }

        // работает!
        public bool DeleteRate(Rate rate)
        {
            bool res = MessageBox.Show("Удалить тариф \"" + rate.name+ "\"?", "Удаление тарифа",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
            if (res)
            {
                Connector.Delete(rate);
            }
            return res;
        }

        public void DissolveAbonent(Abonent ab)
        {

            bool res = MessageBox.Show("Расторгнуть договор № " + ab.Id + "?", "Расторжение договора",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
            if (res)
            {
                ab.dissolved = true;
                Connector.Update(ab);
                MessageBox.Show("Баланс на момент расторжения договора: " + ab.balance.ToString());
            }
        }

        public void ViewDetailsForm<T>(IList<T> list) where T:Entity
        {
            if (list.Count != 0)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = list;
                FormCallDetails form = new FormCallDetails(this, bs);
                form.ShowDialog();
            }
            else MessageBox.Show("Список элементов для отображения пуст.");
        }

        public void ExportToExcel(string filename, DataGridView dgv)
        {
            System.Console.WriteLine("Создаю Excel application...");
            ExcelConnector _ExcelClient = new ExcelConnector(false);
            try
            {
                System.Console.WriteLine("Загружаю книгу " + filename + "...");
                _ExcelClient.OpenExcelWorkBook(filename);
                System.Console.WriteLine("Работаю с листом №1...");
                _ExcelClient.SelectExcelWorkSheet(1);
                for (int i = 0, a = 'A'; i < dgv.ColumnCount; i++, a++)
                {
                    if (!dgv.Columns[i].Visible)
                    {
                        a--;
                        continue;
                    }
                    _ExcelClient.SetCellValue(((char)a).ToString(), 1, dgv.Columns[i].Name);
                    for (int j = 0; j < dgv.RowCount; j++)
                        _ExcelClient.SetCellValue(((char)a).ToString(), j + 2, dgv[i, j].Value.ToString());
                }
            }
            catch (Exception ex) { System.Console.WriteLine(ex.Message); }
            finally
            {
                System.Console.WriteLine("Закрываю Excel application...");
                _ExcelClient.Close();

            }
        }

        public void ImportCallsCSV(string filename)
        {
            Importer imp = new Importer(this.Connector);
            string[][] data = imp.GetCSVCalls(filename);
            imp.ImportCalls(data);
        }

        public void ExportToCSV(string filename, DataGridView dgv)
        {
            Importer imp = new Importer(this.Connector);
            string[][] data=new string [0][];
            Console.WriteLine("Rows="+dgv.RowCount+ "; Cols= "+dgv.ColumnCount);
            for (int i=0;i<dgv.RowCount;i++)
            {
                string[] arr=new string[dgv.ColumnCount];
                DataGridViewRow Row=dgv.Rows[i];
                for (int j=0;i<dgv.ColumnCount;i++) 
                {
                    arr[j]=Row.Cells[j].Value.ToString();
                }
                Array.Resize(ref data, data.Length + 1);
                data[data.Length - 1] = arr;
            }

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j]);
                    Console.Write('|');
                }
                Console.WriteLine();
            }

            imp.ExportCallsCSV(filename, data);
        }

        public void UpdateList<T>(List<T> objects) where T: Entity
        {
            for (int i = 0; i < objects.Count; i++) 
            {
                objects[i] = UpdateEntity(objects[i]);
            }
        }

        public T UpdateEntity<T>(T obj) where T : Entity
        {
            return Connector.Get<T>(obj.Id);
        }
    }
}
