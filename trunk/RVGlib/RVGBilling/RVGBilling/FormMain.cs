using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
                    //ctrl.AddPerson(tbPersonName.Text, tbPersonPassport.Text, tbPersonPhone.Text);
                    break;
                case 1:
                   // ctrl.AddCorporate(tbCorpName.Text, tbCorpAdress.Text, tbCorpPhone.Text);
                    break;
            }

            //FormAbonent fab = new FormAbonent(tbPersonName.Text, tbPersonPassport.Text);
            //fab.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (tcAbonent.SelectedIndex)
            {
                case 0:
                    /*PersonCollection collect = *///ctrl.SearchPerson(tbPersonName.Text, tbPersonPassport.Text, tbPersonPhone.Text);
                    //отобразить коллекцию в DataGridView
                    break;
                case 1:
                    /*CorporateCollection collect = *///ctrl.SearchCoporate(tbCorpName.Text, tbCorpAdress.Text, tbCorpPhone.Text);
                    //отобразить коллекцию в DataGridView
                    break;
            }
        }

        private void btnSelectBody_Click(object sender, EventArgs e)
        {
            switch (tcAbonent.SelectedIndex)
            {
                case 0:
                  //  ctrl.SelectPerson(0/*id из dataGridView*/);
                    break;
                case 1:
                  //  ctrl.SelectCorporate(0/*id из dataGridView*/);
                    break;
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
          //  ctrl.Payment(tbNomber.Text, Convert.ToDecimal(tbSumma.Text));
            //сделать обработку исключения
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
