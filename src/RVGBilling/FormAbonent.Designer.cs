namespace RVGBilling
{
    partial class FormAbonent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAbInfo = new System.Windows.Forms.GroupBox();
            this.mtbAccountNumber = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPassportDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDepartament = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPatronymic = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLastPay = new System.Windows.Forms.TextBox();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbIdentity = new System.Windows.Forms.TextBox();
            this.labelIdentity = new System.Windows.Forms.Label();
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.lbNumbers = new System.Windows.Forms.ListBox();
            this.groupBoxNumInfo = new System.Windows.Forms.GroupBox();
            this.rbBills = new System.Windows.Forms.RadioButton();
            this.rbCalls = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetCallDetails = new System.Windows.Forms.Button();
            this.btnChangeTariff = new System.Windows.Forms.Button();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxOps = new System.Windows.Forms.GroupBox();
            this.btnCloseAccount = new System.Windows.Forms.Button();
            this.btnMakeBill = new System.Windows.Forms.Button();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.groupBoxNumbersList = new System.Windows.Forms.GroupBox();
            this.groupBoxAbInfo.SuspendLayout();
            this.groupBoxNumInfo.SuspendLayout();
            this.groupBoxOps.SuspendLayout();
            this.groupBoxNumbersList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAbInfo
            // 
            this.groupBoxAbInfo.Controls.Add(this.mtbAccountNumber);
            this.groupBoxAbInfo.Controls.Add(this.label15);
            this.groupBoxAbInfo.Controls.Add(this.label10);
            this.groupBoxAbInfo.Controls.Add(this.tbEmail);
            this.groupBoxAbInfo.Controls.Add(this.label1);
            this.groupBoxAbInfo.Controls.Add(this.tbAddress);
            this.groupBoxAbInfo.Controls.Add(this.dtpBirthDate);
            this.groupBoxAbInfo.Controls.Add(this.label2);
            this.groupBoxAbInfo.Controls.Add(this.dtpPassportDate);
            this.groupBoxAbInfo.Controls.Add(this.label11);
            this.groupBoxAbInfo.Controls.Add(this.tbDepartament);
            this.groupBoxAbInfo.Controls.Add(this.label12);
            this.groupBoxAbInfo.Controls.Add(this.label13);
            this.groupBoxAbInfo.Controls.Add(this.tbPatronymic);
            this.groupBoxAbInfo.Controls.Add(this.label14);
            this.groupBoxAbInfo.Controls.Add(this.tbName);
            this.groupBoxAbInfo.Controls.Add(this.labelSurname);
            this.groupBoxAbInfo.Controls.Add(this.label16);
            this.groupBoxAbInfo.Controls.Add(this.tbSurname);
            this.groupBoxAbInfo.Controls.Add(this.tbPhone);
            this.groupBoxAbInfo.Controls.Add(this.label9);
            this.groupBoxAbInfo.Controls.Add(this.tbLastPay);
            this.groupBoxAbInfo.Controls.Add(this.tbBalance);
            this.groupBoxAbInfo.Controls.Add(this.label8);
            this.groupBoxAbInfo.Controls.Add(this.tbIdentity);
            this.groupBoxAbInfo.Controls.Add(this.labelIdentity);
            this.groupBoxAbInfo.Location = new System.Drawing.Point(13, 13);
            this.groupBoxAbInfo.Name = "groupBoxAbInfo";
            this.groupBoxAbInfo.Size = new System.Drawing.Size(329, 389);
            this.groupBoxAbInfo.TabIndex = 0;
            this.groupBoxAbInfo.TabStop = false;
            this.groupBoxAbInfo.Text = "Информация";
            // 
            // mtbAccountNumber
            // 
            this.mtbAccountNumber.Location = new System.Drawing.Point(149, 17);
            this.mtbAccountNumber.Mask = "0000000000";
            this.mtbAccountNumber.Name = "mtbAccountNumber";
            this.mtbAccountNumber.ReadOnly = true;
            this.mtbAccountNumber.Size = new System.Drawing.Size(168, 20);
            this.mtbAccountNumber.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 69;
            this.label15.Text = "№ договора";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "E-mail";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(149, 258);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(168, 20);
            this.tbEmail.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Адрес";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(149, 232);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(168, 20);
            this.tbAddress.TabIndex = 9;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Enabled = false;
            this.dtpBirthDate.Location = new System.Drawing.Point(149, 201);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(168, 20);
            this.dtpBirthDate.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Дата рождения";
            // 
            // dtpPassportDate
            // 
            this.dtpPassportDate.Enabled = false;
            this.dtpPassportDate.Location = new System.Drawing.Point(149, 145);
            this.dtpPassportDate.Name = "dtpPassportDate";
            this.dtpPassportDate.Size = new System.Drawing.Size(168, 20);
            this.dtpPassportDate.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Кем выдан";
            // 
            // tbDepartament
            // 
            this.tbDepartament.Location = new System.Drawing.Point(149, 171);
            this.tbDepartament.Name = "tbDepartament";
            this.tbDepartament.ReadOnly = true;
            this.tbDepartament.Size = new System.Drawing.Size(168, 20);
            this.tbDepartament.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Когда выдан";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "Отчество";
            // 
            // tbPatronymic
            // 
            this.tbPatronymic.Location = new System.Drawing.Point(149, 119);
            this.tbPatronymic.Name = "tbPatronymic";
            this.tbPatronymic.ReadOnly = true;
            this.tbPatronymic.Size = new System.Drawing.Size(168, 20);
            this.tbPatronymic.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Имя";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(149, 93);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(168, 20);
            this.tbName.TabIndex = 4;
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(6, 70);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(56, 13);
            this.labelSurname.TabIndex = 52;
            this.labelSurname.Text = "Фамилия";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 284);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Контактный тел.";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(149, 67);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.ReadOnly = true;
            this.tbSurname.Size = new System.Drawing.Size(168, 20);
            this.tbSurname.TabIndex = 3;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(149, 284);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.ReadOnly = true;
            this.tbPhone.Size = new System.Drawing.Size(168, 20);
            this.tbPhone.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Время последней оплаты";
            // 
            // tbLastPay
            // 
            this.tbLastPay.Location = new System.Drawing.Point(150, 341);
            this.tbLastPay.Name = "tbLastPay";
            this.tbLastPay.ReadOnly = true;
            this.tbLastPay.Size = new System.Drawing.Size(167, 20);
            this.tbLastPay.TabIndex = 13;
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(149, 318);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            this.tbBalance.Size = new System.Drawing.Size(168, 20);
            this.tbBalance.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Баланс";
            // 
            // tbIdentity
            // 
            this.tbIdentity.BackColor = System.Drawing.SystemColors.Control;
            this.tbIdentity.Location = new System.Drawing.Point(149, 40);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.ReadOnly = true;
            this.tbIdentity.Size = new System.Drawing.Size(168, 20);
            this.tbIdentity.TabIndex = 2;
            // 
            // labelIdentity
            // 
            this.labelIdentity.AutoSize = true;
            this.labelIdentity.Location = new System.Drawing.Point(6, 43);
            this.labelIdentity.Name = "labelIdentity";
            this.labelIdentity.Size = new System.Drawing.Size(50, 13);
            this.labelIdentity.TabIndex = 2;
            this.labelIdentity.Text = "Паспорт";
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(9, 172);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(110, 23);
            this.btnAddNumber.TabIndex = 15;
            this.btnAddNumber.Text = "Добавить номер";
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.btnAddNumber_Click);
            // 
            // lbNumbers
            // 
            this.lbNumbers.FormattingEnabled = true;
            this.lbNumbers.Location = new System.Drawing.Point(6, 19);
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.Size = new System.Drawing.Size(223, 147);
            this.lbNumbers.TabIndex = 14;
            this.lbNumbers.SelectedIndexChanged += new System.EventHandler(this.lbNumbers_SelectedIndexChanged);
            // 
            // groupBoxNumInfo
            // 
            this.groupBoxNumInfo.Controls.Add(this.rbBills);
            this.groupBoxNumInfo.Controls.Add(this.rbCalls);
            this.groupBoxNumInfo.Controls.Add(this.label7);
            this.groupBoxNumInfo.Controls.Add(this.dtEndDate);
            this.groupBoxNumInfo.Controls.Add(this.dtStartDate);
            this.groupBoxNumInfo.Controls.Add(this.label6);
            this.groupBoxNumInfo.Controls.Add(this.label5);
            this.groupBoxNumInfo.Controls.Add(this.btnGetCallDetails);
            this.groupBoxNumInfo.Controls.Add(this.btnChangeTariff);
            this.groupBoxNumInfo.Controls.Add(this.cbRate);
            this.groupBoxNumInfo.Controls.Add(this.label4);
            this.groupBoxNumInfo.Location = new System.Drawing.Point(348, 221);
            this.groupBoxNumInfo.Name = "groupBoxNumInfo";
            this.groupBoxNumInfo.Size = new System.Drawing.Size(235, 181);
            this.groupBoxNumInfo.TabIndex = 1;
            this.groupBoxNumInfo.TabStop = false;
            this.groupBoxNumInfo.Text = "Информация о номере";
            // 
            // rbBills
            // 
            this.rbBills.AutoSize = true;
            this.rbBills.Location = new System.Drawing.Point(77, 149);
            this.rbBills.Name = "rbBills";
            this.rbBills.Size = new System.Drawing.Size(54, 17);
            this.rbBills.TabIndex = 24;
            this.rbBills.Text = "Счета";
            this.rbBills.UseVisualStyleBackColor = true;
            // 
            // rbCalls
            // 
            this.rbCalls.AutoSize = true;
            this.rbCalls.Checked = true;
            this.rbCalls.Location = new System.Drawing.Point(9, 149);
            this.rbCalls.Name = "rbCalls";
            this.rbCalls.Size = new System.Drawing.Size(62, 17);
            this.rbCalls.TabIndex = 23;
            this.rbCalls.TabStop = true;
            this.rbCalls.Text = "Звонки";
            this.rbCalls.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "с";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(53, 120);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(176, 20);
            this.dtEndDate.TabIndex = 22;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(53, 93);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(176, 20);
            this.dtStartDate.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "по";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Детализация за период";
            // 
            // btnGetCallDetails
            // 
            this.btnGetCallDetails.Location = new System.Drawing.Point(138, 146);
            this.btnGetCallDetails.Name = "btnGetCallDetails";
            this.btnGetCallDetails.Size = new System.Drawing.Size(91, 23);
            this.btnGetCallDetails.TabIndex = 25;
            this.btnGetCallDetails.Text = "Детализация";
            this.btnGetCallDetails.UseVisualStyleBackColor = true;
            this.btnGetCallDetails.Click += new System.EventHandler(this.btnGetDetails_Click);
            // 
            // btnChangeTariff
            // 
            this.btnChangeTariff.Location = new System.Drawing.Point(138, 46);
            this.btnChangeTariff.Name = "btnChangeTariff";
            this.btnChangeTariff.Size = new System.Drawing.Size(91, 23);
            this.btnChangeTariff.TabIndex = 20;
            this.btnChangeTariff.Text = "Изменить";
            this.btnChangeTariff.UseVisualStyleBackColor = true;
            this.btnChangeTariff.Click += new System.EventHandler(this.btnChangeRate_Click);
            // 
            // cbRate
            // 
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(99, 19);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(130, 21);
            this.cbRate.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Тарифный план";
            // 
            // groupBoxOps
            // 
            this.groupBoxOps.Controls.Add(this.btnCloseAccount);
            this.groupBoxOps.Controls.Add(this.btnMakeBill);
            this.groupBoxOps.Controls.Add(this.btnAddMoney);
            this.groupBoxOps.Location = new System.Drawing.Point(12, 408);
            this.groupBoxOps.Name = "groupBoxOps";
            this.groupBoxOps.Size = new System.Drawing.Size(571, 67);
            this.groupBoxOps.TabIndex = 2;
            this.groupBoxOps.TabStop = false;
            this.groupBoxOps.Text = "Операции";
            // 
            // btnCloseAccount
            // 
            this.btnCloseAccount.Location = new System.Drawing.Point(180, 20);
            this.btnCloseAccount.Name = "btnCloseAccount";
            this.btnCloseAccount.Size = new System.Drawing.Size(81, 36);
            this.btnCloseAccount.TabIndex = 18;
            this.btnCloseAccount.Text = "Расторгнуть договор";
            this.btnCloseAccount.UseVisualStyleBackColor = true;
            this.btnCloseAccount.Click += new System.EventHandler(this.btnCloseAccount_Click);
            // 
            // btnMakeBill
            // 
            this.btnMakeBill.Location = new System.Drawing.Point(93, 20);
            this.btnMakeBill.Name = "btnMakeBill";
            this.btnMakeBill.Size = new System.Drawing.Size(81, 36);
            this.btnMakeBill.TabIndex = 17;
            this.btnMakeBill.Text = "Выписать счет";
            this.btnMakeBill.UseVisualStyleBackColor = true;
            this.btnMakeBill.Click += new System.EventHandler(this.btnMakeBill_Click);
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.Location = new System.Drawing.Point(7, 20);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(80, 36);
            this.btnAddMoney.TabIndex = 16;
            this.btnAddMoney.Text = "Пополнить баланс";
            this.btnAddMoney.UseVisualStyleBackColor = true;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // groupBoxNumbersList
            // 
            this.groupBoxNumbersList.Controls.Add(this.lbNumbers);
            this.groupBoxNumbersList.Controls.Add(this.btnAddNumber);
            this.groupBoxNumbersList.Location = new System.Drawing.Point(348, 13);
            this.groupBoxNumbersList.Name = "groupBoxNumbersList";
            this.groupBoxNumbersList.Size = new System.Drawing.Size(235, 202);
            this.groupBoxNumbersList.TabIndex = 3;
            this.groupBoxNumbersList.TabStop = false;
            this.groupBoxNumbersList.Text = "Номера абонента";
            // 
            // FormAbonent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 488);
            this.Controls.Add(this.groupBoxNumbersList);
            this.Controls.Add(this.groupBoxOps);
            this.Controls.Add(this.groupBoxNumInfo);
            this.Controls.Add(this.groupBoxAbInfo);
            this.Name = "FormAbonent";
            this.Text = "Абонент";
            this.Load += new System.EventHandler(this.FormAbonent_Load);
            this.groupBoxAbInfo.ResumeLayout(false);
            this.groupBoxAbInfo.PerformLayout();
            this.groupBoxNumInfo.ResumeLayout(false);
            this.groupBoxNumInfo.PerformLayout();
            this.groupBoxOps.ResumeLayout(false);
            this.groupBoxNumbersList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAbInfo;
        private System.Windows.Forms.TextBox tbIdentity;
        private System.Windows.Forms.Label labelIdentity;
        private System.Windows.Forms.ListBox lbNumbers;
        private System.Windows.Forms.GroupBox groupBoxNumInfo;
        private System.Windows.Forms.Button btnGetCallDetails;
        private System.Windows.Forms.Button btnChangeTariff;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxOps;
        private System.Windows.Forms.Button btnCloseAccount;
        private System.Windows.Forms.Button btnMakeBill;
        private System.Windows.Forms.Button btnAddMoney;
        private System.Windows.Forms.Button btnAddNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLastPay;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPassportDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbDepartament;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPatronymic;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox mtbAccountNumber;
        private System.Windows.Forms.GroupBox groupBoxNumbersList;
        private System.Windows.Forms.RadioButton rbBills;
        private System.Windows.Forms.RadioButton rbCalls;
    }
}