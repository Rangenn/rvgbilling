using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RVGlib.Domain;

namespace RVGBilling
{
    public partial class FormMain : Form
    {
        Controller ctrl;

        public FormMain(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
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
            switch (tcAbonent.SelectedIndex)
            {
                case 0:
                    {
                        IList<PrivateAbonent> list = ctrl.SearchPerson(tbPersonName.Text, tbPersonPassport.Text, tbPersonPhone.Text);
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
                        break;
                    }
                case 1:
                    {
                        IList<CorporateAbonent> list = ctrl.SearchCoporate(tbCorpName.Text, tbCorpAdress.Text, tbCorpPhone.Text);
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
                        break;
                    }
            }
        }

        private void btnSelectBody_Click(object sender, EventArgs e)
        {
            switch (tcAbonent.SelectedIndex)
            {
                case 0:
                    ctrl.SelectPerson(Convert.ToInt32(dgvSearch.CurrentRow.Cells["id"].Value));
                    break;
                case 1:
                    ctrl.SelectCorporate(Convert.ToInt32(dgvSearch.CurrentRow.Cells["id"].Value));
                    break;
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
    }
}
