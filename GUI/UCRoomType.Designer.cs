namespace HotelManagementSystem.GUI {
    partial class UCRoomType {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txt_costPerDay = new System.Windows.Forms.TextBox();
            this.txt_roomTypeName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txt_capacity = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txt_numberOfBeds = new System.Windows.Forms.TextBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txt_roomTypeId = new System.Windows.Forms.TextBox();
            this.lblRoomId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgv_ListRoomType = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ListRoomType)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Thông tin loại phòng";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Teal;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(23, 709);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(420, 49);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Xóa phòng";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txt_costPerDay
            // 
            this.txt_costPerDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_costPerDay.Location = new System.Drawing.Point(23, 469);
            this.txt_costPerDay.Margin = new System.Windows.Forms.Padding(4);
            this.txt_costPerDay.Name = "txt_costPerDay";
            this.txt_costPerDay.Size = new System.Drawing.Size(419, 30);
            this.txt_costPerDay.TabIndex = 17;
            // 
            // txt_roomTypeName
            // 
            this.txt_roomTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_roomTypeName.Location = new System.Drawing.Point(23, 210);
            this.txt_roomTypeName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_roomTypeName.Name = "txt_roomTypeName";
            this.txt_roomTypeName.Size = new System.Drawing.Size(419, 30);
            this.txt_roomTypeName.TabIndex = 16;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(249, 634);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(193, 49);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(23, 634);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(193, 49);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(19, 351);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(107, 28);
            this.lblCapacity.TabIndex = 8;
            this.lblCapacity.Text = "Sức chứa";
            // 
            // txt_capacity
            // 
            this.txt_capacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_capacity.Location = new System.Drawing.Point(23, 383);
            this.txt_capacity.Margin = new System.Windows.Forms.Padding(4);
            this.txt_capacity.Name = "txt_capacity";
            this.txt_capacity.Size = new System.Drawing.Size(419, 30);
            this.txt_capacity.TabIndex = 7;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(19, 437);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(44, 28);
            this.lblCost.TabIndex = 6;
            this.lblCost.Text = "Giá";
            // 
            // txt_numberOfBeds
            // 
            this.txt_numberOfBeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numberOfBeds.Location = new System.Drawing.Point(23, 294);
            this.txt_numberOfBeds.Margin = new System.Windows.Forms.Padding(4);
            this.txt_numberOfBeds.Name = "txt_numberOfBeds";
            this.txt_numberOfBeds.Size = new System.Drawing.Size(419, 30);
            this.txt_numberOfBeds.TabIndex = 5;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(19, 262);
            this.lblRoomType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(115, 28);
            this.lblRoomType.TabIndex = 4;
            this.lblRoomType.Text = "Số giường";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(17, 178);
            this.lblRoomName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(162, 28);
            this.lblRoomName.TabIndex = 2;
            this.lblRoomName.Text = "Tên loại phòng";
            // 
            // txt_roomTypeId
            // 
            this.txt_roomTypeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_roomTypeId.Location = new System.Drawing.Point(23, 123);
            this.txt_roomTypeId.Margin = new System.Windows.Forms.Padding(4);
            this.txt_roomTypeId.Name = "txt_roomTypeId";
            this.txt_roomTypeId.Size = new System.Drawing.Size(419, 30);
            this.txt_roomTypeId.TabIndex = 1;
            // 
            // lblRoomId
            // 
            this.lblRoomId.AutoSize = true;
            this.lblRoomId.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomId.Location = new System.Drawing.Point(19, 91);
            this.lblRoomId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomId.Name = "lblRoomId";
            this.lblRoomId.Size = new System.Drawing.Size(221, 28);
            this.lblRoomId.TabIndex = 0;
            this.lblRoomId.Text = "Thông tin loại phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách phòng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtgv_ListRoomType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(507, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1140, 892);
            this.panel2.TabIndex = 5;
            // 
            // dtgv_ListRoomType
            // 
            this.dtgv_ListRoomType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_ListRoomType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_ListRoomType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_ListRoomType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ListRoomType.EnableHeadersVisualStyles = false;
            this.dtgv_ListRoomType.Location = new System.Drawing.Point(25, 63);
            this.dtgv_ListRoomType.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv_ListRoomType.Name = "dtgv_ListRoomType";
            this.dtgv_ListRoomType.RowHeadersVisible = false;
            this.dtgv_ListRoomType.RowHeadersWidth = 51;
            this.dtgv_ListRoomType.Size = new System.Drawing.Size(1093, 810);
            this.dtgv_ListRoomType.TabIndex = 0;
            this.dtgv_ListRoomType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_ListRoomType_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.txt_costPerDay);
            this.panel1.Controls.Add(this.txt_roomTypeName);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblCapacity);
            this.panel1.Controls.Add(this.txt_capacity);
            this.panel1.Controls.Add(this.lblCost);
            this.panel1.Controls.Add(this.txt_numberOfBeds);
            this.panel1.Controls.Add(this.lblRoomType);
            this.panel1.Controls.Add(this.lblRoomName);
            this.panel1.Controls.Add(this.txt_roomTypeId);
            this.panel1.Controls.Add(this.lblRoomId);
            this.panel1.Location = new System.Drawing.Point(20, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 892);
            this.panel1.TabIndex = 4;
            // 
            // UCRoomType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCRoomType";
            this.Size = new System.Drawing.Size(1667, 929);
            this.Load += new System.EventHandler(this.UCRoomType_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ListRoomType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txt_costPerDay;
        private System.Windows.Forms.TextBox txt_roomTypeName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txt_capacity;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txt_numberOfBeds;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.TextBox txt_roomTypeId;
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgv_ListRoomType;
        private System.Windows.Forms.Panel panel1;
    }
}
