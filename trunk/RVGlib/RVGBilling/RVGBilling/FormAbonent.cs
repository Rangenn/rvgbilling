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

            if (ab is PrivateAbonent || ab is CorporateAbonent)
            {
                this.abonent = ab;              
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
            RefreshForm();
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
                abonent = (PrivateAbonent)ctrl.Connector.Get<PrivateAbonent>(id);
            }
            else
            {
                abonent = (CorporateAbonent)ctrl.Connector.Get<CorporateAbonent>(id);
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
                groupBoxNumInfo.Enabled = true;
                groupBoxOps.Enabled = true;
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
                ctrl.Connector.Update(abonent);
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
                abonent = ctrl.UpdateEntity<PrivateAbonent>((PrivateAbonent)abonent);
                PrivateAbonent person = (PrivateAbonent)abonent;               
                labelSurname.Text = "Фамилия";
                tbSurname.Text = person.surname;               
                labelIdentity.Text = "Паспорт";
                tbIdentity.Text = person.passport_series;

                //mtbPassportSeries.Text = person.passport_series;
                tbName.Text = person.name;
                tbPatronymic.Text = person.patronymic;
                dtpBirthDate.Value = person.birth_date;                
                dtpPassportDate.Value = person.passport_date;
                tbDepartament.Text = person.passport_department;
                label11.Visible =
                label12.Visible =
                label13.Visible =
                label14.Visible =
                label2.Visible = 
                tbName.Visible = 
                tbPatronymic.Visible = 
                dtpBirthDate.Visible = 
                dtpPassportDate.Visible =
                tbDepartament.Visible = true;
            }
            if (abonent is CorporateAbonent)
            {
                abonent = ctrl.UpdateEntity<CorporateAbonent>((CorporateAbonent)abonent);
                CorporateAbonent corp = (CorporateAbonent)abonent;
                labelSurname.Text = "Название";
                tbSurname.Text = corp.corporate_name;
                labelIdentity.Text = "�?НН";
                tbIdentity.Text = corp.INN;
                label11.Visible =
                label12.Visible =
                label13.Visible =
                label14.Visible =
                label2.Visible = 
                tbName.Visible =
                tbPatronymic.Visible =
                dtpBirthDate.Visible =
                dtpPassportDate.Visible =
                tbDepartament.Visible = false;
            }
            this.Text = "Абонент : " + tbSurname.Text;
            mtbAccountNumber.Text = abonent.Id.ToString().PadLeft(10, '0');
            tbAddress.Text = abonent.address;
            tbPhone.Text = abonent.phone;
            tbEmail.Text = abonent.mail_address;
            tbLastPay.Text = abonent.last_pay_date.ToString();
            tbBalance.Text = abonent.balance.ToString();
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                cbRate.SelectedItem = abonent.Numbers[index].rate;
            }
            else
            {
                groupBoxNumInfo.Enabled = false;
            }
            if (abonent.dissolved)
            {
                groupBoxNumInfo.Enabled =
                groupBoxNumbersList.Enabled =
                groupBoxOps.Enabled = 
                groupBoxAbInfo.Enabled = false;
                this.Text += " ДОГОВОР РАСТОРГНУТ.";
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

        private void btnCloseAccount_Click(object sender, EventArgs e)
        {
            ctrl.DissolveAbonent(abonent);
            RefreshForm();
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                if (rbCalls.Checked)
                {
                    IList<Call> list = ctrl.GetCalls(abonent.Numbers[index], dtStartDate.Value, dtEndDate.Value);
                    ctrl.ViewDetailsForm<Call>(list);
                }
                else if (rbBills.Checked)
                {
                    IList<Bill> list = ctrl.GetBills(abonent.Numbers[index], dtStartDate.Value, dtEndDate.Value);
                    ctrl.ViewDetailsForm<Bill>(list);
                }
                else MessageBox.Show("Не выбран компонент детализации.");
            }
            else MessageBox.Show("Не выбран номер для детализации.");
        }




    }
}
