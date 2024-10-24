namespace HotelManagementSystem
{
    partial class UCCheckIn
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
            this.txtCheckInDate = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCheckOutDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRoomTypeName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvCheckInRooms = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearchByIdNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchByIdNumber = new System.Windows.Forms.TextBox();
            this.txtBookingRecordId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInRooms)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCheckInDate
            // 
            this.txtCheckInDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInDate.Location = new System.Drawing.Point(48, 435);
            this.txtCheckInDate.Name = "txtCheckInDate";
            this.txtCheckInDate.Size = new System.Drawing.Size(315, 26);
            this.txtCheckInDate.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtBookingRecordId);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtPrice);
            this.panel3.Controls.Add(this.btnCheckIn);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtCapacity);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtIdNumber);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtFullName);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtCheckOutDate);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtCheckInDate);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtRoomTypeName);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtRoomName);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(15, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(416, 725);
            this.panel3.TabIndex = 40;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(48, 635);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(315, 26);
            this.txtPrice.TabIndex = 41;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.Teal;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(48, 674);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(315, 40);
            this.btnCheckIn.TabIndex = 36;
            this.btnCheckIn.Text = "NHẬN PHÒNG";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 614);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 40;
            this.label4.Text = "Giá:";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacity.Location = new System.Drawing.Point(48, 575);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(315, 26);
            this.txtCapacity.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(45, 554);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 19);
            this.label9.TabIndex = 38;
            this.label9.Text = "Sức chứa:";
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdNumber.Location = new System.Drawing.Point(48, 218);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(315, 26);
            this.txtIdNumber.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 19);
            this.label6.TabIndex = 36;
            this.label6.Text = "CMND/CCCD:";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(48, 154);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(315, 26);
            this.txtFullName.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Họ và tên:";
            // 
            // txtCheckOutDate
            // 
            this.txtCheckOutDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutDate.Location = new System.Drawing.Point(49, 503);
            this.txtCheckOutDate.Name = "txtCheckOutDate";
            this.txtCheckOutDate.Size = new System.Drawing.Size(315, 26);
            this.txtCheckOutDate.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(46, 482);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 19);
            this.label15.TabIndex = 32;
            this.label15.Text = "Ngày check out:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(45, 414);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 19);
            this.label14.TabIndex = 30;
            this.label14.Text = "Ngày check in:";
            // 
            // txtRoomTypeName
            // 
            this.txtRoomTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomTypeName.Location = new System.Drawing.Point(48, 366);
            this.txtRoomTypeName.Name = "txtRoomTypeName";
            this.txtRoomTypeName.Size = new System.Drawing.Size(315, 26);
            this.txtRoomTypeName.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(45, 345);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 19);
            this.label13.TabIndex = 28;
            this.label13.Text = "Loại phòng:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomName.Location = new System.Drawing.Point(49, 289);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(315, 26);
            this.txtRoomName.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(46, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 26;
            this.label12.Text = "Tên phòng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Thông tin nhận phòng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(248, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "Danh sách phòng check in";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvCheckInRooms);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(447, 97);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(788, 643);
            this.panel5.TabIndex = 42;
            // 
            // dgvCheckInRooms
            // 
            this.dgvCheckInRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckInRooms.Location = new System.Drawing.Point(0, 42);
            this.dgvCheckInRooms.Name = "dgvCheckInRooms";
            this.dgvCheckInRooms.Size = new System.Drawing.Size(788, 601);
            this.dgvCheckInRooms.TabIndex = 3;
            this.dgvCheckInRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckInRooms_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnSearchByIdNumber);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtSearchByIdNumber);
            this.panel4.Location = new System.Drawing.Point(445, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(790, 76);
            this.panel4.TabIndex = 43;
            // 
            // btnSearchByIdNumber
            // 
            this.btnSearchByIdNumber.BackColor = System.Drawing.Color.Teal;
            this.btnSearchByIdNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByIdNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByIdNumber.ForeColor = System.Drawing.Color.White;
            this.btnSearchByIdNumber.Location = new System.Drawing.Point(616, 15);
            this.btnSearchByIdNumber.Name = "btnSearchByIdNumber";
            this.btnSearchByIdNumber.Size = new System.Drawing.Size(158, 40);
            this.btnSearchByIdNumber.TabIndex = 27;
            this.btnSearchByIdNumber.Text = "TÌM";
            this.btnSearchByIdNumber.UseVisualStyleBackColor = false;
            this.btnSearchByIdNumber.Click += new System.EventHandler(this.btnSearchByIdNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tìm khách hàng theo CMND/CCCD:";
            // 
            // txtSearchByIdNumber
            // 
            this.txtSearchByIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByIdNumber.Location = new System.Drawing.Point(363, 23);
            this.txtSearchByIdNumber.Name = "txtSearchByIdNumber";
            this.txtSearchByIdNumber.Size = new System.Drawing.Size(248, 26);
            this.txtSearchByIdNumber.TabIndex = 22;
            // 
            // txtBookingRecordId
            // 
            this.txtBookingRecordId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookingRecordId.Location = new System.Drawing.Point(48, 90);
            this.txtBookingRecordId.Name = "txtBookingRecordId";
            this.txtBookingRecordId.Size = new System.Drawing.Size(315, 26);
            this.txtBookingRecordId.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Mã đặt phòng:";
            // 
            // UCCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "UCCheckIn";
            this.Size = new System.Drawing.Size(1250, 755);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckInRooms)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCheckInDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCheckOutDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRoomTypeName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvCheckInRooms;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearchByIdNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchByIdNumber;
        private System.Windows.Forms.TextBox txtBookingRecordId;
        private System.Windows.Forms.Label label2;
    }
}
