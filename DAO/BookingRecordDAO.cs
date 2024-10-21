using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.DBConnection;

namespace HotelManagementSystem.DAO
{
    public class BookingRecordDAO
    {
        public static void AddBookingRecord(string bookingRecordId, DateTime bookingTime, string status, DateTime expectedCheckInTime, DateTime expectedCheckOutTime, DateTime? actualCheckInTime, DateTime? actualCheckOutTime, string receptionistId, string customerId, string roomId)
        {
            SqlConnection conn = DBConnection.Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AddBookingRecord";

            cmd.Parameters.Add("@booking_record_id", SqlDbType.VarChar).Value = bookingRecordId;
            cmd.Parameters.Add("@booking_time", SqlDbType.DateTime).Value = bookingTime;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.Add("@expected_check_in_time", SqlDbType.DateTime).Value = expectedCheckInTime;
            cmd.Parameters.Add("@expected_check_out_time", SqlDbType.DateTime).Value = expectedCheckOutTime;
            cmd.Parameters.Add("@actual_check_in_time", SqlDbType.DateTime).Value = (object)actualCheckInTime ?? DBNull.Value;
            cmd.Parameters.Add("@actual_check_out_time", SqlDbType.DateTime).Value = (object)actualCheckOutTime ?? DBNull.Value;
            cmd.Parameters.Add("@staff_id", SqlDbType.VarChar).Value = receptionistId;
            cmd.Parameters.Add("@customer_id", SqlDbType.VarChar).Value = customerId;
            cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = roomId;

            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đặt phòng thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
