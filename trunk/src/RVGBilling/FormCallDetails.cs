using System;
using System.Windows.Forms;


namespace RVGBilling
{
    /// <summary>
    /// Форма детализации. В качестве источники информации используется bindingsource.
    /// </summary>
    public partial class FormCallDetails : Form
    {
        Controller controller;

        public FormCallDetails(Controller ctrl)
            : base()
        {
            InitializeComponent();
            controller = ctrl;
        }

        public FormCallDetails(Controller ctrl, BindingSource bs): this (ctrl)
        {          
            //отобразить коллекцию в DataGridView
            dgDetails.DataSource = bs;
            DataGridViewColumnCollection Columns = dgDetails.Columns;
            if (Columns.Contains("Id")) Columns["Id"].Visible = false;
            //if (Columns.Contains("Number")) Columns["Number"].Visible = false;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                controller.ExportToExcel(saveFileDialog1.FileName, controller.GridToArray(dgDetails));
            }     
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                controller.ExportToCSV(saveFileDialog1.FileName, controller.GridToArray(dgDetails));
            }
        }


        
    }
}
