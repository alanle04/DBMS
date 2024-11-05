namespace HotelManagementSystem
{
    partial class UCServiceAndPayment
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
            this.dtgv_bill = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_bookService = new System.Windows.Forms.Button();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_searchByRoom = new System.Windows.Forms.Button();
            this.txt_roomId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cb_ServiceType = new System.Windows.Forms.ComboBox();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgv_serviceUsage = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_bill)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_serviceUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_bill
            // 
            this.dtgv_bill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_bill.Location = new System.Drawing.Point(0, 39);
            this.dtgv_bill.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv_bill.Name = "dtgv_bill";
            this.dtgv_bill.RowHeadersWidth = 51;
            this.dtgv_bill.Size = new System.Drawing.Size(1051, 86);
            this.dtgv_bill.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 28);
            this.label8.TabIndex = 4;
            this.label8.Text = "Hóa đơn phòng";
            // 
            // btn_bookService
            // 
            this.btn_bookService.BackColor = System.Drawing.Color.Teal;
            this.btn_bookService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bookService.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bookService.ForeColor = System.Drawing.Color.White;
            this.btn_bookService.Location = new System.Drawing.Point(79, 410);
            this.btn_bookService.Margin = new System.Windows.Forms.Padding(4);
            this.btn_bookService.Name = "btn_bookService";
            this.btn_bookService.Size = new System.Drawing.Size(420, 49);
            this.btn_bookService.TabIndex = 36;
            this.btn_bookService.Text = "ADD";
            this.btn_bookService.UseVisualStyleBackColor = false;
            this.btn_bookService.Click += new System.EventHandler(this.btn_bookService_Click);
            // 
            // txt_price
            // 
            this.txt_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.Location = new System.Drawing.Point(79, 255);
            this.txt_price.Margin = new System.Windows.Forms.Padding(4);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(419, 30);
            this.txt_price.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 24);
            this.label6.TabIndex = 36;
            this.label6.Text = "Giá";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_searchByRoom);
            this.panel1.Controls.Add(this.txt_roomId);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(20, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 128);
            this.panel1.TabIndex = 43;
            // 
            // btn_searchByRoom
            // 
            this.btn_searchByRoom.BackColor = System.Drawing.Color.Teal;
            this.btn_searchByRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_searchByRoom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_searchByRoom.ForeColor = System.Drawing.Color.White;
            this.btn_searchByRoom.Location = new System.Drawing.Point(309, 45);
            this.btn_searchByRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btn_searchByRoom.Name = "btn_searchByRoom";
            this.btn_searchByRoom.Size = new System.Drawing.Size(173, 49);
            this.btn_searchByRoom.TabIndex = 38;
            this.btn_searchByRoom.Text = "SEARCH";
            this.btn_searchByRoom.UseVisualStyleBackColor = false;
            this.btn_searchByRoom.Click += new System.EventHandler(this.btn_searchByRoom_Click);
            // 
            // txt_roomId
            // 
            this.txt_roomId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_roomId.Location = new System.Drawing.Point(64, 64);
            this.txt_roomId.Margin = new System.Windows.Forms.Padding(4);
            this.txt_roomId.Name = "txt_roomId";
            this.txt_roomId.Size = new System.Drawing.Size(237, 30);
            this.txt_roomId.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 24);
            this.label7.TabIndex = 24;
            this.label7.Text = "Tìm phòng theo mã";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "Loại dịch vụ";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dtgv_bill);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(596, 18);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1051, 126);
            this.panel5.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(75, 317);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 24);
            this.label12.TabIndex = 26;
            this.label12.Text = "Số lượng";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cb_ServiceType);
            this.panel3.Controls.Add(this.btn_bookService);
            this.panel3.Controls.Add(this.txt_price);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_quantity);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(20, 154);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 756);
            this.panel3.TabIndex = 44;
            // 
            // cb_ServiceType
            // 
            this.cb_ServiceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_ServiceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_ServiceType.DropDownWidth = 250;
            this.cb_ServiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ServiceType.FormattingEnabled = true;
            this.cb_ServiceType.Items.AddRange(new object[] {
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
            this.cb_ServiceType.Location = new System.Drawing.Point(80, 180);
            this.cb_ServiceType.Margin = new System.Windows.Forms.Padding(4);
            this.cb_ServiceType.Name = "cb_ServiceType";
            this.cb_ServiceType.Size = new System.Drawing.Size(419, 33);
            this.cb_ServiceType.TabIndex = 38;
            this.cb_ServiceType.SelectedValueChanged += new System.EventHandler(this.cb_ServiceType_SelectedValueChanged);
            // 
            // txt_quantity
            // 
            this.txt_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quantity.Location = new System.Drawing.Point(79, 343);
            this.txt_quantity.Margin = new System.Windows.Forms.Padding(4);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(419, 30);
            this.txt_quantity.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = "Sử dụng dịch vụ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.dtgv_serviceUsage);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(596, 155);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1051, 756);
            this.panel4.TabIndex = 47;
            // 
            // dtgv_serviceUsage
            // 
            this.dtgv_serviceUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_serviceUsage.Location = new System.Drawing.Point(0, 39);
            this.dtgv_serviceUsage.Margin = new System.Windows.Forms.Padding(4);
            this.dtgv_serviceUsage.Name = "dtgv_serviceUsage";
            this.dtgv_serviceUsage.RowHeadersWidth = 51;
            this.dtgv_serviceUsage.Size = new System.Drawing.Size(1051, 716);
            this.dtgv_serviceUsage.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hóa đơn dịch vụ";
            // 
            // UCServiceAndPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCServiceAndPayment";
            this.Size = new System.Drawing.Size(1667, 929);
            this.Load += new System.EventHandler(this.UCServiceAndPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_bill)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_serviceUsage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_bill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_bookService;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_searchByRoom;
        private System.Windows.Forms.TextBox txt_roomId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtgv_serviceUsage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_ServiceType;
    }
}
