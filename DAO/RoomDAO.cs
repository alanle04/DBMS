using HotelManagementSystem.DBConnection;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using HotelManagementSystem.Model;

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

        public static DataTable GetDepositedRooms()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_CheckInRooms";

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

        public static DataTable GetDepositedRoomsByIdNumber(string idNumber)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM dbo.fn_GetDepositedRoomsByIdNumber(@idNumber)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@idNumber", SqlDbType.VarChar).Value = idNumber;
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

        public Room GetRoomById(string roomId)
        {
            Room room = null;

            using (SqlConnection connection = DBConnection.Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM fn_SearchRoomById(@room_id)";
                    cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = roomId;

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    room = new Room()
                                    {
                                        RoomId = reader["room_id"].ToString(),
                                        RoomName = reader["room_name"].ToString(),
                                        Status = reader["status"].ToString(),
                                        RoomTypeId = reader["room_type_id"].ToString(),
                                        ManagerId = reader["manager_id"].ToString()
                                    };
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Lỗi khi tìm kiếm phòng: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return room;
        }

    public Room GetRoomByRoomName(string roomName)
        {
            Room room = null;

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SearchRoomByName";
                    cmd.Parameters.Add("@room_name", SqlDbType.NVarChar).Value = roomName;

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    room = new Room()
                                    {
                                        RoomId = reader["room_id"].ToString(),
                                        RoomName = reader["room_name"].ToString(),
                                        Status = reader["status"].ToString(),
                                        RoomTypeId = reader["room_type_id"].ToString(),
                                        ManagerId = reader["manager_id"].ToString()
                                    };
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Lỗi khi tìm kiếm phòng: " + ex.Message);
                    }
                }
            }

            return room;
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

        public int DeleteRoom(string roomId) {

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
    }

}
