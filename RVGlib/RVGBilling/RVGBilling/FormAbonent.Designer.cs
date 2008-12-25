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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLastPay = new System.Windows.Forms.TextBox();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.lbNumbers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbIdentity = new System.Windows.Forms.TextBox();
            this.labelIdentity = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetDetailes = new System.Windows.Forms.Button();
            this.btnChangeTariff = new System.Windows.Forms.Button();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCloseAccount = new System.Windows.Forms.Button();
            this.btnMakeBill = new System.Windows.Forms.Button();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbLastPay);
            this.groupBox1.Controls.Add(this.tbBalance);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnAddNumber);
            this.groupBox1.Controls.Add(this.lbNumbers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbIdentity);
            this.groupBox1.Controls.Add(this.labelIdentity);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Время последней оплаты";
            // 
            // tbLastPay
            // 
            this.tbLastPay.Location = new System.Drawing.Point(150, 97);
            this.tbLastPay.Name = "tbLastPay";
            this.tbLastPay.ReadOnly = true;
            this.tbLastPay.Size = new System.Drawing.Size(175, 20);
            this.tbLastPay.TabIndex = 10;
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(149, 71);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            this.tbBalance.Size = new System.Drawing.Size(176, 20);
            this.tbBalance.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Баланс";
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(15, 146);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(110, 23);
            this.btnAddNumber.TabIndex = 7;
            this.btnAddNumber.Text = "Добавить номер";
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.btnAddNumber_Click);
            // 
            // lbNumbers
            // 
            this.lbNumbers.FormattingEnabled = true;
            this.lbNumbers.Location = new System.Drawing.Point(149, 136);
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.Size = new System.Drawing.Size(176, 147);
            this.lbNumbers.TabIndex = 6;
            this.lbNumbers.SelectedIndexChanged += new System.EventHandler(this.lbNumbers_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номера";
            // 
            // tbIdentity
            // 
            this.tbIdentity.Location = new System.Drawing.Point(149, 45);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.ReadOnly = true;
            this.tbIdentity.Size = new System.Drawing.Size(176, 20);
            this.tbIdentity.TabIndex = 3;
            // 
            // labelIdentity
            // 
            this.labelIdentity.AutoSize = true;
            this.labelIdentity.Location = new System.Drawing.Point(6, 48);
            this.labelIdentity.Name = "labelIdentity";
            this.labelIdentity.Size = new System.Drawing.Size(111, 13);
            this.labelIdentity.TabIndex = 2;
            this.labelIdentity.Text = "Паспортные данные";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(149, 19);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(176, 20);
            this.tbName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(34, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "ФИО";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtEndDate);
            this.groupBox2.Controls.Add(this.dtStartDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnGetDetailes);
            this.groupBox2.Controls.Add(this.btnChangeTariff);
            this.groupBox2.Controls.Add(this.cbRate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о номере";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "с";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(126, 97);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(176, 20);
            this.dtEndDate.TabIndex = 9;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(126, 70);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(176, 20);
            this.dtStartDate.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "по";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Детализация за период";
            // 
            // btnGetDetailes
            // 
            this.btnGetDetailes.Location = new System.Drawing.Point(318, 94);
            this.btnGetDetailes.Name = "btnGetDetailes";
            this.btnGetDetailes.Size = new System.Drawing.Size(91, 23);
            this.btnGetDetailes.TabIndex = 3;
            this.btnGetDetailes.Text = "Детализация";
            this.btnGetDetailes.UseVisualStyleBackColor = true;
            this.btnGetDetailes.Click += new System.EventHandler(this.btnGetDetailes_Click);
            // 
            // btnChangeTariff
            // 
            this.btnChangeTariff.Location = new System.Drawing.Point(318, 17);
            this.btnChangeTariff.Name = "btnChangeTariff";
            this.btnChangeTariff.Size = new System.Drawing.Size(91, 23);
            this.btnChangeTariff.TabIndex = 2;
            this.btnChangeTariff.Text = "Изменить";
            this.btnChangeTariff.UseVisualStyleBackColor = true;
            this.btnChangeTariff.Click += new System.EventHandler(this.btnChangeRate_Click);
            // 
            // cbRate
            // 
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(126, 19);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(176, 21);
            this.cbRate.TabIndex = 1;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCloseAccount);
            this.groupBox3.Controls.Add(this.btnMakeBill);
            this.groupBox3.Controls.Add(this.btnAddMoney);
            this.groupBox3.Location = new System.Drawing.Point(355, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(93, 295);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Операции";
            // 
            // btnCloseAccount
            // 
            this.btnCloseAccount.Location = new System.Drawing.Point(6, 118);
            this.btnCloseAccount.Name = "btnCloseAccount";
            this.btnCloseAccount.Size = new System.Drawing.Size(75, 36);
            this.btnCloseAccount.TabIndex = 2;
            this.btnCloseAccount.Text = "Закрыть счет";
            this.btnCloseAccount.UseVisualStyleBackColor = true;
            // 
            // btnMakeBill
            // 
            this.btnMakeBill.Location = new System.Drawing.Point(6, 69);
            this.btnMakeBill.Name = "btnMakeBill";
            this.btnMakeBill.Size = new System.Drawing.Size(75, 36);
            this.btnMakeBill.TabIndex = 1;
            this.btnMakeBill.Text = "Выписать счет";
            this.btnMakeBill.UseVisualStyleBackColor = true;
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.Location = new System.Drawing.Point(7, 20);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(75, 36);
            this.btnAddMoney.TabIndex = 0;
            this.btnAddMoney.Text = "Пополнить баланс";
            this.btnAddMoney.UseVisualStyleBackColor = true;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // FormAbonent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 453);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAbonent";
            this.Text = "Абонент";
            this.Load += new System.EventHandler(this.FormAbonent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbIdentity;
        private System.Windows.Forms.Label labelIdentity;
        private System.Windows.Forms.ListBox lbNumbers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetDetailes;
        private System.Windows.Forms.Button btnChangeTariff;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCloseAccount;
        private System.Windows.Forms.Button btnMakeBill;
        private System.Windows.Forms.Button btnAddMoney;
        private System.Windows.Forms.Button btnAddNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLastPay;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.Label label8;
    }
}