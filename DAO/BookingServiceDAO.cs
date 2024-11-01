using HotelManagementSystem.DBConnection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    internal class BookingServiceDAO {
        public static void BookingService(string serviceUsageId, DateTime usageTime, int quantity, string bookingRecordId, string staffId, string serviceId) {
            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AddServiceUsageRecord";

            cmd.Parameters.AddWithValue("@service_usage_id", SqlDbType.VarChar).Value = serviceUsageId;
            cmd.Parameters.AddWithValue("@usage_time", SqlDbType.DateTime).Value = usageTime;
            cmd.Parameters.AddWithValue("@quantity", SqlDbType.Int).Value = quantity;
            cmd.Parameters.AddWithValue("@booking_record_id", SqlDbType.Int).Value = bookingRecordId;
            cmd.Parameters.AddWithValue("@staff_id", SqlDbType.VarChar).Value = staffId;
            cmd.Parameters.AddWithValue("@service_id", SqlDbType.VarChar).Value = serviceId;

            try {
                conn.Open();
                if(cmd.ExecuteNonQuery() > 0) {
                    MessageBox.Show("Đặt dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex) {
                MessageBox.Show("Đặt dịch vụ thất bại" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }


        }
        public static DataTable GetBillInfoByRoomId(string roomId) {
            DataTable result = new DataTable();

            using(SqlConnection conn = Connection.GetConnection()) {
                string query = "SELECT * FROM fn_GetBillInfoByRoomId(@room_id)";

                using(SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@room_id", roomId);

                    conn.Open();

                    using(SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        da.Fill(result);
                    }

                    conn.Close();
                }
            }

            return result;
        }

        public static DataTable GetServiceUsageInfoByRoomId(string roomId) {
            DataTable result = new DataTable();

            using(SqlConnection conn = Connection.GetConnection()) {
                string query = "SELECT * FROM fn_GetServiceUsageInfoByRoomId(@roomId)";

                using(SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    conn.Open();

                    using(SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        da.Fill(result);
                    }

                    conn.Close();
                }
            }

            return result;
        }

        public static string GetBookingRecordIdByRoomID(string roomId) {
            string bookingrecordid = "";
            string query = "SELECT dbo.fn_GetBookingRecordIdByRoomIdCustomerId(@roomId)";
            SqlConnection conn = Connection.GetConnection();
            using(SqlCommand cmd = new SqlCommand(query, conn)) {
                cmd.Parameters.AddWithValue("@roomId", roomId);

                conn.Open();

                var result = cmd.ExecuteScalar();

                if(result != DBNull.Value) {
                    bookingrecordid = result.ToString();
                }

                conn.Close();
            }
            return bookingrecordid;
        }
    }
}
