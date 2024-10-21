using System;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FReceptionist : Form {

        private string username;
        public FReceptionist() {
            InitializeComponent();
            UCBooking uCBooking = new UCBooking();
            uCBooking.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uCBooking);
        }

        public FReceptionist(string username) {
            InitializeComponent();
            this.username = username;
            lblUsername.Text = username;
            UCBooking uCBooking = new UCBooking(username);
            uCBooking.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uCBooking);
        }

        private void lblClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            MessageBox.Show(username);

            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) {
                FLogin fLogin = new FLogin();
                fLogin.Show();

                this.Hide();
            }
        }

        private void btnBooking_Click(object sender, EventArgs e) {
<<<<<<< HEAD
            UCBooking uCBooking = new UCBooking(username);
            uCBooking.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uCBooking);
        }

        private void btnServiceAndPayment_Click(object sender, EventArgs e) {
            UCBooking uCBooking = new UCBooking();
            uCBooking.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uCBooking);
        }

        private void btnCheckIn_Click(object sender, EventArgs e) {
            UCCheckIn uCCheckIn = new UCCheckIn();
            uCCheckIn.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uCCheckIn);
=======
            UCBooking ucbooking = new UCBooking();
            ucbooking.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucbooking);
        }

        private void btnServiceAndPayment_Click(object sender, EventArgs e) {
            UCServiceAndPayment ucserPay = new UCServiceAndPayment(username);
            ucserPay.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucserPay);
        }

        private void btnCheckIn_Click(object sender, EventArgs e) {
            UCCheckIn uccheckIN = new UCCheckIn();
            uccheckIN.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uccheckIN);
>>>>>>> main
        }
    }
}
