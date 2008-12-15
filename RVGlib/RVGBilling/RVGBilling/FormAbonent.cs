using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RVGBilling
{
    public partial class FormAbonent : Form
    {
        Controller ctrl;

        public FormAbonent(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        public FormAbonent(Controller ctrl, string FIO, string passport):this(ctrl)
        {
            tbName.Text = FIO;
            tbPassport.Text = passport;
        }
    }
}
