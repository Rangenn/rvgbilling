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

        public FormCallDetails(IList<Call> list): this ()
        {
            DataGridViewColumnCollection Columns = dgCalls.Columns;
            Columns.Clear();
            Columns.Add("Calling number", "Вызываемый номер");
            Columns.Add("Start time", "Начало разговора");
            Columns.Add("Duration", "Время разговора, сек");
            Columns.Add("id", "ID");
            Columns["id"].Visible = false;
            DataGridViewRowCollection Rows = dgCalls.Rows;
            Rows.Clear();
            if (list.Count > 0)
            {
                Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    Rows[i].Cells["Calling number"].Value = list[i].calling_number;
                    Rows[i].Cells["Start time"].Value = list[i].start_time.ToString();
                    Rows[i].Cells["Duration"].Value = list[i].duration;
                    Rows[i].Cells["id"].Value = list[i].Id;
                }
            }
            //dgCalls.Visible = true;
            //отобразить коллекцию в DataGridView
        }
    }
}
