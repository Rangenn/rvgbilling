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
            this.ctrl = ctrl;
        }

        public FormAbonent(Controller ctrl, PrivateAbonent ab)
 	            : this(ctrl)
 	        {
                this.abonent = ab;// = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
                Refresh();
 	        }

        public FormAbonent(Controller ctrl, CorporateAbonent ab)
            : this(ctrl)
        {
            MessageBox.Show("Corporate abonents not supported yet!");
            //this.Close();
            supported = false;
        }

        public FormAbonent(Controller ctrl,Int64 id)
            : this(ctrl)
        {
            //Int64 id = 1;
            abonent = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
            this.Refresh();
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
            Refresh();
        }

        /// <summary>
        /// Обновление компонентов формы
        /// </summary>
        private void Refresh()
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

    }
}
