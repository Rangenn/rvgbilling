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
    /// <summary>
    /// Форма редактирования списка тарифов с ценами
    /// </summary>
    public partial class FormRateList : Form
    {
        IList<Rate> ListRates;
        BindingSource lbBindingSource, gridBindingSource;
        Controller controller;

        public FormRateList()
        {
            InitializeComponent();
            ListRates = new List<Rate>();
        }

        public FormRateList(Controller ctrl)
            : this()
        {
            this.controller = ctrl;
            // выбираем все тарифы и заносим в listbox
            ListRates = ctrl.GetRates();
            lbBindingSource = new BindingSource();
            lbBindingSource.DataSource = ListRates;
            lbRates.DataSource = lbBindingSource;
        }

        private void InitGrid()
        {
            // прячем ненужные колонки DataGridView, создаем названия заголовков
            DataGridViewColumnCollection Columns = dgvPrices.Columns;
            if (Columns.Contains("rate")) Columns["rate"].Visible = false;
            if (Columns.Contains("mask")) Columns["mask"].HeaderText = "Маска номера";
            if (Columns.Contains("cost_per_minute")) Columns["cost_per_minute"].HeaderText = "Цена за минуту";
            if (Columns.Contains("ID")) Columns["ID"].Visible = false;
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
                controller.AddPrice((Rate)lbRates.SelectedItem);
            gridBindingSource.ResetBindings(false);
            //выдать диалоговое окно, по завершении добавить в список и обновить грид
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            int index = dgvPrices.CurrentRow.Index;
            if (index >= 0)
                controller.EditPrice(((Rate)lbRates.SelectedItem).Prices[index]);
            gridBindingSource.ResetBindings(false);
            //выдать диалоговое окно, по завершении сохранить изменения и обновить грид
        }

        private void btnRemovePrice_Click(object sender, EventArgs e)
        {
            int index = dgvPrices.CurrentRow.Index;
            if (index >= 0)
            {               
                Rate rate=(Rate)lbRates.SelectedItem;
                Price price = rate.Prices[index];
                controller.DeletePriceFromRate(rate, price);
            }
            gridBindingSource.ResetBindings(false);
            //удалить из списка и обновить грид
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rate r=controller.AddRate();
            ListRates = controller.GetRates();
            lbBindingSource.DataSource = ListRates;
            lbBindingSource.ResetBindings(false);
            //добавить новый тариф в список и обновить лист
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lbRates.SelectedIndex;
            if (index >= 0)
            {
                Rate rate = (Rate)lbRates.SelectedItem;
                controller.EditRate(rate);
                lbBindingSource.ResetBindings(false);
            }
            //изменить название тарифа
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lbRates.SelectedIndex;
            if (index >= 0)
            {
                Rate rate = (Rate)lbRates.SelectedItem;             
                //if (controller.DeleteRate(rate))
                    //ListRates.Remove(rate);
                controller.DeleteRate(rate);
                ListRates = controller.GetRates();
                lbBindingSource.DataSource = ListRates;
                lbBindingSource.ResetBindings(false);
            }
            //удалить тариф из списка и обновить лист
        }

        private void dgvPrices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            InitGrid();
        }

        private void ExportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel files|*.xls|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ExportToExcel(saveFileDialog.FileName, controller.GridToArray(dgvPrices));
            }
        }

        private void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ExportToCSV(saveFileDialog.FileName, controller.GridToArray(dgvPrices));
            }
        }

        private void genToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Import.DataGenerator dg = new RVGBilling.Import.DataGenerator();
            int index = lbRates.SelectedIndex;
            if (index >= 0)
            {
                Rate rate = (Rate)lbRates.SelectedItem;
                controller.ImportRatesFromDataToDB(dg.generateRate(rate.name, 900, 950));
                gridBindingSource.ResetBindings(false);
            }           
        }
    }
}
