using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class RoomTypeDAO {
        public static void AddRoomType(string roomTypeId, string roomTypeName, int numberOfBeds, int capacity, int costPerDay, string managerId) {
            SqlConnection conn = DBConnection.Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AddRoomType";

            cmd.Parameters.Add("@room_type_id", SqlDbType.VarChar).Value = roomTypeId;
            cmd.Parameters.Add("@room_type_name", SqlDbType.NVarChar).Value = roomTypeName;
            cmd.Parameters.Add("@number_of_bed", SqlDbType.Int).Value = numberOfBeds;
            cmd.Parameters.Add("@capacity", SqlDbType.Int).Value = capacity;
            cmd.Parameters.Add("@cost_per_day", SqlDbType.Int).Value = costPerDay;
            cmd.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = managerId;

            try {
                conn.Open();
                if(cmd.ExecuteNonQuery() > 0) {
                    MessageBox.Show("Thêm loại phòng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex) {
                MessageBox.Show("Thêm mới thất bại" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }

        public static void UpdateRoomType(string roomTypeId, string roomTypeName, int numberOfBeds, int capacity, int costPerDay, string managerId) {
            SqlConnection conn = DBConnection.Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateRoomType";

            cmd.Parameters.Add("@type_id", SqlDbType.VarChar).Value = roomTypeId;
            cmd.Parameters.Add("@type_name", SqlDbType.NVarChar).Value = roomTypeName;
            cmd.Parameters.Add("@num_bed", SqlDbType.Int).Value = numberOfBeds;
            cmd.Parameters.Add("@capac", SqlDbType.Int).Value = capacity;
            cmd.Parameters.Add("@cost", SqlDbType.Int).Value = costPerDay;
            cmd.Parameters.Add("@manager", SqlDbType.VarChar).Value = managerId;

            try {
                conn.Open();
                if(cmd.ExecuteNonQuery() > 0) {
                    MessageBox.Show("Cập nhật loại phòng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex) {
                MessageBox.Show("Cập nhật thất bại" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }

        public static void DeleteRoomType(string roomTypeId) {

            SqlConnection conn = DBConnection.Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DeleteRoomType";

            cmd.Parameters.Add("@type_id", SqlDbType.VarChar).Value = roomTypeId;


            try {
                conn.Open();
                if(cmd.ExecuteNonQuery() > 0) {
                    MessageBox.Show("Xóa loại phòng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex) {
                MessageBox.Show("Xóa thất bại" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }

        public static DataTable RoomTypeList() {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM vw_RoomTypeList";
            SqlConnection conn = DBConnection.Connection.GetConnection();
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
                string query = "SELECT ID FROM vw_RoomTypeList WHERE Name = @roomTypeName";

                connection.Open();
                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@roomTypeName", roomTypeName);
                    var result = cmd.ExecuteScalar();
                    if(result != null) {
                        return result.ToString();
                    }
                }
            }

            return null;
        }

        public RoomType GetRoomTypeById(string roomTypeId)
        {
            RoomType roomType = null;

            using (SqlConnection conn = DBConnection.Connection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM room_type WHERE room_type_id = @id", conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = roomTypeId;

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                roomType = new RoomType
                                {
                                    RoomTypeId = reader["room_type_id"].ToString(),
                                    RoomTypeName = reader["room_type_name"].ToString(),
                                    NumberOfBed = Convert.ToInt32(reader["number_of_bed"]),
                                    Capacity = Convert.ToInt32(reader["capacity"]),
                                    CostPerDay = Convert.ToInt32(reader["cost_per_day"]),
                                    ManagerId = reader["manager_id"]?.ToString()
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Lỗi khi lấy thông tin loại phòng: " + ex.Message);
                    }
                }
            }

            return roomType;
        }


    }
}
