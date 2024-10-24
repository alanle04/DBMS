using HotelManagementSystem.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO
{
    public class RevenueMonthlyDAO
    {
        Connection db = new Connection();
        public List<RevenueData> GetRevenueDataMonth(int month, int year)
        {
            var revenueData = new List<RevenueData>();

            // Kết nối đến cơ sở dữ liệu

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                // Sử dụng truy vấn SQL để gọi hàm fn_GetDailyRevenue
                string query = "SELECT day, total FROM dbo.fn_GetMonthlyRevenue(@month, @year)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho truy vấn
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@year", year);

                    using (var reader = command.ExecuteReader())
                    {
                      
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) && !reader.IsDBNull(1)) // Kiểm tra giá trị không null
                            {
                                revenueData.Add(new RevenueData
                                {
                                    Day = reader.GetInt32(0), // Ngày
                                                              // Thay đổi phương thức ép kiểu dựa trên kiểu dữ liệu của total
                                    TotalRevenue = reader.GetInt32(1)
                                });

                            }
                        }

                    }
                }
                connection.Close();

            }

            return revenueData;
        }
        public class RevenueData
        {
            public int Day { get; set; } // Ngày
            public int TotalRevenue { get; set; } // Doanh thu
        }
    }
}
