using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using HotelManagementSystem.DBConnection;

namespace HotelManagementSystem.DAO {
    public class LoginDAO {
        Connection db = new Connection();
        public int CheckLogin(string username, string password)
        {
            int result = -1; // Mặc định là tài khoản không tồn tại
            string connectionString = db.strCon;

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
    }
}
