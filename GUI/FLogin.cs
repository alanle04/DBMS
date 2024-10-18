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

        public FLogin()
        {
            InitializeComponent();
        }

        public int CheckLogin(string username, string password)
        {
            int result = -1; // Mặc định là tài khoản không tồn tại
            string connectionString = @"Data Source=DESKTOP-EBUN5JD;Initial Catalog=hotel_management;Persist Security Info=True;User ID=sa;Password=1234567890";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Gọi hàm trong câu lệnh SQL
                    string query = "SELECT dbo.CheckLogin(@username, @password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho hàm
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        // Thực hiện lệnh và lấy kết quả
                        object resultObj = command.ExecuteScalar();

                        // Kiểm tra xem kết quả có null không
                        if (resultObj != null)
                        {
                            result = Convert.ToInt32(resultObj); // Chuyển đổi kết quả sang int
                        }
                        else
                        {
                            MessageBox.Show("Không có kết quả trả về từ cơ sở dữ liệu."); // Thông báo nếu không có kết quả
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Bắt lỗi và hiển thị thông báo
            }

            return result; // Trả về kết quả
       
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
                db.openConnection(); 
                try
                {
                    int loginResult = CheckLogin(txtUsername.Text, txtPassword.Text); 

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
                    db.closeConnection();
                }
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
