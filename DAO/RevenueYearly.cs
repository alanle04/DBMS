using HotelManagementSystem.DBConnection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    public class RevenueYearly {
        public List<RevenueData> GetRevenueData(int year) {
            var revenueData = new List<RevenueData>();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT Month, TotalRevenue FROM fn_TotalRevenueByYear(@year)";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@year", year);

                    using(var reader = command.ExecuteReader()) {
                        while(reader.Read()) {
                            if(!reader.IsDBNull(0) && !reader.IsDBNull(1)) {
                                revenueData.Add(new RevenueData {
                                    Month = reader.GetInt32(0),
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
            public int Month { get; set; }
            public int TotalRevenue { get; set; }
        }
    }
}
