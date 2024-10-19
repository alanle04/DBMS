namespace HotelManagementSystem.GUI
{
    partial class UCRevenueDaily
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelDaily = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(223, 93);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(172, 18);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Tổng doanh thu theo ngày là";
            // 
            // labelDaily
            // 
            this.labelDaily.BackColor = System.Drawing.Color.Transparent;
            this.labelDaily.Location = new System.Drawing.Point(468, 93);
            this.labelDaily.Name = "labelDaily";
            this.labelDaily.Size = new System.Drawing.Size(172, 18);
            this.labelDaily.TabIndex = 4;
            this.labelDaily.Text = "Tổng doanh thu theo ngày là";
            this.labelDaily.Click += new System.EventHandler(this.labelDaily_Click);
            // 
            // UCRevenueDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDaily);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "UCRevenueDaily";
            this.Size = new System.Drawing.Size(1265, 690);
            this.Load += new System.EventHandler(this.UCRevenueDaily_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelDaily;
    }
}
