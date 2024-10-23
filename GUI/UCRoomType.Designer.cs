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
            this.lblManager = new System.Windows.Forms.Label();
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
            this.cbManagerID = new System.Windows.Forms.ComboBox();
            this.btn_excute = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ListRoomType)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Room type Information";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Teal;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(23, 709);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(420, 49);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManager.Location = new System.Drawing.Point(19, 537);
            this.lblManager.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(103, 23);
            this.lblManager.TabIndex = 18;
            this.lblManager.Text = "Manager:";
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
            this.btnUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(249, 634);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(193, 49);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblCapacity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(19, 356);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(103, 23);
            this.lblCapacity.TabIndex = 8;
            this.lblCapacity.Text = "Capacity:";
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
            this.lblCost.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(19, 442);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(137, 23);
            this.lblCost.TabIndex = 6;
            this.lblCost.Text = "Cost Per Day";
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
            this.lblRoomType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(19, 268);
            this.lblRoomType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(167, 23);
            this.lblRoomType.TabIndex = 4;
            this.lblRoomType.Text = "Number Of Bed:";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(19, 185);
            this.lblRoomName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(188, 23);
            this.lblRoomName.TabIndex = 2;
            this.lblRoomName.Text = "Room Type Name:";
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
            this.lblRoomId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomId.Location = new System.Drawing.Point(19, 97);
            this.lblRoomId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomId.Name = "lblRoomId";
            this.lblRoomId.Size = new System.Drawing.Size(152, 23);
            this.lblRoomId.TabIndex = 0;
            this.lblRoomId.Text = "Room Type ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "A list of room type";
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
            this.panel1.Controls.Add(this.btn_excute);
            this.panel1.Controls.Add(this.cbManagerID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lblManager);
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
            // cbManagerID
            // 
            this.cbManagerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbManagerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbManagerID.DropDownWidth = 250;
            this.cbManagerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManagerID.FormattingEnabled = true;
            this.cbManagerID.Items.AddRange(new object[] {
            "Afghan",
            "",
            "Albanian",
            "",
            "Algerian",
            "",
            "American",
            "",
            "Andorran",
            "",
            "Angolan",
            "",
            "Antiguan",
            "",
            "Argentine",
            "",
            "Armenian",
            "",
            "Australian",
            "",
            "Austrian",
            "",
            "Azerbaijani",
            "",
            "Bahamian",
            "",
            "Bahraini",
            "",
            "Bangladeshi",
            "",
            "Barbadian",
            "",
            "Belarusian",
            "",
            "Belgian",
            "",
            "Belizean",
            "",
            "Beninese",
            "",
            "Bhutanese",
            "",
            "Bolivian",
            "",
            "Bosnian ",
            "",
            "Botswanan",
            "",
            "Brazilian",
            "",
            "British",
            "",
            "Bruneian",
            "",
            "Bulgarian",
            "",
            "Burkinabe",
            "",
            "Burmese",
            "",
            "Burundian",
            "",
            "Cambodian",
            "",
            "Cameroonian",
            "",
            "Canadian",
            "",
            "Cape Verdean",
            "",
            "Central African",
            "",
            "Chadian",
            "",
            "Chilean",
            "",
            "Chinese",
            "",
            "Colombian",
            "",
            "Comoran",
            "",
            "Congolese (Congo-Brazzaville)",
            "",
            "Congolese (Congo-Kinshasa)",
            "",
            "Costa Rican",
            "",
            "Croatian",
            "",
            "Cuban",
            "",
            "Cypriot",
            "",
            "Czech",
            "",
            "Danish",
            "",
            "Djiboutian",
            "",
            "Dominican",
            "",
            "Dutch",
            "",
            "East Timorese",
            "",
            "Ecuadorean",
            "",
            "Egyptian",
            "",
            "Emirati",
            "",
            "Equatorial Guinean",
            "",
            "Eritrean",
            "",
            "Estonian",
            "",
            "Ethiopian",
            "",
            "Fijian",
            "",
            "Finnish",
            "",
            "French",
            "",
            "Gabonese",
            "",
            "Gambian",
            "",
            "Georgian",
            "",
            "German",
            "",
            "Ghanaian",
            "",
            "Greek",
            "",
            "Grenadian",
            "",
            "Guatemalan",
            "",
            "Guinean",
            "",
            "Guinea-Bissauan",
            "",
            "Guyanese",
            "",
            "Haitian",
            "",
            "Honduran",
            "",
            "Hungarian",
            "",
            "Icelandic",
            "",
            "Indian",
            "",
            "Indonesian",
            "",
            "Iranian",
            "",
            "Iraqi",
            "",
            "Irish",
            "",
            "Israeli",
            "",
            "Italian",
            "",
            "Ivorian",
            "",
            "Jamaican",
            "",
            "Japanese",
            "",
            "Jordanian",
            "",
            "Kazakh",
            "",
            "Kenyan",
            "",
            "Kiribati",
            "",
            "Kuwaiti",
            "",
            "Kyrgyz",
            "",
            "Laotian",
            "",
            "Latvian",
            "",
            "Lebanese",
            "",
            "Lesotho",
            "",
            "Liberian",
            "",
            "Libyan",
            "",
            "Liechtenstein",
            "",
            "Lithuanian",
            "",
            "Luxembourgish",
            "",
            "Macedonian",
            "",
            "Malagasy",
            "",
            "Malawian",
            "",
            "Malaysian",
            "",
            "Maldivian",
            "",
            "Malian",
            "",
            "Maltese",
            "",
            "Marshallese",
            "",
            "Mauritanian",
            "",
            "Mauritian",
            "",
            "Mexican",
            "",
            "Micronesian",
            "",
            "Moldovan",
            "",
            "Monacan",
            "",
            "Mongolian",
            "",
            "Montenegrin",
            "",
            "Moroccan",
            "",
            "Mozambican",
            "",
            "Namibian",
            "",
            "Nauruan",
            "",
            "Nepalese",
            "",
            "New Zealander",
            "",
            "Nicaraguan",
            "",
            "Nigerian",
            "",
            "Nigerien",
            "",
            "North Korean",
            "",
            "Norwegian",
            "",
            "Omani",
            "",
            "Pakistani",
            "",
            "Palauan",
            "",
            "Panamanian",
            "",
            "Papua New Guinean",
            "",
            "Paraguayan",
            "",
            "Peruvian",
            "",
            "Philippine",
            "",
            "Polish",
            "",
            "Portuguese",
            "",
            "Qatari",
            "",
            "Romanian",
            "",
            "Russian",
            "",
            "Rwandan",
            "",
            "Saint Lucian",
            "",
            "Salvadoran",
            "",
            "Samoan",
            "",
            "San Marinese",
            "",
            "Sao Tomean",
            "",
            "Saudi",
            "",
            "Senegalese",
            "",
            "Serbian",
            "",
            "Seychellois",
            "",
            "Sierra Leonean",
            "",
            "Singaporean",
            "",
            "Slovak",
            "",
            "Slovenian",
            "",
            "Solomon Islander",
            "",
            "Somali",
            "",
            "South African",
            "",
            "South Korean",
            "",
            "Spanish",
            "",
            "Sri Lankan",
            "",
            "Sudanese",
            "",
            "Surinamese",
            "",
            "Swazi",
            "",
            "Swedish",
            "",
            "Swiss",
            "",
            "Syrian",
            "",
            "Taiwanese",
            "",
            "Tajik",
            "",
            "Tanzanian",
            "",
            "Thai",
            "",
            "Togolese",
            "",
            "Tongan",
            "",
            "Trinidadian or Tobagonian",
            "",
            "Tunisian",
            "",
            "Turkish",
            "",
            "Turkmen",
            "",
            "Tuvaluan",
            "",
            "Ugandan",
            "",
            "Ukrainian",
            "",
            "Uruguayan",
            "",
            "Uzbek",
            "",
            "Vanuatuan",
            "",
            "Venezuelan",
            "",
            "Vietnamese",
            "",
            "Yemeni",
            "",
            "Zambian",
            "",
            "Zimbabwean"});
            this.cbManagerID.Location = new System.Drawing.Point(23, 564);
            this.cbManagerID.Margin = new System.Windows.Forms.Padding(4);
            this.cbManagerID.Name = "cbManagerID";
            this.cbManagerID.Size = new System.Drawing.Size(419, 33);
            this.cbManagerID.TabIndex = 25;
            // 
            // btn_excute
            // 
            this.btn_excute.BackColor = System.Drawing.Color.Teal;
            this.btn_excute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excute.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excute.ForeColor = System.Drawing.Color.White;
            this.btn_excute.Location = new System.Drawing.Point(22, 778);
            this.btn_excute.Margin = new System.Windows.Forms.Padding(4);
            this.btn_excute.Name = "btn_excute";
            this.btn_excute.Size = new System.Drawing.Size(420, 49);
            this.btn_excute.TabIndex = 26;
            this.btn_excute.Text = "Thực hiện";
            this.btn_excute.UseVisualStyleBackColor = false;
            this.btn_excute.Click += new System.EventHandler(this.btn_excute_Click);
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
        private System.Windows.Forms.Label lblManager;
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
        private System.Windows.Forms.ComboBox cbManagerID;
        private System.Windows.Forms.Button btn_excute;
    }
}
