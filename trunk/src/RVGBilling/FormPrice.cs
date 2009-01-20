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
    /// Форма добавления цены
    /// </summary>
    public partial class FormPrice : Form
    {
        private Price price;

        public FormPrice()
        {
            InitializeComponent();
        }

        public FormPrice(Price p)
            : this()
        {
            price = p;
            tbCost.Text = p.cost_per_minute.ToString();
            mtbMask.Text = p.mask;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            price.cost_per_minute = Convert.ToDecimal(tbCost.Text);
            price.mask = mtbMask.Text.Trim();
        }
    }
}
