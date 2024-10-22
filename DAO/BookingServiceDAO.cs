using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using HotelManagementSystem.Model;

namespace HotelManagementSystem.DAO
{
    internal class BookingServiceDAO
    {
        public static void BookingService(string serviceUsageId, DateTime usageTime, int quantity, string bookingRecordId, string staffId, string serviceId)
        {
            SqlConnection conn = DBConnection.Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_AddServiceUsageRecord";

            cmd.Parameters.AddWithValue("@service_usage_id", SqlDbType.VarChar).Value = serviceUsageId;
            cmd.Parameters.AddWithValue("@usage_time", SqlDbType.DateTime).Value = usageTime;
            cmd.Parameters.AddWithValue("@quantity", SqlDbType.Int).Value = quantity;
            cmd.Parameters.AddWithValue("@booking_record_id", SqlDbType.Int).Value = bookingRecordId;
            cmd.Parameters.AddWithValue("@staff_id", SqlDbType.VarChar).Value = staffId;
            cmd.Parameters.AddWithValue("@service_id", SqlDbType.VarChar).Value = serviceId;

            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đặt dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đặt dịch vụ thất bại" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }


        }
        public static DataTable GetBillInfoByRoomId(string roomId)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = DBConnection.Connection.GetConnection())
            {
                string query = "SELECT * FROM fn_getBillInfoByRoomId(@roomId)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(result);
                    }

                    conn.Close();
                }
            }

            return result;
        }
        public static DataTable GetServiceUsageInfoByRoomId(string roomId)
        {
            DataTable result = new DataTable();

            using (SqlConnection conn = DBConnection.Connection.GetConnection())
            {
                string query = "SELECT * FROM fn_getServiceUsageInfoByRoomId(@roomId)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(result);
                    }

                    conn.Close();
                }
            }

            return result;
        }

        public static string GetBookingRecordIdByRoomID(string roomId)
        {
            string bookingrecordid = "";
            string query = "SELECT dbo.fn_getBookingRecordIdByRoomIdCustomerId(@roomId)";
            SqlConnection conn = DBConnection.Connection.GetConnection();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@roomId", roomId);

                conn.Open();

                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    bookingrecordid = result.ToString();
                }

                conn.Close();
            }
            return bookingrecordid;
        }
    }
}
