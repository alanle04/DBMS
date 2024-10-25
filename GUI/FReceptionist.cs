using HotelManagementSystem.GUI;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FReceptionist : Form {

        private string username;
        public FReceptionist() {
            InitializeComponent();
            UCBooking uCBooking = new UCBooking();
            uCBooking.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCBooking);
        }

        public FReceptionist(string username) {
            InitializeComponent();
            this.username = username;
            lblUsername.Text = username;
            UCBooking uCBooking = new UCBooking(username);
            uCBooking.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCBooking);
        }

        private void lblClose_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) {
                FLogin fLogin = new FLogin();
                fLogin.Show();

                this.Hide();
            }
        }

        private void btnBooking_Click(object sender, EventArgs e) {
            UCBooking uCBooking = new UCBooking(username);
            uCBooking.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCBooking);
        }

        private void btnServiceAndPayment_Click(object sender, EventArgs e) {
            UCServiceAndPayment uCServiceAndPayment = new UCServiceAndPayment(username);
            uCServiceAndPayment.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCServiceAndPayment);
        }

        private void btnCheckIn_Click(object sender, EventArgs e) {
            UCCheckIn uCCheckIn = new UCCheckIn();
            uCCheckIn.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCCheckIn);
        }

        private void btnCheckOut_Click(object sender, EventArgs e) {
            UCCheckOut uCCheckOut = new UCCheckOut();
            uCCheckOut.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uCCheckOut);
        }
    }
}
