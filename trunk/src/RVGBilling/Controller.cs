using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Globalization;
using RVGlib.Domain;
using RVGlib.Framework;
using System.Windows.Forms;
using NHibernate;
using FluentNHibernate.Framework;

using ExcelWorkLib;
using RVGBilling.Import;
using System.IO;

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
                _connector.GetAll<Abonent>();//для кеширования
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
            else try
                {
                    _connector.Save(ab);
                    ViewAbonent(ab);
                }
                catch (NHibernate.Exceptions.GenericADOException ex) { Console.WriteLine(ex.Message); }
        }

        public void ViewAbonent(Abonent ab)
        {
            formAbonent = new FormAbonent(this, ab);
            fmAbonent.ShowDialog();
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
            catch (FormatException ex) { MessageBox.Show("Введены некорректные данные."); }
            
            return res;
        }

        public void EditPrice(Price pr)
        {
            FormPrice form = new FormPrice(pr);
            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Connector.Update(pr);
                }
            }
            catch (FormatException ex) { MessageBox.Show("Введены некорректные данные."); }
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

        /// <summary>
        /// Функция для пополнения баланса
        /// </summary>
        /// <param name="number"></param>
        /// <param name="summa"></param>
        public void Payment(string number, decimal summa)
        {
            Number num = null;
            Abonent abonent = null;
            try
            {
                //num = Connector.GetNumber(number);
                abonent = Connector.SearchByNumber(number);
                for (int i = 0; i < abonent.Numbers.Count; i++)
                {
                    if (abonent.Numbers[i].number.Equals(number))
                    {
                        num = abonent.Numbers[i];
                        break;
                    }
                }
                if (num == null) throw new DBSearchException("Ошибка поиска номера.", new NullReferenceException());
            }
            catch (DBSearchException ex) { MessageBox.Show(ex.Message); return; }

            string s = "Пополнить баланс на сумму " + summa.ToString();
            if (abonent is PrivateAbonent)
                s += " на имя: " + ((PrivateAbonent)abonent).surname + " " + ((PrivateAbonent)abonent).name + " " + ((PrivateAbonent)abonent).patronymic + '?';
            else if (abonent is CorporateAbonent)
                s += " на имя: " + ((CorporateAbonent)abonent).corporate_name + '?';

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
                Connector.Update(num);
                Connector.add_bill_money(b);
                Connector.Refresh(abonent);
            }
        }

        public void DissolveAbonent(Abonent ab)
        {

            bool res = MessageBox.Show("Расторгнуть договор № " + ab.Id + "?", "Расторжение договора",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
            if (res)
            {
                ab.dissolved = true;
                CalcBalance(ab);
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

        //public void UpdateAbonentList(List<Abonent> objects)
        //{
        //    for (int i = 0; i < objects.Count; i++)
        //    {
        //        if (objects[i] is PrivateAbonent)
        //        {
        //            objects[i] = UpdateEntity((PrivateAbonent)objects[i]);
        //        }
        //        if (objects[i] is CorporateAbonent)
        //        {
        //            objects[i] = UpdateEntity((CorporateAbonent)objects[i]);
        //        }
        //    }
        //}

        //public T UpdateEntity<T>(T obj) where T : Entity
        //{
        //    return Connector.Get<T>(obj.Id);
        //}

        /// <summary>
        /// вычет стоимости еще не учтенных звонков. возвращает текущий(рассчитанный) баланс абонента
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public Decimal CalcBalance(Abonent ab)
        {
            Decimal res = 0;
            if (ab.Numbers == null) return ab.balance;
            foreach (Number n in ab.Numbers)
                foreach (Call c in n.Calls)
                    if (c.creation_time >= ab.last_pay_date)
                    {
                        res += c.cost;
                        //ab.balance -= c.cost;
                    }
            ab.balance -= res;
            ab.last_pay_date = DateTime.Today;
            Connector.Update(ab);
            return ab.balance;
        }

        public void CalcAllBalances()
        {
            //Thread t = new Thread(delegate()
            //{
                foreach (Abonent ab in Connector.GetAll<Abonent>())
                    CalcBalance(ab);
            //}
            //);
            //t.Start();
            //MessageBox.Show("Calculating... Please wait");
            //t.Join();
        }

        public void MakeReport(Abonent ab, DateTime dt)
        {
            Decimal bal = CalcBalance(ab);
            string[][] Arr = new string[4][];
            Arr[0] = new string[]{"Информация об абоненте"};
            Arr[1] = ab.ToStringArray();//выводим инфо об абоненте
            Arr[2] = new string[] {"Звонки"};
            Arr[3] = new string[] { "Исходящий", "Входящий", "Начало звонка", "Длительность", "Стоимость" };
            foreach (Number n in ab.Numbers) //выводим инфо о его звонках
            {

                IList<Call> buf = n.Calls;
                for (int i = 0; i < buf.Count; i++)
                {
                    if (buf[i].creation_time.CompareTo(dt) >= 0)
                    {
                        Array.Resize(ref Arr, Arr.Length + 1);
                        Arr[Arr.Length - 1] = buf[i].ToStringArray();
                    }
                }
            }
            Array.Resize(ref Arr, Arr.Length + 2);
            Arr[Arr.Length - 2] = new string[]{"Платежи"};
            Arr[Arr.Length - 1] = new string[]{"Номер", "Сумма", "Дата"};
            foreach (Number n in ab.Numbers) //выводим инфо о его платежах
            {
                IList<Bill> billbuf = n.Bills; 
                for (int i = 0; i < billbuf.Count; i++)
                {
                    if (billbuf[i].creation_time.CompareTo(dt) >= 0)
                    {
                        Array.Resize(ref Arr, Arr.Length + 1);
                        Arr[Arr.Length - 1] = billbuf[i].ToStringArray();
                    }
                }
            }
            Array.Resize(ref Arr, Arr.Length + 1);
            Arr[Arr.Length - 1] = new string[]{"Итоговый баланс на момент выписки счета: ", bal.ToString()};
            string str = ab.Id.ToString() + ' ';
            if (ab is PrivateAbonent)
                str += ((PrivateAbonent)ab).surname;
            if (ab is CorporateAbonent)
                str += ((CorporateAbonent)ab).corporate_name;
            //string app_path  = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string app_path = new DirectoryInfo(".").FullName;
            str = app_path +"\\report" + ' ' + str + ' ' + dt.ToShortDateString() + ' ' + DateTime.Now.ToShortDateString() + ' ' + ".xls";
            logger.log(str);
            ExportToExcel(str, Arr);
        }

        public void MakeAllReports()
        {
            DateTime dt = new DateTime(DateTime.Today.Year - 1, DateTime.Today.Month, 1);
            foreach (Abonent ab in Connector.GetAll<PrivateAbonent>())
                MakeReport(ab, dt);
            foreach (Abonent ab in Connector.GetAll<CorporateAbonent>())
                MakeReport(ab, dt);
        }



        /// <summary>
        /// Извлечь из datagridview двумерный массив строк
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string[][] GridToArray(DataGridView dgv)
        {
            string[][] data = new string[dgv.RowCount][];
            Console.WriteLine("Rows=" + dgv.RowCount + "; Cols= " + dgv.ColumnCount);
            for (int i = 0; i < dgv.RowCount; i++)
            {
                string[] arr = new string[dgv.ColumnCount];
                DataGridViewRow Row = dgv.Rows[i];
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    string str;
                    if (Row.Cells[j].ValueType.IsValueType)
                        str = Convert.ToString(Row.Cells[j].Value, CultureInfo.InvariantCulture.NumberFormat);
                    else str = Row.Cells[j].Value.ToString();
                    arr[j] = str;
                }
                //Array.Resize(ref data, data.Length + 1);
                data[i] = arr;
            }
            return data;
        }
        /// <summary>
        /// Вывести в консольный поток вывода двумерный строковый массив
        /// </summary>
        /// <param name="data"></param>
        private static void ConsolePrint(string[][] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j]);
                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }

        #region universal transmitting of string[][] data
        public void ExportToCSV(string filename, string[][] data)
        {
            Export(filename, data, new CsvTransmitter());
        }
        public void ExportToExcel(string filename, string[][] data)
        {
            Export(filename, data, new ExcelTransmitter());
        }
        protected void Export(string filename, string[][] data, ITransmitter tm)
        {
            tm.Export(filename, data);
        }
        public string[][] ImportFromExcel(string filename)
        {
            return Import(filename, new ExcelTransmitter());
        }

        public string[][] ImportFromCSV(string filename)
        {
            return Import(filename, new CsvTransmitter());
        }
        protected string[][] Import(string filename, ITransmitter tm)
        {
            return tm.Import(filename);
        }
        #endregion

        #region ImportCalls
        public void ImportCallsExcel(string filename)
        {
            ImportCallsFromDataToDB(ImportFromExcel(filename));
        }
        public void ImportCallsCSV(string filename)
        {
            ImportCallsFromDataToDB(ImportFromCSV(filename));
        }
        public void ExportCallsExcel(string filename)
        {
            ExportToExcel(filename, ExportCallsFromDB());
        }
        public void ExportCallsCSV(string filename)
        {
            ExportToCSV(filename, ExportCallsFromDB());
        }
        // на входе строки вида "Вызываемый номер, вызывающий номер, время звонка, длительность"
        //Вадик, это обломно! переделал формат входа на: "вызывающий номер, Вызываемый номер, время звонка, длительность"
        public void ImportCallsFromDataToDB(string[][] data)
        {
            ConsolePrint(data);
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    Number num = Connector.GetNumber(data[i][0]);

                    Call call = new Call
                    {
                        calling_number = data[i][1],
                        number = num,
                        creation_time = Convert.ToDateTime(data[i][2]),
                        duration = Convert.ToInt32(data[i][3])
                    };

                    num.Calls.Add(call);
                    Connector.Update(num);
                    Connector.calculate_call_cost(call);
                }
                catch (EstablishConnectionException ex)
                {
                    Console.WriteLine("Номер не найден :" + data[i][1]);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Формат записи " + i + " не распознан");
                }
            }
        }
        /// <summary>
        /// Экспорт всех тарифов и цен из базы
        /// </summary>
        private string[][] ExportCallsFromDB()
        {
            IList<Call> rates = Connector.GetAll<Call>();
            string[][] Arr = new string[0][];
            foreach (Call c in rates)
            {
                //IList<Price> buf = r.Prices;
                //for (int i = 0; i < buf.Count; i++)
                //{
                    Array.Resize(ref Arr, Arr.Length + 1);
                    Arr[Arr.Length - 1] = c.ToStringArray();
                    //Console.WriteLine("buf length : "+buf[i].ToStringArray().Length);
                //}
            }
            return Arr;
        }
        #endregion

        #region ImportExportRates
        public void ImportRatesExcel(string filename)
        {
            ImportRatesFromDataToDB(ImportFromExcel(filename));
        }
        public void ImportRatesCSV(string filename)
        {
            ImportRatesFromDataToDB(ImportFromCSV(filename));
        }

        public void ExportRatesExcel(string filename)
        {
            ExportToExcel(filename, ExportRatesFromDB());
        }
        public void ExportRatesCSV(string filename)
        {
            ExportToCSV(filename, ExportRatesFromDB());
        }

        //на входе строки вида "Название тарифа, маска, цена за минуту"
        private void ImportRatesFromDataToDB(string[][] data)
        {
            ConsolePrint(data);
            //не реализовано.

            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    Rate rate = Connector.GetRate(data[i][0]);

                    Price price = new Price
                    {
                        rate = rate,
                        mask = data[i][1],
                        cost_per_minute = Convert.ToDecimal(data[i][2],CultureInfo.InvariantCulture.NumberFormat)
                    };
                    if (rate.Prices.Contains<Price>(price, new PriceComparer()))
                    {
                        Console.WriteLine("Маска \"" + price.mask + "\" уже существует в этом тарифе.");
                    }
                    else
                    {
                        rate.Prices.Add(price);
                        Connector.Update(rate);
                    }
                }
                catch (EstablishConnectionException ex)
                {
                    Console.WriteLine("Тариф не найден :" + data[i][0]);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Формат записи " + i + " не распознан");
                }
            }
        }
        /// <summary>
        /// Экспорт всех тарифов и цен из базы
        /// </summary>
        private string[][] ExportRatesFromDB()
        {
            IList<Rate> rates= Connector.GetAll<Rate>();
            string[][] Arr = new string[0][];
            foreach (Rate r in rates)
            {
                IList<Price> buf = r.Prices;
                for (int i = 0; i < buf.Count; i++)
                {
                        Array.Resize(ref Arr, Arr.Length + 1);
                        Arr[Arr.Length - 1] = buf[i].ToStringArray();
                        //Console.WriteLine("buf length : "+buf[i].ToStringArray().Length);
                }
            }
            return Arr;
        }
        #endregion

    }
}
