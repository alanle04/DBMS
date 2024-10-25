using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class BookingRecordDAO {
        public BookingRecord GetBookingRecordByRoomIdToCheckOut(string roomId) {
            BookingRecord bookingRecord = null;

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand cmd = connection.CreateCommand()) {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM fn_getBookingRecordByRoomIdToCheckOut(@room_id)";
                    cmd.Parameters.Add("@room_id", SqlDbType.VarChar).Value = roomId;

                    try {
                        using(SqlDataReader reader = cmd.ExecuteReader()) {
                            if(reader.HasRows) {
                                while(reader.Read()) {
                                    bookingRecord = new BookingRecord() {
                                        BookingRecordId = reader["booking_record_id"].ToString(),
                                        BookingTime = Convert.ToDateTime(reader["booking_time"]),
                                        Status = reader["status"].ToString(),
                                        ExpectedCheckInTime = Convert.ToDateTime(reader["expected_check_in_time"]),
                                        ExpectedCheckOutTime = Convert.ToDateTime(reader["expected_check_out_time"]),
                                        ActualCheckInTime = reader.IsDBNull(reader.GetOrdinal("actual_check_in_time"))
                                                    ? (DateTime?)null
                                                    : Convert.ToDateTime(reader["actual_check_in_time"]),
                                        ActualCheckOutTime = reader.IsDBNull(reader.GetOrdinal("actual_check_out_time"))
                                                    ? (DateTime?)null
                                                    : Convert.ToDateTime(reader["actual_check_out_time"]),
                                        ReceptionistId = reader["receptionist_id"].ToString(),
                                        CustomerId = reader["customer_id"].ToString(),
                                        RoomId = reader["room_id"].ToString()
                                    };
                                }
                            }
                        }
                    } catch(SqlException ex) {
                        throw new Exception("Lỗi khi tìm kiếm booking record: " + ex.Message);
                    } catch(Exception ex) {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return bookingRecord;
        }
        public static void AddBookingRecord(string bookingRecordId, DateTime bookingTime, string status, DateTime expectedCheckInTime, DateTime expectedCheckOutTime, DateTime? actualCheckInTime, DateTime? actualCheckOutTime, string receptionistId, string customerId, string roomId) {
            SqlConnection conn = Connection.GetConnection();
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

            try {
                conn.Open();
                if(cmd.ExecuteNonQuery() > 0) {
                    MessageBox.Show("Đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch(Exception ex) {
                MessageBox.Show("Đặt phòng thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }

        public static void UpdateBookingRecordStatus(string bookingRecordId) {
            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateBookingRecord";

            cmd.Parameters.Add("@booking_record_id", SqlDbType.VarChar).Value = bookingRecordId;

            try {
                conn.Open();
                cmd.ExecuteNonQuery();
            } catch(Exception ex) {
                MessageBox.Show("Nhận phòng thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }
        public DataTable GetRoomBillByRoomId(string bookingRecordId) {
            DataTable roomBillTable = new DataTable();

            using(SqlConnection conn = Connection.GetConnection()) {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetRoomBillByBookingRecordId(@booking_record_id)", conn)) {
                    cmd.Parameters.Add("@booking_record_id", SqlDbType.VarChar).Value = bookingRecordId;

                    try {
                        conn.Open();
                        using(SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                            adapter.Fill(roomBillTable);
                        }
                    } catch(SqlException ex) {
                        throw new Exception("Lỗi khi lấy thông tin hóa đơn phòng: " + ex.Message);
                    }
                }
            }
            return roomBillTable;
        }

        public static void CheckOutRoom(string bookingRecordId) {
            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "sp_CheckOutRoom";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@booking_record_id", SqlDbType.VarChar).Value = bookingRecordId;

                    try {
                        command.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật thời gian trả phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }


        public static void UpdateStatusRoomBookingRecordAfterPay(string bookingRecordId) {
            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AfterPay";

            cmd.Parameters.Add("@booking_record_id", SqlDbType.VarChar).Value = bookingRecordId;

            try {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh toán hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex) {
                MessageBox.Show("Thanh toán thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }

        public static void AddPayMethod(string billid, string payMethod) {
            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdatePaymentMethod";

            cmd.Parameters.Add("@bill_id", SqlDbType.VarChar).Value = billid;
            cmd.Parameters.Add("@paymethod", SqlDbType.VarChar).Value = payMethod;

            try {
                conn.Open();
                cmd.ExecuteNonQuery();
            } catch(Exception ex) {
                MessageBox.Show("Có lỗi xảy ra:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }

        public static string GetBillIdByCustomerId(string customerId) {
            string billid = null;
            using(SqlConnection conn = Connection.GetConnection()) {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetBillIDByCustomerID(@customer_id)", conn)) {
                    cmd.Parameters.AddWithValue("@customer_id", customerId);

                    using(SqlDataReader reader = cmd.ExecuteReader()) {
                        // Kiểm tra nếu có dòng kết quả
                        if(reader.Read()) {
                            // Lấy giá trị của cột bill_id
                            billid = reader["bill_id"].ToString();
                        }
                    }
                }
            }
            return billid;
        }
    }
}
