using HotelManagementSystem.DBConnection;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    public class RoomTypeDAO {
        public DataTable GetAllRoomTypes() {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_RoomType";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }

            return dt;
        }
    }
}
