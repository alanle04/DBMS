using HotelManagementSystem.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DAO
{
    public class RevenueYearly
    {
        Connection db = new Connection();
       public List<RevenueData> GetRevenueData(int year)
        {
            var revenueData = new List<RevenueData>();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                // Sử dụng truy vấn SQL để gọi hàm fn_TotalRevenueByYear
                string query = "SELECT Month, TotalRevenue FROM fn_TotalRevenueByYear(@year)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@year", year);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                            {
                                revenueData.Add(new RevenueData
                                {
                                    Month = reader.GetInt32(0), // Tháng
                                    TotalRevenue = reader.GetInt32(1) // Tổng doanh thu
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
            public decimal TotalRevenue { get; set; } // Tổng doanh thu
        }
    }
}
