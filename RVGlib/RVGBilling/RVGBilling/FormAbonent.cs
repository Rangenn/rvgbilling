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
    public partial class FormAbonent : Form
    {
        Controller ctrl;
       //DBconnector connector;
        PrivateAbonent ab;

        public FormAbonent(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        public FormAbonent(Controller ctrl, PrivateAbonent ab)
 	            : this(ctrl)
 	        {
 	            //Int64 id = 1;
 	           // PrivateAbonent ab = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
 	            tbName.Text = ab.name;
 	            tbPassport.Text = ab.passport_series;
 	            for (int i = 0; i < ab.Numbers.Count; i++)
 	                lbNumbers.Items.Add(ab.Numbers[i].number);
 	            IList<Rate> rates=(IList<Rate>)ctrl.conn.GetAll<Rate>();
 	            for (int i = 0; i < rates.Count; i++)
 	                cbTariff.Items.Add(rates[i].name);
 	            //cbTariff.SelectedItem=ab.Numbers[lbNumbers.SelectedItem
 	        }

        public FormAbonent(Controller ctrl, CorporateAbonent ab)
        {
        }

        public FormAbonent(Controller ctrl,Int64 id)
            : this(ctrl)
        {
            //Int64 id = 1;
            ab = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
            this.Refresh();
        }

        private void lbNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            cbTariff.SelectedItem = ab.Numbers[index].rate;
        }

        private void btnChangeTariff_Click(object sender, EventArgs e)
        {
            int index = lbNumbers.SelectedIndex;
            ab.Numbers[index].rate = (Rate)cbTariff.SelectedItem;
            //ab.name = "derrek";
            ctrl.conn.Update(ab);
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            
            Number num = new Number
            {   
                abonent=ab,
                rate = (Rate)cbTariff.SelectedItem
            };
            FormAdd form = new FormAdd(num);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //ctrl.conn.Save(num);
                ab.Numbers.Add(num);
                ctrl.conn.Update(ab);
            }
            Refresh();
        }

        private void Refresh()
        {
            //Int64 id = 1;
            tbName.Text = ab.name;
            tbPassport.Text = ab.passport_series;
            lbNumbers.Items.Clear();
            // заполняем listbox с номерами
            for (int i = 0; i < ab.Numbers.Count; i++)
                lbNumbers.Items.Add(ab.Numbers[i].number);
            // заполняем combobox с тарифами
            IList<Rate> rates = (IList<Rate>)ctrl.conn.GetAll<Rate>();
            cbTariff.Items.Clear();
            for (int i = 0; i < rates.Count; i++)
                cbTariff.Items.Add(rates[i]);
            int index = (lbNumbers.SelectedIndex < 0) ? 0 : lbNumbers.SelectedIndex;
            cbTariff.SelectedItem = ab.Numbers[index].rate;
        }

    }
}
