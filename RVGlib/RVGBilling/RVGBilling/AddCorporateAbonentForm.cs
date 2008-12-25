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
    public partial class AddCorporateAbonentForm : Form
    {
        CorporateAbonent Abonent;

        public AddCorporateAbonentForm(CorporateAbonent ab)
        {
            Abonent = ab;
            if (Abonent == null)
                throw new NullReferenceException("Abonent is null");
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Abonent.corporate_name = tbName.Text;
            Abonent.INN = tbINN.Text;
            Abonent.phone = tbPhone.Text;
            Abonent.balance = 0;
            Abonent.last_pay_date = DateTime.Today;
            Abonent.reg_time = DateTime.Today;
            Abonent.mail_address = tbEmail.Text;
            Abonent.address = tbAddress.Text;
        }
    }
}
