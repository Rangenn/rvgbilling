using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RVGlib.Domain;

namespace RVGBilling
{
    /// <summary>
    /// Основная форма программы
    /// </summary>
    public partial class FormMain : Form
    {
        Controller controller;

        /// <summary>
        /// BindingSource для связи таблицы и листа абонентов
        /// </summary>
        BindingSource bs;

        private List<Abonent> abonents;

        public FormMain(Controller ctrl)
        {
            InitializeComponent();
            /*foreach (DataGridViewColumn column in dgvSearch.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;*/
            abonents = new List<Abonent>();
            bs = new BindingSource();
            // присваиваем источник данных (и у нас автоматическая загрузка в таблицу!)
            dgvSearch.DataSource = bs;
            controller = ctrl;
            
        }

        /// <summary>
        /// Обновление таблицы (прячем лишние ячейки, устанавливаем заголовки и т.п.)
        /// </summary>
        /// <param name="isPrivate"></param>
        private void InitGrid(bool isPrivate)
        {
            DataGridViewColumnCollection Columns = dgvSearch.Columns;
            /*if (isPrivate)
            {
                DataGridViewColumnCollection Columns = dgvSearch.Columns;
                Columns["balance"].HeaderText = "Баланс";
                Columns["balance"].DisplayIndex = 0;

                Columns["last_pay_date"].Visible = false;
                Columns["Numbers"].Visible = false;
                Columns["phone"].Visible = false;
                Columns["reg_time"].Visible = false;
            }*/
            Columns["last_pay_date"].Visible = false;
            Columns["Numbers"].Visible = false;
            Columns["ID"].Visible = false;
            Columns["creation_time"].Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (tcAbonent.SelectedIndex)
            {
                case 0:
                    controller.AddPrivateAbonent();
                    break;
                case 1:
                    controller.AddCorporateAbonent();
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            abonents.Clear();
            
            switch (tcAbonent.SelectedIndex)
            {
                case 0:
                    {
                        IList<PrivateAbonent> list = controller.SearchPrivateAbonent(tbPersonName.Text, tbPersonPassport.Text, tbPersonPhone.Text);
                        abonents.AddRange(list.ToArray());
                        bs.DataSource = list;
                        //InitGridPrivate();
                        break;
                    }
                case 1:
                    {
                        IList<CorporateAbonent> list = controller.SearchCorporateAbonent(tbCorpName.Text, tbCorpAdress.Text, tbCorpPhone.Text);
                        abonents.AddRange(list.ToArray());
                        bs.DataSource = list;
                        break;
                    }
            }

            // обновление DataGridView
            bs.ResetBindings(true);
            InitGrid(true);
            // обновление DataGridView
            dgvSearch.Visible = true;
        }

        private void btnSelectBody_Click(object sender, EventArgs e)
        {
            int index=dgvSearch.CurrentRow.Index;
            if (index >= 0)
            {
                controller.ViewAbonent(abonents[index]);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            //попросить подтверждение
            Decimal sum;
            try
            {
                sum = Convert.ToDecimal(tbSumma.Text);
                if (sum <= 0)
                    throw new FormatException();
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверно введена сумма");
                return;
            }
            controller.Payment(tbNumber.Text, sum);
            controller.UpdateAbonentList(abonents);
            dgvSearch.Update();
            tbNumber.Text = "";
            tbSumma.Text = "";

            //обновляем DataGridView
            bs.ResetBindings(false);
            //сделать обработку исключения
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHideSearchRes_Click(object sender, EventArgs e)
        {
            dgvSearch.Visible = false;
        }

        private void tcAbonent_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonHideSearchRes_Click(sender, e);
        }

        private void calcBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.CalcAllBalances();
            controller.MakeAllReports();

            MessageBox.Show("Действие успешно выполнено.");
            //Здесь генерируется отчет excel. список всех звонков за месяц либо список списанных сумм.
        }

        private void ImportCallsCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ImportCallsCSV(openFileDialog.FileName);
            }
        }

        private void ImportCallsExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel files|*.xls|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ImportCallsExcel(openFileDialog.FileName);
            }
        }

        private void ImportRatesExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel files|*.xls|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ImportRatesExcel(openFileDialog.FileName);
            }
        }

        private void ImportRatesCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                controller.ImportRatesCSV(openFileDialog.FileName);
            }
        }

        private void ExportRatesExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel files|*.xls|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ExportRatesExcel(saveFileDialog.FileName);
            }
        }

        private void ExportRatesCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ExportRatesCSV(saveFileDialog.FileName);
            }
        }

        private void RatesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ViewRates();
        }

        private void ExportCallsExcelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel files|*.xls|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ExportCallsExcel(saveFileDialog.FileName);
            }
        }

        private void ExportCallsCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                controller.ExportCallsExcel(saveFileDialog.FileName);
            }
        }
    }
}
