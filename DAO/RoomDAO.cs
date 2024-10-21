using HotelManagementSystem.DBConnection;
<<<<<<< HEAD
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

=======
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class RoomDAO {
        public DataTable GetAllRooms() {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                string query = "SELECT * FROM vw_Room";

                connection.Open();
                using(SqlCommand cmd = new SqlCommand(query, connection)) {

                    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        adapter.Fill(dt);
                    }

                }

            }

            return dt;
        }
        public int AddRoom(Room room) {

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_AddRoom";

                    cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = room.RoomId;
                    cmd.Parameters.Add("@room_name", SqlDbType.VarChar).Value = room.RoomName;
                    cmd.Parameters.Add("@room_type_id", SqlDbType.VarChar).Value = room.RoomTypeId;
                    cmd.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = room.ManagerId;

                    try {
                        if(cmd.ExecuteNonQuery() > 0) {
                            return 1;
                        }
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            return 0;
        }

        public int UpdateRoom(Room room) {

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_UpdateRoomById";

                    cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = room.RoomId;
                    cmd.Parameters.Add("@room_name", SqlDbType.VarChar).Value = room.RoomName;
                    cmd.Parameters.Add("@room_type_id", SqlDbType.VarChar).Value = room.RoomTypeId;
                    cmd.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = room.ManagerId;

                    try {
                        if(cmd.ExecuteNonQuery() > 0) {
                            return 1;
                        }
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            return 0;
        }

        public int DeleteRoom(String roomId) {

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_DeleteRoomById";

                    cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = roomId;

                    try {
                        if(cmd.ExecuteNonQuery() > 0) {
                            return 1;
                        }
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            return 0;
        }
>>>>>>> main
    }

}
