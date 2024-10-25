using HotelManagementSystem.DBConnection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    public class RevenueMonthlyDAO {
        public List<RevenueData> GetRevenueDataMonth(int month, int year) {
            var revenueData = new List<RevenueData>();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT day, total FROM dbo.fn_GetDailyRevenue(@month, @year)";


                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@year", year);

                    using(var reader = command.ExecuteReader()) {

                        while(reader.Read()) {
                            if(!reader.IsDBNull(0) && !reader.IsDBNull(1)) 
                            {
                                revenueData.Add(new RevenueData {
                                    Day = reader.GetInt32(0), 
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
        public class RevenueData {
            public int Day { get; set; } 
            public int TotalRevenue { get; set; } 
        }
    }
}
