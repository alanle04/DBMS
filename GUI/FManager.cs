using HotelManagementSystem.DAO;
using HotelManagementSystem.GUI;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FManager : Form {

        private string username;
        

        public FManager() {
            InitializeComponent();
            UCDashboard uCDashboard = new UCDashboard();
            uCDashboard.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCDashboard);
        }

        public FManager(string username) {
            InitializeComponent();
            this.username = username;
            lblUsername.Text = username;
            
            UCDashboard uCDashboard = new UCDashboard();
            uCDashboard.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCDashboard);
        }


        private void lblClose_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if(result == DialogResult.Yes) {
                FLogin fLogin = new FLogin();
                fLogin.Show();

                this.Hide();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e) {
            UCDashboard ucDashboard = new UCDashboard();
            ucDashboard.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucDashboard);
        }

        private void btnRoom_Click(object sender, EventArgs e) {
            UCRoom ucRoom = new UCRoom(username);
            ucRoom.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucRoom);
        }

        private void btnRoomType_Click(object sender, EventArgs e) {
            UCRoomType uCRoomType = new UCRoomType(username);
            uCRoomType.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCRoomType);
        }

        private void btnCustomer_Click(object sender, EventArgs e) {
            UCCustomer uCCustomer = new UCCustomer();
            uCCustomer.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCCustomer);
        }

        private void btnService_Click(object sender, EventArgs e) {
            UCService ucService = new UCService(username);
            ucService.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucService);
        }

        private void btnBill_Click(object sender, EventArgs e) {
            UCBill ucBill = new UCBill();
            ucBill.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucBill);
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void ucBill_Load(object sender, EventArgs e) {

        }

        private void FManager_Load(object sender, EventArgs e) {

        }
    }
}
