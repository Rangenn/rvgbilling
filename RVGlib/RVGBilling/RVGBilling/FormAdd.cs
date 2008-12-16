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
    public partial class FormAdd : Form
    {
        private Number num;

        public FormAdd()
        {
            InitializeComponent();
        }
        public FormAdd(Number num)
        {
            InitializeComponent();
            this.num = num;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.num.number = maskedTextBox.Text;
            num.number = maskedTextBox.Text;
        }

        
    }
}
