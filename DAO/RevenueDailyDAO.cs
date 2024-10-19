using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.DBConnection;

namespace HotelManagementSystem.DAO
{
    public class RevenueDailyDAO
    {
      
        Connection db = new Connection();
        public int GetTotalRevenueByDate(int day, int month, int year)
        {
            int totalRevenue = 0;
            Connection db = new Connection(); // Kết nối cơ sở dữ liệu

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();
                // Truy vấn gọi hàm fn_CalculateTotalRevenueByDate
                string query = "SELECT dbo.fn_CalculateTotalRevenueByDate(@day, @month, @year)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho truy vấn
                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@year", year);

                    // Thực thi truy vấn và lấy kết quả
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalRevenue = Convert.ToInt32(result); // Chuyển đổi về INT
                    }
                }
            }

            return totalRevenue;
        }  
    }
}
