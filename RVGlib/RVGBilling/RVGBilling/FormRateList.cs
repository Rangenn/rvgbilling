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
        BindingSource lbBindingSource, gridBindingSource;
        Controller ctrl;

        public FormRateList()
        {
            InitializeComponent();
            ListRates = new List<Rate>();
        }

        public FormRateList(Controller ctrl)
            : this()
        {
            this.ctrl = ctrl;

            // выбираем все тарифы и заносим в listbox
            ListRates = ctrl.GetRates();
            lbBindingSource = new BindingSource();
            lbBindingSource.DataSource = ListRates;
            lbRates.DataSource = lbBindingSource;
        }

        private void InitGrid()
        {
            // прячем ненужные колонки DataGridView
            DataGridViewColumnCollection Columns = dgvPrices.Columns;
            Columns["rate"].Visible = false;
            Columns["mask"].DisplayIndex = 0;
            Columns["ID"].Visible = false;
            Columns["cost_per_minute"].DisplayIndex = 1;
        }


        private void lbRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            // настраиваем BindingSource
            gridBindingSource = new BindingSource();
            // источник данных -- список цен выбранного тарифа
            gridBindingSource.DataSource = ListRates[ListRates.IndexOf((Rate)lbRates.SelectedItem)].Prices;
            dgvPrices.DataSource = gridBindingSource;
            // после этого gridview заполняется автоматически
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            if (lbRates.SelectedItem!=null)
                ctrl.AddPrice((Rate)lbRates.SelectedItem);
            gridBindingSource.ResetBindings(false);
            //выдать диалоговое окно, по завершении добавить в список и обновить грид
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            int index = dgvPrices.CurrentRow.Index;
            if (index >= 0)
                ctrl.EditPrice(((Rate)lbRates.SelectedItem).Prices[index]);
            gridBindingSource.ResetBindings(false);
            //выдать диалоговое окно, по завершении сохранить изменения и обновить грид
        }

        private void btnRemovePrice_Click(object sender, EventArgs e)
        {
            int index = dgvPrices.CurrentRow.Index;
            if (index >= 0)
            {
                // вся эта байда не работает! Рома, сам пиши удаление!!!
                Rate rate=(Rate)lbRates.SelectedItem;
                Price price = rate.Prices[index];
                rate.Prices.Remove(price);
                price.rate = null;
                ctrl.conn.Update(rate);
                ctrl.DeletePrice(price);
            }
            gridBindingSource.ResetBindings(false);
            //удалить из списка и обновить грид
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rate r=ctrl.AddRate();
            ListRates.Add(r);
            lbBindingSource.ResetBindings(false);
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

        private void dgvPrices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            InitGrid();
        }
    }
}
