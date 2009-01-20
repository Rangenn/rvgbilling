namespace RVGBilling
{
    partial class FormPrice
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
            this.lMask = new System.Windows.Forms.Label();
            this.lCost = new System.Windows.Forms.Label();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mtbMask = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lMask
            // 
            this.lMask.AutoSize = true;
            this.lMask.Location = new System.Drawing.Point(15, 21);
            this.lMask.Name = "lMask";
            this.lMask.Size = new System.Drawing.Size(87, 13);
            this.lMask.TabIndex = 0;
            this.lMask.Text = "Маска номеров";
            // 
            // lCost
            // 
            this.lCost.AutoSize = true;
            this.lCost.Location = new System.Drawing.Point(15, 55);
            this.lCost.Name = "lCost";
            this.lCost.Size = new System.Drawing.Size(86, 13);
            this.lCost.TabIndex = 1;
            this.lCost.Text = "Цена за минуту";
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(123, 52);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(100, 20);
            this.tbCost.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(18, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(148, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // mtbMask
            // 
            this.mtbMask.Location = new System.Drawing.Point(123, 18);
            this.mtbMask.Mask = "0000000000";
            this.mtbMask.Name = "mtbMask";
            this.mtbMask.Size = new System.Drawing.Size(100, 20);
            this.mtbMask.TabIndex = 5;
            // 
            // FormPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 114);
            this.Controls.Add(this.mtbMask);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.lCost);
            this.Controls.Add(this.lMask);
            this.Name = "FormPrice";
            this.Text = "Цена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lMask;
        private System.Windows.Forms.Label lCost;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox mtbMask;
    }
}