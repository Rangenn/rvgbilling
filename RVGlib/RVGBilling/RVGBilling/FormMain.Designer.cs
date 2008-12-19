namespace RVGBilling
{
    partial class FormMain
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
            this.gbAbonent = new System.Windows.Forms.GroupBox();
            this.tcAbonent = new System.Windows.Forms.TabControl();
            this.tpPerson = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPersonName = new System.Windows.Forms.TextBox();
            this.tbPersonPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPersonPassport = new System.Windows.Forms.TextBox();
            this.tpCorporate = new System.Windows.Forms.TabPage();
            this.tbCorpPhone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCorpAdress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCorpName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tariffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPayment = new System.Windows.Forms.Button();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbBalance = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSumma = new System.Windows.Forms.TextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.buttonHideSearchRes = new System.Windows.Forms.Button();
            this.btnSelectBody = new System.Windows.Forms.Button();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.gbAbonent.SuspendLayout();
            this.tcAbonent.SuspendLayout();
            this.tpPerson.SuspendLayout();
            this.tpCorporate.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.gbBalance.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAbonent
            // 
            this.gbAbonent.Controls.Add(this.tcAbonent);
            this.gbAbonent.Controls.Add(this.btnAdd);
            this.gbAbonent.Controls.Add(this.btnSearch);
            this.gbAbonent.Location = new System.Drawing.Point(12, 27);
            this.gbAbonent.Name = "gbAbonent";
            this.gbAbonent.Size = new System.Drawing.Size(309, 184);
            this.gbAbonent.TabIndex = 0;
            this.gbAbonent.TabStop = false;
            this.gbAbonent.Text = "Абонент";
            // 
            // tcAbonent
            // 
            this.tcAbonent.Controls.Add(this.tpPerson);
            this.tcAbonent.Controls.Add(this.tpCorporate);
            this.tcAbonent.Location = new System.Drawing.Point(6, 19);
            this.tcAbonent.Name = "tcAbonent";
            this.tcAbonent.SelectedIndex = 0;
            this.tcAbonent.Size = new System.Drawing.Size(297, 121);
            this.tcAbonent.TabIndex = 1;
            this.tcAbonent.SelectedIndexChanged += new System.EventHandler(this.tcAbonent_SelectedIndexChanged);
            // 
            // tpPerson
            // 
            this.tpPerson.Controls.Add(this.label6);
            this.tpPerson.Controls.Add(this.label2);
            this.tpPerson.Controls.Add(this.tbPersonName);
            this.tpPerson.Controls.Add(this.tbPersonPhone);
            this.tpPerson.Controls.Add(this.label1);
            this.tpPerson.Controls.Add(this.tbPersonPassport);
            this.tpPerson.Location = new System.Drawing.Point(4, 22);
            this.tpPerson.Name = "tpPerson";
            this.tpPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tpPerson.Size = new System.Drawing.Size(289, 95);
            this.tpPerson.TabIndex = 0;
            this.tpPerson.Text = "Физ. лицо";
            this.tpPerson.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ф.И.О.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тел.";
            // 
            // tbPersonName
            // 
            this.tbPersonName.Location = new System.Drawing.Point(118, 6);
            this.tbPersonName.Name = "tbPersonName";
            this.tbPersonName.Size = new System.Drawing.Size(168, 20);
            this.tbPersonName.TabIndex = 6;
            // 
            // tbPersonPhone
            // 
            this.tbPersonPhone.Location = new System.Drawing.Point(118, 58);
            this.tbPersonPhone.Name = "tbPersonPhone";
            this.tbPersonPhone.Size = new System.Drawing.Size(168, 20);
            this.tbPersonPhone.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Паспортные данные";
            // 
            // tbPersonPassport
            // 
            this.tbPersonPassport.Location = new System.Drawing.Point(118, 32);
            this.tbPersonPassport.Name = "tbPersonPassport";
            this.tbPersonPassport.Size = new System.Drawing.Size(168, 20);
            this.tbPersonPassport.TabIndex = 1;
            // 
            // tpCorporate
            // 
            this.tpCorporate.Controls.Add(this.tbCorpPhone);
            this.tpCorporate.Controls.Add(this.label9);
            this.tpCorporate.Controls.Add(this.tbCorpAdress);
            this.tpCorporate.Controls.Add(this.label8);
            this.tpCorporate.Controls.Add(this.tbCorpName);
            this.tpCorporate.Controls.Add(this.label7);
            this.tpCorporate.Location = new System.Drawing.Point(4, 22);
            this.tpCorporate.Name = "tpCorporate";
            this.tpCorporate.Padding = new System.Windows.Forms.Padding(3);
            this.tpCorporate.Size = new System.Drawing.Size(289, 95);
            this.tpCorporate.TabIndex = 1;
            this.tpCorporate.Text = "Юр. лицо";
            this.tpCorporate.UseVisualStyleBackColor = true;
            // 
            // tbCorpPhone
            // 
            this.tbCorpPhone.Location = new System.Drawing.Point(118, 58);
            this.tbCorpPhone.Name = "tbCorpPhone";
            this.tbCorpPhone.Size = new System.Drawing.Size(165, 20);
            this.tbCorpPhone.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Тел.";
            // 
            // tbCorpAdress
            // 
            this.tbCorpAdress.Location = new System.Drawing.Point(118, 32);
            this.tbCorpAdress.Name = "tbCorpAdress";
            this.tbCorpAdress.Size = new System.Drawing.Size(165, 20);
            this.tbCorpAdress.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Адрес";
            // 
            // tbCorpName
            // 
            this.tbCorpName.Location = new System.Drawing.Point(118, 6);
            this.tbCorpName.Name = "tbCorpName";
            this.tbCorpName.Size = new System.Drawing.Size(165, 20);
            this.tbCorpName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Название";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(123, 147);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(211, 146);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.booksToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(641, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tariffsToolStripMenuItem});
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.booksToolStripMenuItem.Text = "Справочники";
            // 
            // tariffsToolStripMenuItem
            // 
            this.tariffsToolStripMenuItem.Name = "tariffsToolStripMenuItem";
            this.tariffsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.tariffsToolStripMenuItem.Text = "Тарифные планы";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(216, 74);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(87, 23);
            this.btnPayment.TabIndex = 3;
            this.btnPayment.Text = "Пополнить";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(128, 22);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(175, 20);
            this.tbNumber.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Номер тел.";
            // 
            // gbBalance
            // 
            this.gbBalance.Controls.Add(this.label4);
            this.gbBalance.Controls.Add(this.tbSumma);
            this.gbBalance.Controls.Add(this.btnPayment);
            this.gbBalance.Controls.Add(this.label3);
            this.gbBalance.Controls.Add(this.tbNumber);
            this.gbBalance.Location = new System.Drawing.Point(12, 217);
            this.gbBalance.Name = "gbBalance";
            this.gbBalance.Size = new System.Drawing.Size(309, 106);
            this.gbBalance.TabIndex = 6;
            this.gbBalance.TabStop = false;
            this.gbBalance.Text = "Пополнение баланса";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сумма";
            // 
            // tbSumma
            // 
            this.tbSumma.Location = new System.Drawing.Point(128, 48);
            this.tbSumma.Name = "tbSumma";
            this.tbSumma.Size = new System.Drawing.Size(175, 20);
            this.tbSumma.TabIndex = 6;
            // 
            // gbSearch
            // 
            this.gbSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSearch.Controls.Add(this.buttonHideSearchRes);
            this.gbSearch.Controls.Add(this.btnSelectBody);
            this.gbSearch.Controls.Add(this.dgvSearch);
            this.gbSearch.Location = new System.Drawing.Point(328, 28);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(301, 295);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Результаты поиска";
            this.gbSearch.Visible = false;
            // 
            // buttonHideSearchRes
            // 
            this.buttonHideSearchRes.Location = new System.Drawing.Point(7, 263);
            this.buttonHideSearchRes.Name = "buttonHideSearchRes";
            this.buttonHideSearchRes.Size = new System.Drawing.Size(75, 23);
            this.buttonHideSearchRes.TabIndex = 2;
            this.buttonHideSearchRes.Text = "<<<<<<";
            this.buttonHideSearchRes.UseVisualStyleBackColor = true;
            this.buttonHideSearchRes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectBody
            // 
            this.btnSelectBody.Location = new System.Drawing.Point(220, 263);
            this.btnSelectBody.Name = "btnSelectBody";
            this.btnSelectBody.Size = new System.Drawing.Size(75, 23);
            this.btnSelectBody.TabIndex = 1;
            this.btnSelectBody.Text = "Выбрать";
            this.btnSelectBody.UseVisualStyleBackColor = true;
            this.btnSelectBody.Click += new System.EventHandler(this.btnSelectBody_Click);
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AllowUserToOrderColumns = true;
            this.dgvSearch.AllowUserToResizeColumns = false;
            this.dgvSearch.AllowUserToResizeRows = false;
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(7, 20);
            this.dgvSearch.MultiSelect = false;
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new System.Drawing.Size(288, 237);
            this.dgvSearch.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(641, 335);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbBalance);
            this.Controls.Add(this.gbAbonent);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FormMain";
            this.Text = "RVG Billing";
            this.gbAbonent.ResumeLayout(false);
            this.tcAbonent.ResumeLayout(false);
            this.tpPerson.ResumeLayout(false);
            this.tpPerson.PerformLayout();
            this.tpCorporate.ResumeLayout(false);
            this.tpCorporate.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.gbBalance.ResumeLayout(false);
            this.gbBalance.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAbonent;
        private System.Windows.Forms.TextBox tbPersonPassport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPersonPhone;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tariffsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSumma;
        private System.Windows.Forms.TabControl tcAbonent;
        private System.Windows.Forms.TabPage tpPerson;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPersonName;
        private System.Windows.Forms.TabPage tpCorporate;
        private System.Windows.Forms.TextBox tbCorpPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCorpAdress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCorpName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Button btnSelectBody;
        private System.Windows.Forms.Button buttonHideSearchRes;
    }
}

