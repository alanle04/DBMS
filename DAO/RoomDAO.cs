using HotelManagementSystem.DBConnection;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagementSystem.DAO {
    public class RoomDAO {
        public static DataTable GetAllRooms()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_RoomList";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            return dt;

        }
        public static DataTable FindRoomsByRoomType(string roomTypeName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_AvailableRooms WHERE room_type_name = @RoomTypeName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomTypeName", roomTypeName);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            return dt;
        }

    }
}
