using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using RVGlib.Domain;

namespace RVGBilling
{
    /// <summary>
    /// Форма для работы с абонентами
    /// </summary>
    public partial class FormAbonent : Form
    {
        Controller ctrl;
        Abonent abonent;
        BindingSource rateBindingSource, numbersBindingSource;
        bool supported = true;

        public FormAbonent(Controller ctrl)
        {
            InitializeComponent();
            dtStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.ctrl = ctrl;
        }

        public FormAbonent(Controller ctrl, Abonent ab)
 	            : this(ctrl)
        {
            // заполняем combobox с тарифами
            IList<Rate> rates = ctrl.GetRates();
            rateBindingSource = new BindingSource();
            rateBindingSource.DataSource = rates;
            cbRate.DataSource = rateBindingSource;

            if (ab is PrivateAbonent)
            {
                this.abonent = ab;
                RefreshForm();
            }
            else if (ab is CorporateAbonent)
            {
                this.abonent = ab;
                RefreshForm();
            }
            else
            {
                MessageBox.Show("Incorrect parameter type given in constructor.");
                supported = false;
            }

            // заполняем listbox с номерами
            numbersBindingSource = new BindingSource();
            numbersBindingSource.DataSource = abonent.Numbers;
            lbNumbers.DataSource = numbersBindingSource;

        }

        // не использовать! Устарело!
        public FormAbonent(Controller ctrl,Int64 id, bool isPrivate)
            : this(ctrl)
        {

            // заполняем combobox с тарифами
            IList<Rate> rates = ctrl.GetRates();
            rateBindingSource = new BindingSource();
            rateBindingSource.DataSource = rates;
            cbRate.DataSource = rateBindingSource;

            if (isPrivate)
            {
                abonent = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
            }
            else
            {
                abonent = (CorporateAbonent)ctrl.conn.Get<CorporateAbonent>(id);
            }
            this.RefreshForm();

            // заполняем listbox с номерами
            numbersBindingSource = new BindingSource();
            numbersBindingSource.DataSource = abonent.Numbers;
            lbNumbers.DataSource = numbersBindingSource;
        }

        private void lbNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                cbRate.SelectedItem = abonent.Numbers[index].rate;
            }
        }

        /// <summary>
        /// смена тарифа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeRate_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                abonent.Numbers[index].rate = (Rate)cbRate.SelectedItem;
                ctrl.conn.Update(abonent);
            }
            numbersBindingSource.ResetBindings(false);
        }
        /// <summary>
        /// добавление нового номера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            ctrl.AddNumber(abonent, rateBindingSource);
            numbersBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Обновление компонентов формы
        /// </summary>
        private void RefreshForm()
        {
            if (abonent is PrivateAbonent)
            {
                PrivateAbonent person = (PrivateAbonent)abonent;
                tbName.Text = person.surname + ' ' + person.name + ' ' + person.patronymic;
                labelIdentity.Text = "Паспортные данные";
                tbIdentity.Text = person.passport_series;
            }
            if (abonent is CorporateAbonent)
            {
                CorporateAbonent corp = (CorporateAbonent)abonent;
                tbName.Text = corp.corporate_name;
                labelIdentity.Text = "ИНН";
                tbIdentity.Text = corp.INN;
            }
            this.Text = "Абонент : " + tbName.Text;
            tbLastPay.Text = abonent.last_pay_date.ToString();
            tbBalance.Text = abonent.balance.ToString();
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                cbRate.SelectedItem = abonent.Numbers[index].rate;
            }
            else
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void FormAbonent_Load(object sender, EventArgs e)
        {
            if (!supported)
                this.Close();
        }

        private void btnAddMoney_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
                ctrl.Payment(lbNumbers.SelectedItem.ToString(), 100);
            RefreshForm();
        }

        private void btnGetDetailes_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                IList<Call> list = ctrl.GetCalls(abonent.Numbers[index], dtStartDate.Value, dtEndDate.Value);
                BindingSource bs = new BindingSource();
                bs.DataSource = list;
                FormCallDetails form = new FormCallDetails(bs);
                form.ShowDialog();
            }
        }

    }
}
