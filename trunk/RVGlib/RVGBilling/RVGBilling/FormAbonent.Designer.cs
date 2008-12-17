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
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.lbNumbers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetDetailes = new System.Windows.Forms.Button();
            this.btnChangeTariff = new System.Windows.Forms.Button();
            this.cbTariff = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Controls.Add(this.btnAddNumber);
            this.groupBox1.Controls.Add(this.lbNumbers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPassport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(7, 89);
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
            this.lbNumbers.Location = new System.Drawing.Point(126, 72);
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.Size = new System.Drawing.Size(176, 82);
            this.lbNumbers.TabIndex = 6;
            this.lbNumbers.SelectedIndexChanged += new System.EventHandler(this.lbNumbers_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номера";
            // 
            // tbPassport
            // 
            this.tbPassport.Location = new System.Drawing.Point(126, 45);
            this.tbPassport.Name = "tbPassport";
            this.tbPassport.Size = new System.Drawing.Size(176, 20);
            this.tbPassport.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Паспортные данные";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(126, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(176, 20);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
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
            this.groupBox2.Controls.Add(this.cbTariff);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 127);
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
            this.btnGetDetailes.Location = new System.Drawing.Point(308, 94);
            this.btnGetDetailes.Name = "btnGetDetailes";
            this.btnGetDetailes.Size = new System.Drawing.Size(91, 23);
            this.btnGetDetailes.TabIndex = 3;
            this.btnGetDetailes.Text = "Детализация";
            this.btnGetDetailes.UseVisualStyleBackColor = true;
            this.btnGetDetailes.Click += new System.EventHandler(this.btnGetDetailes_Click);
            // 
            // btnChangeTariff
            // 
            this.btnChangeTariff.Location = new System.Drawing.Point(308, 17);
            this.btnChangeTariff.Name = "btnChangeTariff";
            this.btnChangeTariff.Size = new System.Drawing.Size(91, 23);
            this.btnChangeTariff.TabIndex = 2;
            this.btnChangeTariff.Text = "Изменить";
            this.btnChangeTariff.UseVisualStyleBackColor = true;
            this.btnChangeTariff.Click += new System.EventHandler(this.btnChangeTariff_Click);
            // 
            // cbTariff
            // 
            this.cbTariff.FormattingEnabled = true;
            this.cbTariff.Location = new System.Drawing.Point(126, 19);
            this.cbTariff.Name = "cbTariff";
            this.cbTariff.Size = new System.Drawing.Size(176, 21);
            this.cbTariff.TabIndex = 1;
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
            this.groupBox3.Location = new System.Drawing.Point(328, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(93, 162);
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
            this.ClientSize = new System.Drawing.Size(431, 314);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbNumbers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetDetailes;
        private System.Windows.Forms.Button btnChangeTariff;
        private System.Windows.Forms.ComboBox cbTariff;
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
    }
}