using HotelManagementSystem.DAO;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FLogin : Form {

        LoginDAO db = new LoginDAO();

        public FLogin() {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e) {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        public bool emptyFields() {
            return string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if(emptyFields()) {
                MessageBox.Show("Tất cả các trường đều phải được điền đầy đủ.", "Thông báo lỗi", MessageBoxButtons.OK);
            } else {

                try {
                    int loginResult = db.CheckLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                    if(loginResult == 1) {
                        MessageBox.Show("Manager đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FManager fManager = new FManager(txtUsername.Text.Trim());
                        fManager.Show();
                        this.Hide();
                    } else if(loginResult == 0) {
                        MessageBox.Show("Receptionist đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FReceptionist fReceptionist = new FReceptionist(txtUsername.Text.Trim());
                        fReceptionist.Show();
                        this.Hide();
                    } else {
                        MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch(Exception ex) {
                    MessageBox.Show("Kết nối thất bại: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FLogin_Load(object sender, EventArgs e) {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                btnLogin_Click(sender, e);
            }
        }
    }
}
