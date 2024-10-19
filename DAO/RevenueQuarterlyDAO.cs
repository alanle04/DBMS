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
    public class RevenueQuarterlyDAO
    {
        Connection db = new Connection();
        public List<RevenueData> GetRevenueData(int quarter, int year)
        {
            var revenueData = new List<RevenueData>();
            string connectionString = db.strCon;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sử dụng truy vấn SQL để gọi hàm fn_TotalRevenueByQuarter
                string query = "SELECT month, total_revenue FROM fn_TotalRevenueByQuarter(@quarter, @year)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quarter", quarter);
                    command.Parameters.AddWithValue("@year", year);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Function không trả về kết quả.");
                        }
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) && !reader.IsDBNull(1)) // Kiểm tra giá trị không null
                            {
                                revenueData.Add(new RevenueData
                                {
                                    Month = reader.GetInt32(0), // Tháng
                                    TotalRevenue = reader.GetInt32(1) // Doanh thu
                                });
                            }
                        }
                    }
                }
            }

            return revenueData;
        }

        public class RevenueData
        {
            public int Month { get; set; } // Tháng
            public int TotalRevenue { get; set; } // Doanh thu
        }
    }
}
