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
    /// <summary>
    /// Форма добавления абонентов - физ.лиц
    /// </summary>
    public partial class AddPrivateAbonentForm : Form
    {
        PrivateAbonent Abonent;

        public AddPrivateAbonentForm(PrivateAbonent ab)
        {
            Abonent = ab;
            if (Abonent == null)
                throw new NullReferenceException("Abonent is null");
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Abonent.surname = tbSurname.Text;
            Abonent.name = tbName.Text;
            Abonent.patronymic = tbPatronymic.Text;
            Abonent.passport_series = mtbPassportSeries.Text;
            Abonent.passport_date = dtpPassportDate.Value;
            Abonent.passport_department = tbDepartament.Text;
            Abonent.phone = tbPhone.Text;
            Abonent.birth_date = dtpBirthDate.Value;
            //Abonent.balance = 0;
            Abonent.last_pay_date = DateTime.Today;
            Abonent.creation_time = DateTime.Today;
            Abonent.mail_address = tbEmail.Text;
            Abonent.address = tbAddress.Text;
        }
    }
}
