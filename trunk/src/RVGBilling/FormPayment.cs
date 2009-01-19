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
    public partial class FormPayment : Form
    {
        public Int32 summa;
        public FormPayment(Int32 sum)
        {
            InitializeComponent();
            this.tbSumma.Text = sum.ToString();
            this.summa = sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.summa = Int32.Parse(tbSumma.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Некорректный ввод сумммы");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
