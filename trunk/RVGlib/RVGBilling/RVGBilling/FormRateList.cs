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
    public partial class FormRateList : Form
    {
        IList<Rate> ListRates;
        Controller ctrl;

        public FormRateList()
        {
            InitializeComponent();
            ListRates = new List<Rate>();

            DataGridViewColumnCollection Columns = dgvPrices.Columns;
            Columns.Clear();
            Columns.Add("mask", "Маска вызываемого номера");
            Columns.Add("cost_per_minute", "Стоимость минуты");
            Columns.Add("id", "ID");
            Columns["id"].Visible = false;
        }

        public FormRateList(Controller ctrl)
            : this()
        {
            this.ctrl = ctrl;
            ListRates = ctrl.GetRates();
        }

        //public FormRateList(Controller ctrl, List<Rate> list) : this()
        //{
        //    this.ctrl = ctrl;
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        ListRates.Add(list[i]);
        //        lbRates.Items.Add(ListRates[i]);
        //    }
        //}

        private void lbRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            IList<Price> list = ListRates[ListRates.IndexOf((Rate)lbRates.SelectedItem)].Prices;
          
            DataGridViewRowCollection Rows = dgvPrices.Rows;
            Rows.Clear();
            if (list.Count > 0)
            {
                Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    Rows[i].Cells["mask"].Value = list[i].mask;
                    Rows[i].Cells["cost_per_minute"].Value = list[i].cost_per_minute;
                    Rows[i].Cells["id"].Value = list[i].Id;
                }
            }
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            //выдать диалоговое окно, по завершении добавить в список и обновить грид
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            //выдать диалоговое окно, по завершении сохранить изменения и обновить грид
        }

        private void btnRemovePrice_Click(object sender, EventArgs e)
        {
            //удалить из списка и обновить грид
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //добавить новый тариф в список и обновить лист
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //найти тариф в списке и сделать selected в листе
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //удалить тариф из списка и обновить лист
        }
    }
}
