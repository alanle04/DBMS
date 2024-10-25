using HotelManagementSystem.DBConnection;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    public class StaffDAO {

        public string GetStaffFullNameByUsername(string username) {
            using(SqlConnection connection = Connection.GetConnection()) {
                string query = "SELECT dbo.fn_GetStaffFullNameByUsername(@username)";

                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public string GetStaffIdByUsername(string username) {
            using(SqlConnection connection = Connection.GetConnection()) {
                string query = "SELECT dbo.fn_GetStaffIdByUsername(@username)";

                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public static DataTable GetManager()
        {
            SqlConnection conn = Connection.GetConnection();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM vw_AllManager";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            conn.Close();
            return table;
        }
    }
}
