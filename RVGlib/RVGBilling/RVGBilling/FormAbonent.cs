using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RVGlib.Domain;

namespace RVGBilling
{
    /// <summary>
    /// Форма для работы с абонентами
    /// </summary>
    public partial class FormAbonent : Form
    {
        Controller ctrl;
        PrivateAbonent abonent;
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
            if (ab is PrivateAbonent)
            {
                this.abonent = (PrivateAbonent)ab;
                RefreshForm();
            }
            else if (ab is CorporateAbonent)
            {
                MessageBox.Show("Corporate abonents not supported yet!");
                supported = false;
            }
            else
            {
                MessageBox.Show("Incorrect parameter type given in constructor.");
                supported = false;
            }
        }

        public FormAbonent(Controller ctrl,Int64 id)
            : this(ctrl)
        {
            //Int64 id = 1;
            //опасно!
            abonent = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
            this.RefreshForm();
        }

        private void lbNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index>=0)
                cbTariff.SelectedItem = abonent.Numbers[index].rate;
        }

        /// <summary>
        /// смена тарифа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeTariff_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                abonent.Numbers[index].rate = (Rate)cbTariff.SelectedItem;
                ctrl.conn.Update(abonent);
            }

        }
        /// <summary>
        /// добавление нового номера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            
            Number num = new Number
            {   
                abonent=abonent,
                rate = (Rate)cbTariff.Items[0]
            };
            FormAdd form = new FormAdd(num);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //ctrl.conn.Save(num);
                abonent.Numbers.Add(num);
                ctrl.conn.Update(abonent);
            }
            RefreshForm();
        }

        /// <summary>
        /// Обновление компонентов формы
        /// </summary>
        private void RefreshForm()
        {
            //Int64 id = 1;
            tbName.Text = abonent.name;
            tbPassport.Text = abonent.passport_series;
            lbNumbers.Items.Clear();
            // заполняем listbox с номерами
            for (int i = 0; i < abonent.Numbers.Count; i++)
                lbNumbers.Items.Add(abonent.Numbers[i].number);
            // заполняем combobox с тарифами
            IList<Rate> rates = (IList<Rate>)ctrl.conn.GetAll<Rate>();
            cbTariff.Items.Clear();
            for (int i = 0; i < rates.Count; i++)
                cbTariff.Items.Add(rates[i]);
            //int index = (lbNumbers.SelectedIndex < 0) ? 0 : lbNumbers.SelectedIndex;
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
                cbTariff.SelectedItem = abonent.Numbers[index].rate;
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
        }

        private void btnGetDetailes_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            if (index >= 0)
            {
                IList<Call> list = ctrl.GetCalls(abonent.Numbers[index], dtStartDate.Value, dtEndDate.Value);
                FormCallDetails form = new FormCallDetails(list);
                form.ShowDialog();
            }
             //   ctrl.Payment(lbNumbers.SelectedItem.ToString(), 100);
        }

    }
}
