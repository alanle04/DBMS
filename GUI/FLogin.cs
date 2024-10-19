using HotelManagementSystem.DAO;
using HotelManagementSystem.DBConnection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class FLogin : Form
    {
        Connection db = new Connection();
        LoginDAO loginDAO = new LoginDAO();

        public FLogin()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            return string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Tất cả các trường đều phải được điền đầy đủ.", "Thông báo lỗi", MessageBoxButtons.OK);
            }
            else
            {
                db.openConnection(); // Mở kết nối từ class Connection
                try
                {
                    int loginResult = loginDAO.CheckLogin(txtUsername.Text, txtPassword.Text); // Chỉ gọi một lần

                    if (loginResult == 1)
                    {
                        MessageBox.Show("Manager đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FManager fManager = new FManager();
                        fManager.Show();
                        this.Hide();
                    }
                    else if (loginResult == 0)
                    {
                        MessageBox.Show("Receptionist đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FReceptionist fReceptionist = new FReceptionist();
                        fReceptionist.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối thất bại: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection(); // Đóng kết nối
                }
            }
        }
    }
}
