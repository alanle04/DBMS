namespace HotelManagementSystem
{
    partial class UCBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgv_listBill1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_servicefee = new System.Windows.Forms.TextBox();
            this.txt_roomfee = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBillId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblIdNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_additionfee = new System.Windows.Forms.TextBox();
            this.txtCusname = new System.Windows.Forms.TextBox();
            this.txt_staff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_paymethod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_listBill1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgv_listBill1
            // 
            this.dtgv_listBill1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_listBill1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_listBill1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_listBill1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_listBill1.EnableHeadersVisualStyles = false;
            this.dtgv_listBill1.Location = new System.Drawing.Point(25, 63);
            this.dtgv_listBill1.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv_listBill1.Name = "dtgv_listBill1";
            this.dtgv_listBill1.RowHeadersVisible = false;
            this.dtgv_listBill1.RowHeadersWidth = 51;
            this.dtgv_listBill1.Size = new System.Drawing.Size(1011, 809);
            this.dtgv_listBill1.TabIndex = 0;
            this.dtgv_listBill1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_listBill1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bill Information";
            // 
            // txt_total
            // 
            this.txt_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(27, 534);
            this.txt_total.Margin = new System.Windows.Forms.Padding(4);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(419, 30);
            this.txt_total.TabIndex = 11;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(23, 508);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 23);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Total:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(23, 425);
            this.lblNationality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(150, 23);
            this.lblNationality.TabIndex = 8;
            this.lblNationality.Text = "Additional fee:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtgv_listBill1);
            this.panel2.Location = new System.Drawing.Point(507, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1055, 892);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "A list of bills";
            // 
            // txt_servicefee
            // 
            this.txt_servicefee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_servicefee.Location = new System.Drawing.Point(27, 364);
            this.txt_servicefee.Margin = new System.Windows.Forms.Padding(4);
            this.txt_servicefee.Name = "txt_servicefee";
            this.txt_servicefee.Size = new System.Drawing.Size(419, 30);
            this.txt_servicefee.TabIndex = 7;
            // 
            // txt_roomfee
            // 
            this.txt_roomfee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_roomfee.Location = new System.Drawing.Point(27, 276);
            this.txt_roomfee.Margin = new System.Windows.Forms.Padding(4);
            this.txt_roomfee.Name = "txt_roomfee";
            this.txt_roomfee.Size = new System.Drawing.Size(419, 30);
            this.txt_roomfee.TabIndex = 5;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(23, 250);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(108, 23);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Room fee:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer:";
            // 
            // txtBillId
            // 
            this.txtBillId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillId.Location = new System.Drawing.Point(27, 105);
            this.txtBillId.Margin = new System.Windows.Forms.Padding(4);
            this.txtBillId.Name = "txtBillId";
            this.txtBillId.Size = new System.Drawing.Size(419, 30);
            this.txtBillId.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(23, 79);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(71, 23);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Bill ID:";
            // 
            // lblIdNumber
            // 
            this.lblIdNumber.AutoSize = true;
            this.lblIdNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdNumber.Location = new System.Drawing.Point(23, 338);
            this.lblIdNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdNumber.Name = "lblIdNumber";
            this.lblIdNumber.Size = new System.Drawing.Size(126, 23);
            this.lblIdNumber.TabIndex = 6;
            this.lblIdNumber.Text = "Service fee:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_additionfee);
            this.panel1.Controls.Add(this.txtCusname);
            this.panel1.Controls.Add(this.txt_staff);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_paymethod);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_total);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.lblNationality);
            this.panel1.Controls.Add(this.txt_servicefee);
            this.panel1.Controls.Add(this.lblIdNumber);
            this.panel1.Controls.Add(this.txt_roomfee);
            this.panel1.Controls.Add(this.lblPhoneNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBillId);
            this.panel1.Controls.Add(this.lblFullName);
            this.panel1.Location = new System.Drawing.Point(20, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 892);
            this.panel1.TabIndex = 2;
            // 
            // txt_additionfee
            // 
            this.txt_additionfee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_additionfee.Location = new System.Drawing.Point(27, 450);
            this.txt_additionfee.Margin = new System.Windows.Forms.Padding(4);
            this.txt_additionfee.Name = "txt_additionfee";
            this.txt_additionfee.Size = new System.Drawing.Size(419, 30);
            this.txt_additionfee.TabIndex = 22;
            // 
            // txtCusname
            // 
            this.txtCusname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusname.Location = new System.Drawing.Point(27, 192);
            this.txtCusname.Margin = new System.Windows.Forms.Padding(4);
            this.txtCusname.Name = "txtCusname";
            this.txtCusname.Size = new System.Drawing.Size(419, 30);
            this.txtCusname.TabIndex = 21;
            // 
            // txt_staff
            // 
            this.txt_staff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_staff.Location = new System.Drawing.Point(27, 704);
            this.txt_staff.Margin = new System.Windows.Forms.Padding(4);
            this.txt_staff.Name = "txt_staff";
            this.txt_staff.Size = new System.Drawing.Size(419, 30);
            this.txt_staff.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 678);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Receptionist:";
            // 
            // txt_paymethod
            // 
            this.txt_paymethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paymethod.Location = new System.Drawing.Point(27, 619);
            this.txt_paymethod.Margin = new System.Windows.Forms.Padding(4);
            this.txt_paymethod.Name = "txt_paymethod";
            this.txt_paymethod.Size = new System.Drawing.Size(419, 30);
            this.txt_paymethod.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 593);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Payment method:";
            // 
            // UCBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCBill";
            this.Size = new System.Drawing.Size(1577, 925);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_listBill1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_listBill1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_servicefee;
        private System.Windows.Forms.TextBox txt_roomfee;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBillId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_staff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_paymethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_additionfee;
        private System.Windows.Forms.TextBox txtCusname;
    }
}
