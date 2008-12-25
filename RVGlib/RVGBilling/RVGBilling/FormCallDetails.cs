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
    public partial class FormCallDetails : Form
    {
        public FormCallDetails()
        {
            InitializeComponent();

        }

        public FormCallDetails(BindingSource bs): this ()
        {
            //отобразить коллекцию в DataGridView
            dgCalls.DataSource = bs;
            DataGridViewColumnCollection Columns = dgCalls.Columns;
            Columns["Id"].Visible = false;
            Columns["Number"].Visible = false;
        }
    }
}
