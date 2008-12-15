using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RVGlib.Domain;

using RVGlib.Domain;

namespace RVGBilling
{
    public partial class FormAbonent : Form
    {
        Controller ctrl;
       //DBconnector connector;

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

        public FormAbonent(Controller ctrl,Int64 id)
            : this(ctrl)
        {
            //Int64 id = 1;
            PrivateAbonent ab = (PrivateAbonent)ctrl.conn.Get<PrivateAbonent>(id);
            tbName.Text = ab.name;
            tbPassport.Text = ab.passport_series;
            for (int i = 0; i < ab.Numbers.Count; i++)
                lbNumbers.Items.Add(ab.Numbers[i].number);
            IList<Rate> rates=(IList<Rate>)ctrl.conn.GetAll<Rate>();
            for (int i = 0; i < rates.Count; i++)
                cbTariff.Items.Add(rates[i].name);
            //cbTariff.SelectedItem=ab.Numbers[lbNumbers.SelectedItem
        }
    }
}
