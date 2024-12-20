﻿using HotelManagementSystem.GUI;

namespace HotelManagementSystem
{
    partial class UCDashboard
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnYear = new Guna.UI2.WinForms.Guna2Button();
            this.txtYear = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRevenueQuarterly = new Guna.UI2.WinForms.Guna2Button();
            this.txtQuarter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMonthly = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnShowRevenue = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDaily = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRevenueDaily = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgv_mon = new System.Windows.Forms.DataGridView();
            this.dtgv_pt = new System.Windows.Forms.DataGridView();
            this.dtgv_roomtype = new System.Windows.Forms.DataGridView();
            this.dtgv_dv = new System.Windows.Forms.DataGridView();
            this.btn_ptdt = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_mon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_pt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_roomtype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_dv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(20, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1627, 273);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Teal;
            this.panel6.Controls.Add(this.btnYear);
            this.panel6.Controls.Add(this.txtYear);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Location = new System.Drawing.Point(1223, 37);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(380, 197);
            this.panel6.TabIndex = 1;
            // 
            // btnYear
            // 
            this.btnYear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnYear.ForeColor = System.Drawing.Color.White;
            this.btnYear.Location = new System.Drawing.Point(175, 119);
            this.btnYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(123, 46);
            this.btnYear.TabIndex = 7;
            this.btnYear.Text = "Revenue";
            this.btnYear.Click += new System.EventHandler(this.btnYear_Click);
            // 
            // txtYear
            // 
            this.txtYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYear.DefaultText = "";
            this.txtYear.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtYear.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtYear.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtYear.Location = new System.Drawing.Point(175, 64);
            this.txtYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.PlaceholderText = "";
            this.txtYear.SelectedText = "";
            this.txtYear.Size = new System.Drawing.Size(123, 48);
            this.txtYear.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(171, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Yearly Income";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HotelManagementSystem.Properties.Resources.year_icon;
            this.pictureBox4.Location = new System.Drawing.Point(29, 37);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(133, 123);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Teal;
            this.panel5.Controls.Add(this.btnRevenueQuarterly);
            this.panel5.Controls.Add(this.txtQuarter);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Location = new System.Drawing.Point(823, 37);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 197);
            this.panel5.TabIndex = 1;
            // 
            // btnRevenueQuarterly
            // 
            this.btnRevenueQuarterly.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRevenueQuarterly.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRevenueQuarterly.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRevenueQuarterly.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRevenueQuarterly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRevenueQuarterly.ForeColor = System.Drawing.Color.White;
            this.btnRevenueQuarterly.Location = new System.Drawing.Point(175, 119);
            this.btnRevenueQuarterly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevenueQuarterly.Name = "btnRevenueQuarterly";
            this.btnRevenueQuarterly.Size = new System.Drawing.Size(123, 46);
            this.btnRevenueQuarterly.TabIndex = 6;
            this.btnRevenueQuarterly.Text = "Revenue";
            this.btnRevenueQuarterly.Click += new System.EventHandler(this.btnRevenueQuarterly_Click);
            // 
            // txtQuarter
            // 
            this.txtQuarter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuarter.DefaultText = "";
            this.txtQuarter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuarter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuarter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuarter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuarter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuarter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuarter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuarter.Location = new System.Drawing.Point(175, 64);
            this.txtQuarter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarter.Name = "txtQuarter";
            this.txtQuarter.PasswordChar = '\0';
            this.txtQuarter.PlaceholderText = "";
            this.txtQuarter.SelectedText = "";
            this.txtQuarter.Size = new System.Drawing.Size(123, 48);
            this.txtQuarter.TabIndex = 3;
            this.txtQuarter.TextChanged += new System.EventHandler(this.guna2TextBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(171, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quarterly Income";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HotelManagementSystem.Properties.Resources.quarters_icon;
            this.pictureBox3.Location = new System.Drawing.Point(29, 37);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(133, 123);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.Controls.Add(this.txtMonthly);
            this.panel4.Controls.Add(this.btnShowRevenue);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Location = new System.Drawing.Point(423, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 197);
            this.panel4.TabIndex = 1;
            // 
            // txtMonthly
            // 
            this.txtMonthly.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonthly.DefaultText = "";
            this.txtMonthly.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMonthly.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMonthly.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMonthly.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMonthly.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMonthly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMonthly.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMonthly.Location = new System.Drawing.Point(180, 64);
            this.txtMonthly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonthly.Name = "txtMonthly";
            this.txtMonthly.PasswordChar = '\0';
            this.txtMonthly.PlaceholderText = "";
            this.txtMonthly.SelectedText = "";
            this.txtMonthly.Size = new System.Drawing.Size(123, 48);
            this.txtMonthly.TabIndex = 7;
            this.txtMonthly.TextChanged += new System.EventHandler(this.txtMonthly_TextChanged);
            // 
            // btnShowRevenue
            // 
            this.btnShowRevenue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowRevenue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowRevenue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowRevenue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowRevenue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowRevenue.ForeColor = System.Drawing.Color.White;
            this.btnShowRevenue.Location = new System.Drawing.Point(180, 119);
            this.btnShowRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowRevenue.Name = "btnShowRevenue";
            this.btnShowRevenue.Size = new System.Drawing.Size(123, 46);
            this.btnShowRevenue.TabIndex = 4;
            this.btnShowRevenue.Text = "Revenue";
            this.btnShowRevenue.Click += new System.EventHandler(this.btnShowRevenue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(176, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monthly Income";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelManagementSystem.Properties.Resources.month_icon;
            this.pictureBox2.Location = new System.Drawing.Point(35, 37);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(133, 123);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.txtDaily);
            this.panel3.Controls.Add(this.btnRevenueDaily);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(23, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 197);
            this.panel3.TabIndex = 0;
            // 
            // txtDaily
            // 
            this.txtDaily.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDaily.DefaultText = "";
            this.txtDaily.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDaily.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDaily.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDaily.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDaily.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDaily.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDaily.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDaily.Location = new System.Drawing.Point(179, 64);
            this.txtDaily.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDaily.Name = "txtDaily";
            this.txtDaily.PasswordChar = '\0';
            this.txtDaily.PlaceholderText = "";
            this.txtDaily.SelectedText = "";
            this.txtDaily.Size = new System.Drawing.Size(123, 48);
            this.txtDaily.TabIndex = 8;
            this.txtDaily.TextChanged += new System.EventHandler(this.txtDaily_TextChanged);
            // 
            // btnRevenueDaily
            // 
            this.btnRevenueDaily.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRevenueDaily.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRevenueDaily.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRevenueDaily.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRevenueDaily.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRevenueDaily.ForeColor = System.Drawing.Color.White;
            this.btnRevenueDaily.Location = new System.Drawing.Point(179, 119);
            this.btnRevenueDaily.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevenueDaily.Name = "btnRevenueDaily";
            this.btnRevenueDaily.Size = new System.Drawing.Size(123, 46);
            this.btnRevenueDaily.TabIndex = 6;
            this.btnRevenueDaily.Text = "Revenue";
            this.btnRevenueDaily.Click += new System.EventHandler(this.btnRevenueDaily_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(175, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Daily Income";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagementSystem.Properties.Resources.day_icon;
            this.pictureBox1.Location = new System.Drawing.Point(33, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_ptdt);
            this.panel2.Controls.Add(this.dtgv_mon);
            this.panel2.Controls.Add(this.dtgv_pt);
            this.panel2.Controls.Add(this.dtgv_roomtype);
            this.panel2.Controls.Add(this.dtgv_dv);
            this.panel2.Location = new System.Drawing.Point(20, 310);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1627, 603);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dtgv_mon
            // 
            this.dtgv_mon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_mon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_mon.Location = new System.Drawing.Point(1135, 20);
            this.dtgv_mon.Name = "dtgv_mon";
            this.dtgv_mon.RowHeadersWidth = 51;
            this.dtgv_mon.RowTemplate.Height = 24;
            this.dtgv_mon.Size = new System.Drawing.Size(408, 569);
            this.dtgv_mon.TabIndex = 19;
            // 
            // dtgv_pt
            // 
            this.dtgv_pt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_pt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_pt.Location = new System.Drawing.Point(777, 20);
            this.dtgv_pt.Name = "dtgv_pt";
            this.dtgv_pt.RowHeadersWidth = 51;
            this.dtgv_pt.RowTemplate.Height = 24;
            this.dtgv_pt.Size = new System.Drawing.Size(342, 569);
            this.dtgv_pt.TabIndex = 18;
            // 
            // dtgv_roomtype
            // 
            this.dtgv_roomtype.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_roomtype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_roomtype.Location = new System.Drawing.Point(413, 20);
            this.dtgv_roomtype.Name = "dtgv_roomtype";
            this.dtgv_roomtype.RowHeadersWidth = 51;
            this.dtgv_roomtype.RowTemplate.Height = 24;
            this.dtgv_roomtype.Size = new System.Drawing.Size(349, 569);
            this.dtgv_roomtype.TabIndex = 17;
            // 
            // dtgv_dv
            // 
            this.dtgv_dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_dv.Location = new System.Drawing.Point(46, 102);
            this.dtgv_dv.Name = "dtgv_dv";
            this.dtgv_dv.RowHeadersWidth = 51;
            this.dtgv_dv.RowTemplate.Height = 24;
            this.dtgv_dv.Size = new System.Drawing.Size(352, 487);
            this.dtgv_dv.TabIndex = 16;
            // 
            // btn_ptdt
            // 
            this.btn_ptdt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ptdt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ptdt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ptdt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ptdt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ptdt.ForeColor = System.Drawing.Color.White;
            this.btn_ptdt.Location = new System.Drawing.Point(46, 20);
            this.btn_ptdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ptdt.Name = "btn_ptdt";
            this.btn_ptdt.Size = new System.Drawing.Size(352, 77);
            this.btn_ptdt.TabIndex = 8;
            this.btn_ptdt.Text = "Phân tích doanh thu";
            this.btn_ptdt.Click += new System.EventHandler(this.btn_ptdt_Click);
            // 
            // UCDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCDashboard";
            this.Size = new System.Drawing.Size(1667, 929);
            this.Load += new System.EventHandler(this.UCDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_mon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_pt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_roomtype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_dv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtYear;
        private Guna.UI2.WinForms.Guna2TextBox txtQuarter;
        private Guna.UI2.WinForms.Guna2Button btnShowRevenue;
        private Guna.UI2.WinForms.Guna2Button btnRevenueDaily;
        private Guna.UI2.WinForms.Guna2Button btnRevenueQuarterly;
        private GUI.UCRevenueMonthly ucRevenueMonthly1;
        private UCRevenueDaily ucRevenueDaily1;
        private Guna.UI2.WinForms.Guna2TextBox txtMonthly;
        private Guna.UI2.WinForms.Guna2TextBox txtDaily;
        private Guna.UI2.WinForms.Guna2Button btnYear;
        private System.Windows.Forms.DataGridView dtgv_dv;
        private System.Windows.Forms.DataGridView dtgv_mon;
        private System.Windows.Forms.DataGridView dtgv_pt;
        private System.Windows.Forms.DataGridView dtgv_roomtype;
        private Guna.UI2.WinForms.Guna2Button btn_ptdt;
    }
}
