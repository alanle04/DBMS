using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class RoomDAO
    {
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

                string query = "SELECT * FROM dbo.fn_GetDepositedRoomsByIdNumber(@id_number)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@id_number", SqlDbType.VarChar).Value = idNumber;
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

                string query = "SELECT * FROM dbo.vw_AvailableRooms WHERE room_type_name = @room_type_name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@room_type_name", roomTypeName);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            return dt;
        }

       

        public Room GetRoomByRoomName(string roomName)
        {
            Room room = null;

            using (SqlConnection connection = DBConnection.Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM fn_SearchRoomByName(@room_name)";
                    cmd.Parameters.Add("@room_name", SqlDbType.VarChar).Value = roomName;

                   
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
            }

            return room;
        }


        public static void AddRoom(Room room)
        {

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_AddRoom";

                    cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = room.RoomId;
                    cmd.Parameters.Add("@room_name", SqlDbType.VarChar).Value = room.RoomName;
                    cmd.Parameters.Add("@room_type_id", SqlDbType.VarChar).Value = room.RoomTypeId;
                    cmd.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = room.ManagerId;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

           
        }

        public void UpdateRoom(Room room)
        {

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_UpdateRoomById";

                    cmd.Parameters.Add("@roomId", SqlDbType.VarChar).Value = room.RoomId;
                    cmd.Parameters.Add("@roomName", SqlDbType.VarChar).Value = room.RoomName;
                    cmd.Parameters.Add("@roomTypeId", SqlDbType.VarChar).Value = room.RoomTypeId;
                    cmd.Parameters.Add("@managerId", SqlDbType.VarChar).Value = room.ManagerId;


                    cmd.ExecuteNonQuery();

                }
                connection.Close();
            }

        }

        public void DeleteRoom(string roomId)
        {

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_DeleteRoomById";

                    cmd.Parameters.Add("@roomId", SqlDbType.VarChar).Value = roomId;


                    cmd.ExecuteNonQuery();
                }

                connection.Close();

            }
          
        }
    }

}
