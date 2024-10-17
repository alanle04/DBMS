using HotelManagementSystem.Properties;
using System.Data.SqlClient;

namespace HotelManagementSystem.DBConnection {
    public class Connection {
        public static SqlConnection GetConnection() {

            return new SqlConnection(Settings.Default.connectionString);
        }
    }
}
