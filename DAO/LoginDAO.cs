using HotelManagementSystem.DBConnection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class LoginDAO {

        public int CheckLogin(string username, string password)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = Connection.GetConnection())
                {
                    connection.Open();

                    // Thay đổi tên truy vấn để gọi thủ tục
                    string query = "sp_CheckLogin"; // Tên của thủ tục lưu trữ

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Đặt loại lệnh là thủ tục lưu trữ

                        // Thêm tham số
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        // Thêm tham số đầu ra
                        SqlParameter outputParam = new SqlParameter("@result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output // Đặt tham số là đầu ra
                        };
                        command.Parameters.Add(outputParam);

                        // Thực thi thủ tục
                        command.ExecuteNonQuery(); // Sử dụng ExecuteNonQuery cho thủ tục

                        // Lấy giá trị từ tham số đầu ra
                        result = (int)outputParam.Value;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

    }
}
