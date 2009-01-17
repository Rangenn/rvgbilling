namespace RVGBilling
{
    partial class FormRateList
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
            this.lbRates = new System.Windows.Forms.ListBox();
            this.gbRateDetails = new System.Windows.Forms.GroupBox();
            this.btnRemovePrice = new System.Windows.Forms.Button();
            this.btnEditPrice = new System.Windows.Forms.Button();
            this.btnAddPrice = new System.Windows.Forms.Button();
            this.dgvPrices = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbRateDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRates
            // 
            this.lbRates.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRates.FormattingEnabled = true;
            this.lbRates.Location = new System.Drawing.Point(0, 24);
            this.lbRates.Name = "lbRates";
            this.lbRates.Size = new System.Drawing.Size(120, 238);
            this.lbRates.TabIndex = 0;
            this.lbRates.SelectedIndexChanged += new System.EventHandler(this.lbRates_SelectedIndexChanged);
            // 
            // gbRateDetails
            // 
            this.gbRateDetails.Controls.Add(this.btnRemovePrice);
            this.gbRateDetails.Controls.Add(this.btnEditPrice);
            this.gbRateDetails.Controls.Add(this.btnAddPrice);
            this.gbRateDetails.Controls.Add(this.dgvPrices);
            this.gbRateDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRateDetails.Location = new System.Drawing.Point(120, 24);
            this.gbRateDetails.Name = "gbRateDetails";
            this.gbRateDetails.Size = new System.Drawing.Size(254, 240);
            this.gbRateDetails.TabIndex = 1;
            this.gbRateDetails.TabStop = false;
            this.gbRateDetails.Text = "Маски тарифа";
            // 
            // btnRemovePrice
            // 
            this.btnRemovePrice.AllowDrop = true;
            this.btnRemovePrice.Location = new System.Drawing.Point(167, 205);
            this.btnRemovePrice.Name = "btnRemovePrice";
            this.btnRemovePrice.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePrice.TabIndex = 3;
            this.btnRemovePrice.Text = "Удалить";
            this.btnRemovePrice.UseVisualStyleBackColor = true;
            this.btnRemovePrice.Click += new System.EventHandler(this.btnRemovePrice_Click);
            // 
            // btnEditPrice
            // 
            this.btnEditPrice.Location = new System.Drawing.Point(87, 205);
            this.btnEditPrice.Name = "btnEditPrice";
            this.btnEditPrice.Size = new System.Drawing.Size(75, 23);
            this.btnEditPrice.TabIndex = 2;
            this.btnEditPrice.Text = "Изменить";
            this.btnEditPrice.UseVisualStyleBackColor = true;
            this.btnEditPrice.Click += new System.EventHandler(this.btnEditPrice_Click);
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Location = new System.Drawing.Point(6, 205);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(75, 23);
            this.btnAddPrice.TabIndex = 1;
            this.btnAddPrice.Text = "Добавить";
            this.btnAddPrice.UseVisualStyleBackColor = true;
            this.btnAddPrice.Click += new System.EventHandler(this.btnAddPrice_Click);
            // 
            // dgvPrices
            // 
            this.dgvPrices.AllowUserToAddRows = false;
            this.dgvPrices.AllowUserToDeleteRows = false;
            this.dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrices.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPrices.Location = new System.Drawing.Point(3, 16);
            this.dgvPrices.Name = "dgvPrices";
            this.dgvPrices.ReadOnly = true;
            this.dgvPrices.Size = new System.Drawing.Size(248, 183);
            this.dgvPrices.TabIndex = 0;
            this.dgvPrices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPrices_DataBindingComplete);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rateToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rateToolStripMenuItem
            // 
            this.rateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
            this.rateToolStripMenuItem.Name = "rateToolStripMenuItem";
            this.rateToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.rateToolStripMenuItem.Text = "Тариф";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addToolStripMenuItem.Text = "Создать";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.EditToolStripMenuItem.Text = "Переименовать";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.removeSelectedToolStripMenuItem.Text = "Удалить выделенный";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportExcelToolStripMenuItem,
            this.ExportCsvToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.exportToolStripMenuItem.Text = "Экспорт";
            // 
            // ExportExcelToolStripMenuItem
            // 
            this.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem";
            this.ExportExcelToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.ExportExcelToolStripMenuItem.Text = "Excel";
            this.ExportExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportExcelToolStripMenuItem_Click);
            // 
            // ExportCsvToolStripMenuItem
            // 
            this.ExportCsvToolStripMenuItem.Name = "ExportCsvToolStripMenuItem";
            this.ExportCsvToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.ExportCsvToolStripMenuItem.Text = "CSV";
            this.ExportCsvToolStripMenuItem.Click += new System.EventHandler(this.ExportCSVToolStripMenuItem_Click);
            // 
            // FormRateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 264);
            this.Controls.Add(this.gbRateDetails);
            this.Controls.Add(this.lbRates);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormRateList";
            this.Text = "Тарифные планы";
            this.gbRateDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRates;
        private System.Windows.Forms.GroupBox gbRateDetails;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.Button btnRemovePrice;
        private System.Windows.Forms.Button btnEditPrice;
        private System.Windows.Forms.Button btnAddPrice;
        private System.Windows.Forms.DataGridView dgvPrices;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportCsvToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}