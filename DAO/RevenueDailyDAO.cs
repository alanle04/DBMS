using HotelManagementSystem.DBConnection;
using System;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    public class RevenueDailyDAO {

        public int GetTotalRevenueByDate(int day, int month, int year) {
            int totalRevenue = 0;

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT dbo.fn_CalculateTotalRevenueByDate(@day, @month, @year)";

                using(SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@year", year);

                    object result = command.ExecuteScalar();
                    if(result != DBNull.Value) {
                        totalRevenue = Convert.ToInt32(result);
                    }


                }
                connection.Close();
            }

            return totalRevenue;
        }
    }
}
