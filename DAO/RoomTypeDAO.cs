using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class RoomTypeDAO {
        public static void AddRoomType(string roomTypeId, string roomTypeName, int numberOfBeds, int capacity, int costPerDay, string managerId) {
            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_AddRoomType";

                    cmd.Parameters.Add("@room_type_id", SqlDbType.VarChar).Value = roomTypeId;
                    cmd.Parameters.Add("@room_type_name", SqlDbType.NVarChar).Value = roomTypeName;
                    cmd.Parameters.Add("@number_of_bed", SqlDbType.Int).Value = numberOfBeds;
                    cmd.Parameters.Add("@capacity", SqlDbType.Int).Value = capacity;
                    cmd.Parameters.Add("@cost_per_day", SqlDbType.Int).Value = costPerDay;
                    cmd.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = managerId;

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
              
        }

        public static void UpdateRoomType(string roomTypeId, string roomTypeName, int numberOfBeds, int capacity, int costPerDay, string managerId) {
            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_UpdateRoomType";

                    cmd.Parameters.Add("@type_id", SqlDbType.VarChar).Value = roomTypeId;
                    cmd.Parameters.Add("@type_name", SqlDbType.NVarChar).Value = roomTypeName;
                    cmd.Parameters.Add("@num_bed", SqlDbType.Int).Value = numberOfBeds;
                    cmd.Parameters.Add("@capac", SqlDbType.Int).Value = capacity;
                    cmd.Parameters.Add("@cost", SqlDbType.Int).Value = costPerDay;
                    cmd.Parameters.Add("@manager", SqlDbType.VarChar).Value = managerId;

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public static void DeleteRoomType(string roomTypeId) {

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_DeleteRoomTypeById";

                    cmd.Parameters.Add("@type_id", SqlDbType.VarChar).Value = roomTypeId;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
                
        }

        public static DataTable RoomTypeList() {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM vw_RoomTypeList";
            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAllRoomTypeName() {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                string query = "SELECT Name FROM vw_RoomTypeList";

                connection.Open();
                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public string GetRoomTypeIdByRoomTypeName(string roomTypeName) {
            using(SqlConnection connection = Connection.GetConnection()) {
                string query = "SELECT ID FROM vw_RoomTypeList WHERE Name = @room_type_name";

                connection.Open();
                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@room_type_name", roomTypeName);
                    var result = cmd.ExecuteScalar();
                    if(result != null) {
                        return result.ToString();
                    }
                }
            }

            return null;
        }

        public RoomType GetRoomTypeById(string roomTypeId) {
            RoomType roomType = null;

            using(SqlConnection conn = Connection.GetConnection()) {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM room_type WHERE room_type_id = @id", conn)) {
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = roomTypeId;

                    try {
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader()) {
                            if(reader.Read()) {
                                roomType = new RoomType {
                                    RoomTypeId = reader["room_type_id"].ToString(),
                                    RoomTypeName = reader["room_type_name"].ToString(),
                                    NumberOfBed = Convert.ToInt32(reader["number_of_bed"]),
                                    Capacity = Convert.ToInt32(reader["capacity"]),
                                    CostPerDay = Convert.ToInt32(reader["cost_per_day"]),
                                    ManagerId = reader["manager_id"]?.ToString()
                                };
                            }
                        }
                    } catch(SqlException ex) {
                        throw new Exception("Lỗi khi lấy thông tin loại phòng: " + ex.Message);
                    }
                }
            }

            return roomType;
        }


    }
}
