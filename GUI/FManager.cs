<<<<<<< HEAD
﻿using HotelManagementSystem.DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using HotelManagementSystem.GUI;
using System;
>>>>>>> main
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FManager : Form
    {
     
        public FManager()
        {
            InitializeComponent();
            
        }
       

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FLogin fLogin = new FLogin();
                fLogin.Show();

                this.Hide();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ucDashboard.Visible = true;
            ucRoom.Visible = false;
            ucCustomer.Visible = false;
            ucService.Visible = false;
            
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            ucDashboard.Visible = false;
            ucRoom.Visible = true;
            ucCustomer.Visible = false;
            ucService.Visible = false;
            ucBill.Visible = false;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ucDashboard.Visible = false;
            ucRoom.Visible = false;
            ucCustomer.Visible = true;
            ucService.Visible = false;
            ucBill.Visible = false;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ucDashboard.Visible = false;
            ucRoom.Visible = false;
            ucCustomer.Visible = false;
            ucService.Visible = true;
            ucBill.Visible = false;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            ucDashboard.Visible = false;
            ucRoom.Visible = false;
            ucCustomer.Visible = false;
            ucService.Visible = false;
            ucBill.Visible = true;
        }

<<<<<<< HEAD
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucBill_Load(object sender, EventArgs e)
        {

        }

        private void FManager_Load(object sender, EventArgs e)
        {

=======
        private void btnRoomType_Click(object sender, EventArgs e) {
            ucDashboard.Visible = false;
            ucRoom.Visible = false;
            ucRoomType.Visible = true;
            ucCustomer.Visible = false;
            ucService.Visible = false;
            ucBill.Visible = false;
>>>>>>> main
        }
    }
}
