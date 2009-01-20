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
            if (Columns.Contains("money")) Columns["money"].HeaderText = "Сумма";
            if (Columns.Contains("creation_time")) Columns["creation_time"].HeaderText = "Время поступления";
            if (Columns.Contains("cost")) Columns["cost"].HeaderText = "Стоимость";
            if (Columns.Contains("number")) Columns["number"].HeaderText = "Номер абонента";
            if (Columns.Contains("calling_number")) Columns["calling_number"].HeaderText = "Вызываемый номер";
            if (Columns.Contains("duration")) Columns["duration"].HeaderText = "Длительность (секунды)";
            this.Width = 20;
            for (int i = 0; i < dgDetails.Columns.Count; i++ )
                if (dgDetails.Columns[i].Visible)
                    this.Width += dgDetails.Columns[i].Width;
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
