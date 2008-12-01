using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RVGbilling
{
    public partial class FormAbonent : Form
    {
        public FormAbonent()
        {
            InitializeComponent();
        }

        public FormAbonent(string FIO, string passport)
        {
            InitializeComponent();
            tbName.Text = FIO;
            tbPassport.Text = passport;
        }
    }
}
