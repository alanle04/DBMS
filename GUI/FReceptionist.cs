using System;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FReceptionist : Form {
        private string username;
        public FReceptionist() {
            InitializeComponent();
        }

        public FReceptionist(string username) {
            InitializeComponent();
            this.username = username;
            lblUsername.Text = username;
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
            ucBooking.Visible = true;
            ucCheckIn.Visible = false;
            ucServiceAndPayment.Visible = false;
        }

        private void btnServiceAndPayment_Click(object sender, EventArgs e) {
            ucBooking.Visible = false;
            ucCheckIn.Visible = false;
            ucServiceAndPayment.Visible = true;
        }

        private void btnCheckIn_Click(object sender, EventArgs e) {
            ucBooking.Visible = false;
            ucCheckIn.Visible = true;
            ucServiceAndPayment.Visible = false;
        }
    }
}
