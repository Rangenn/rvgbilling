namespace RVGBilling
{
    partial class FormCallDetails
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
            this.dgCalls = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalls)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCalls
            // 
            this.dgCalls.AllowUserToAddRows = false;
            this.dgCalls.AllowUserToDeleteRows = false;
            this.dgCalls.AllowUserToOrderColumns = true;
            this.dgCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCalls.Location = new System.Drawing.Point(0, 0);
            this.dgCalls.Name = "dgCalls";
            this.dgCalls.ReadOnly = true;
            this.dgCalls.Size = new System.Drawing.Size(365, 243);
            this.dgCalls.TabIndex = 0;
            // 
            // FormCallDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 243);
            this.Controls.Add(this.dgCalls);
            this.Name = "FormCallDetails";
            this.Text = "Звонки";
            ((System.ComponentModel.ISupportInitialize)(this.dgCalls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCalls;
    }
}