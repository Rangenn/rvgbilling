using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RVGBilling
{
    public partial class AddCorporateAbonentForm : Form
    {
        Controller ctrl;
        public AddCorporateAbonentForm(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            ctrl.AddCorporateAbonent(tbName.Text, tbAddress.Text,tbPhone.Text, tbEmail.Text);
            this.Close();
        }
    }
}
