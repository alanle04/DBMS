using HotelManagementSystem.DBConnection;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class LoginDAO {

        public int CheckLogin(string username, string password) {
            int result = -1;

            try {
                using(SqlConnection connection = Connection.GetConnection()) {
                    connection.Open();

                    string query = "SELECT dbo.func_CheckLogin(@username, @password)";

                    using(SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        object resultObj = command.ExecuteScalar();

                        if(resultObj != null) {
                            result = Convert.ToInt32(resultObj);
                        } else {
                            MessageBox.Show("Không có kết quả trả về từ cơ sở dữ liệu.");
                        }
                    }

                    Connection.CloseConnection(); 
                }
            } catch(SqlException sqlEx) {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            } catch(Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return result;
        }
    }
}
