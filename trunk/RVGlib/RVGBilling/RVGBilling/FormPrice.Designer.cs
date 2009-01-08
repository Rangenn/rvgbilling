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
            this.tbMask = new System.Windows.Forms.TextBox();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            // tbMask
            // 
            this.tbMask.Location = new System.Drawing.Point(138, 18);
            this.tbMask.Name = "tbMask";
            this.tbMask.Size = new System.Drawing.Size(100, 20);
            this.tbMask.TabIndex = 2;
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(138, 52);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(100, 20);
            this.tbCost.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(28, 89);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(148, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 127);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.tbMask);
            this.Controls.Add(this.lCost);
            this.Controls.Add(this.lMask);
            this.Name = "FormPrice";
            this.Text = "FormPrice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lMask;
        private System.Windows.Forms.Label lCost;
        private System.Windows.Forms.TextBox tbMask;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}