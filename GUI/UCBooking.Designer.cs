namespace HotelManagementSystem
{
    partial class UCBooking
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchRooms = new System.Windows.Forms.Button();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.btnBook = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRoomType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListRoom = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbNationality = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.lblIdNumber = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoom)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSearchRooms);
            this.panel1.Controls.Add(this.dtpCheckOut);
            this.panel1.Controls.Add(this.btnBook);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtpCheckIn);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbRoomType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 330);
            this.panel1.TabIndex = 0;
            // 
            // btnSearchRooms
            // 
            this.btnSearchRooms.BackColor = System.Drawing.Color.Teal;
            this.btnSearchRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRooms.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchRooms.ForeColor = System.Drawing.Color.White;
            this.btnSearchRooms.Location = new System.Drawing.Point(50, 261);
            this.btnSearchRooms.Name = "btnSearchRooms";
            this.btnSearchRooms.Size = new System.Drawing.Size(143, 40);
            this.btnSearchRooms.TabIndex = 36;
            this.btnSearchRooms.Text = "TÌM PHÒNG";
            this.btnSearchRooms.UseVisualStyleBackColor = false;
            this.btnSearchRooms.Click += new System.EventHandler(this.btnSearchRooms_Click);
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOut.Location = new System.Drawing.Point(50, 214);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(315, 24);
            this.dtpCheckOut.TabIndex = 35;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.Teal;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(213, 261);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(152, 40);
            this.btnBook.TabIndex = 25;
            this.btnBook.Text = "ĐẶT PHÒNG";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(47, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 19);
            this.label10.TabIndex = 34;
            this.label10.Text = "Ngày check out:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckIn.Location = new System.Drawing.Point(50, 142);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(315, 24);
            this.dtpCheckIn.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 19);
            this.label9.TabIndex = 32;
            this.label9.Text = "Ngày check in:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Loại phòng:";
            // 
            // cbRoomType
            // 
            this.cbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRoomType.FormattingEnabled = true;
            this.cbRoomType.Items.AddRange(new object[] {
            "Standard-Single",
            "Standard-Double",
            "Superior-Single",
            "Superior-Double",
            "Deluxe-Single",
            "Deluxe-Double",
            "Suite-Single",
            "Suite-Double"});
            this.cbRoomType.Location = new System.Drawing.Point(50, 72);
            this.cbRoomType.Name = "cbRoomType";
            this.cbRoomType.Size = new System.Drawing.Size(315, 28);
            this.cbRoomType.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Thông tin đăng ký";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(635, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "A list of rooms";
            // 
            // dgvListRoom
            // 
            this.dgvListRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRoom.Location = new System.Drawing.Point(0, 40);
            this.dgvListRoom.Name = "dgvListRoom";
            this.dgvListRoom.RowHeadersWidth = 51;
            this.dgvListRoom.Size = new System.Drawing.Size(790, 341);
            this.dgvListRoom.TabIndex = 3;
            this.dgvListRoom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRoom_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cbNationality);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.lblAddress);
            this.panel2.Controls.Add(this.lblNationality);
            this.panel2.Controls.Add(this.txtIdNumber);
            this.panel2.Controls.Add(this.lblIdNumber);
            this.panel2.Controls.Add(this.cbGender);
            this.panel2.Controls.Add(this.txtPhoneNumber);
            this.panel2.Controls.Add(this.lblPhoneNumber);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtFullName);
            this.panel2.Controls.Add(this.lblFullName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(445, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 330);
            this.panel2.TabIndex = 1;
            // 
            // cbNationality
            // 
            this.cbNationality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNationality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNationality.DropDownWidth = 250;
            this.cbNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNationality.FormattingEnabled = true;
            this.cbNationality.Items.AddRange(new object[] {
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
            this.cbNationality.Location = new System.Drawing.Point(423, 162);
            this.cbNationality.Name = "cbNationality";
            this.cbNationality.Size = new System.Drawing.Size(315, 28);
            this.cbNationality.TabIndex = 24;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(423, 227);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(315, 26);
            this.txtAddress.TabIndex = 23;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(420, 206);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(63, 19);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(420, 141);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(82, 19);
            this.lblNationality.TabIndex = 21;
            this.lblNationality.Text = "Quốc tịch:";
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdNumber.Location = new System.Drawing.Point(423, 100);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(315, 26);
            this.txtIdNumber.TabIndex = 20;
            // 
            // lblIdNumber
            // 
            this.lblIdNumber.AutoSize = true;
            this.lblIdNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdNumber.Location = new System.Drawing.Point(420, 79);
            this.lblIdNumber.Name = "lblIdNumber";
            this.lblIdNumber.Size = new System.Drawing.Size(106, 19);
            this.lblIdNumber.TabIndex = 19;
            this.lblIdNumber.Text = "CMND/CCCD:";
            // 
            // cbGender
            // 
            this.cbGender.DisplayMember = "Male";
            this.cbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(47, 162);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(315, 28);
            this.cbGender.TabIndex = 18;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(47, 227);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(315, 26);
            this.txtPhoneNumber.TabIndex = 17;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(44, 206);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(108, 19);
            this.lblPhoneNumber.TabIndex = 16;
            this.lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Giới tính:";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(47, 99);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(315, 26);
            this.txtFullName.TabIndex = 14;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(44, 78);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(83, 19);
            this.lblFullName.TabIndex = 13;
            this.lblFullName.Text = "Họ và tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thông tin khách hàng";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtRoomId);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtPrice);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtCapacity);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtRoomType);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtRoomName);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(15, 358);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(416, 381);
            this.panel3.TabIndex = 2;
            // 
            // txtRoomId
            // 
            this.txtRoomId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomId.Location = new System.Drawing.Point(51, 84);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(315, 26);
            this.txtRoomId.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Mã phòng:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(50, 339);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(315, 26);
            this.txtPrice.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(47, 318);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 19);
            this.label15.TabIndex = 32;
            this.label15.Text = "Giá:";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacity.Location = new System.Drawing.Point(50, 280);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(315, 26);
            this.txtCapacity.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(47, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 19);
            this.label14.TabIndex = 30;
            this.label14.Text = "Sức chứa:";
            // 
            // txtRoomType
            // 
            this.txtRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomType.Location = new System.Drawing.Point(50, 210);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(315, 26);
            this.txtRoomType.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(47, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 19);
            this.label13.TabIndex = 28;
            this.label13.Text = "Loại phòng:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomName.Location = new System.Drawing.Point(51, 145);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(315, 26);
            this.txtRoomName.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(48, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 26;
            this.label12.Text = "Tên phòng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Thông tin phòng";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.dgvListRoom);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(445, 358);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(790, 381);
            this.panel5.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "Danh sách phòng:";
            // 
            // UCBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCBooking";
            this.Size = new System.Drawing.Size(1250, 755);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoom)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListRoom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cbNationality;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRoomType;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearchRooms;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.Label label5;
    }
}
