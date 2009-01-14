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
    /// Форма добавления тарифов
    /// </summary>
    public partial class FormRate : Form
    {
        private Rate rate;

        public FormRate()
        {
            InitializeComponent();
        }

        public FormRate(Rate r) : this()
        {
            this.rate = r;
            tbName.Text = r.name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rate.name = tbName.Text;
        }
    }
}
