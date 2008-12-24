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
    public partial class FormMain : Form
    {
        Controller ctrl;

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
            this.ctrl = ctrl;
            
        }
        
        // Внимание! Метод устарел! Не используйте его
        private void RefreshGrid(IList<PrivateAbonent> list)
        {
            
            DataGridViewColumnCollection Columns = dgvSearch.Columns;
            Columns.Clear();
            Columns.Add("Name", "ФИО");
            Columns.Add("Passport", "Паспорт");
            Columns.Add("id", "id");
            Columns["id"].Visible = false;

            DataGridViewRowCollection Rows = dgvSearch.Rows;
            Rows.Clear();
            if (list.Count > 0)
            {
                Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    Rows[i].Cells["Name"].Value = list[i].surname + " " + list[i].name + " " + list[i].patronymic;
                    Rows[i].Cells["Passport"].Value = list[i].passport_series;
                    Rows[i].Cells["id"].Value = list[i].Id;
                }
            }
            gbSearch.Visible = true;
            //отобразить коллекцию в DataGridView
        }

        // Внимание! Метод устарел! Не используйте его
        private void RefreshGrid(IList<CorporateAbonent> list)
        {
            DataGridViewColumnCollection Columns = dgvSearch.Columns;
            Columns.Clear();
            Columns.Add("Name", "Название");
            Columns.Add("Address", "Адрес");
            Columns.Add("id", "id");
            Columns["id"].Visible = false;

            DataGridViewRowCollection Rows = dgvSearch.Rows;
            Rows.Clear();
            if (list.Count > 0)
            {
                Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    Rows[i].Cells["Name"].Value = list[i].corporate_name;
                    Rows[i].Cells["Address"].Value = list[i].address;
                    Rows[i].Cells["id"].Value = list[i].Id;
                }
            }
            gbSearch.Visible = true;
            //отобразить коллекцию в DataGridView
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
            Columns["reg_time"].Visible = false;
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
                    ctrl.AddPerson();
                    break;
                case 1:
                    ctrl.AddCorporate();
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
                        IList<PrivateAbonent> list = ctrl.SearchPerson(tbPersonName.Text, tbPersonPassport.Text, tbPersonPhone.Text);
                        abonents.AddRange(list.ToArray());
                        bs.DataSource = list;
                        //InitGridPrivate();
                        //this.RefreshGrid(list);
                        //отобразить коллекцию в DataGridView
                        break;
                    }
                case 1:
                    {
                        IList<CorporateAbonent> list = ctrl.SearchCoporate(tbCorpName.Text, tbCorpAdress.Text, tbCorpPhone.Text);
                        abonents.AddRange(list.ToArray());
                        bs.DataSource = list;
                        //this.RefreshGrid(list);
                        //отобразить коллекцию в DataGridView
                        break;
                    }
            }

            // обновление DataGridView
            bs.ResetBindings(true);
            InitGrid(true);
            // обновление DataGridView
            gbSearch.Visible = true;
        }

        private void btnSelectBody_Click(object sender, EventArgs e)
        {
            int index=dgvSearch.CurrentRow.Index;
            //если отсортировали, то борода! ((((((((
            if (index >= 0)
            {
                // все это уже устарело!
                /*switch (tcAbonent.SelectedIndex)
                {
                    case 0:
                        ctrl.SelectPerson(abonents[index]);
                        break;
                    case 1:
                        ctrl.SelectCorporate(abonents[index]);
                        break;
                }*/
                ctrl.ViewAbonent(abonents[index]);
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
            ctrl.Payment(tbNumber.Text, sum);
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

        private void button1_Click(object sender, EventArgs e)
        {
            gbSearch.Visible = false;
        }

        private void tcAbonent_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbSearch.Visible = false;
        }

        private void tariffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctrl.ViewRates();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
