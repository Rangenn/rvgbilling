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
    public partial class AddPrivateAbonentForm : Form
    {
        Controller ctrl; 

        public AddPrivateAbonentForm(Controller ctrl)
        {
            this.ctrl = ctrl;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            DateTime passportDate = DateTime.Parse(tbPassportDate.Text);
            ctrl.AddPrivateAbonent(tbSurname.Text, tbName.Text, tbPatronymic.Text, tbPassportSeria.Text, passportDate, tbDepartament.Text, tbNewNumber.Text);
            this.Close();
        }
    }
}
