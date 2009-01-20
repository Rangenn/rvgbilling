using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RVGlib.Domain;

namespace RVGBilling
{
    /// <summary>
    /// Форма добавления номера
    /// </summary>
    public partial class FormAddNumber : Form
    {
        private Number num;

        public FormAddNumber()
        {
            InitializeComponent();
        }
        public FormAddNumber(Number num, BindingSource rateBindingSource) : this()
        {
            this.num = num;
            cbRate.DataSource = rateBindingSource;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            num.number = maskedTextBox.Text;
            num.rate = (Rate)cbRate.SelectedItem;
        }
      
    }
}
