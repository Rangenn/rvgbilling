using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RVGbilling
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAbonent fab = new FormAbonent(textBox5.Text, textBox1.Text);
            fab.ShowDialog();
        }
    }
}
