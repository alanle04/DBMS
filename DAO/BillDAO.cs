using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    internal class BillDAO {
        public static DataTable GetBills() {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_BillDetails";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }
            return dt;

        }
        public static DataTable GetDetailBills(string id) {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_BillDetails WHERE bill_id = @Id";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    
                    command.Parameters.AddWithValue("@Id", id);

                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dt);
                    }
                }

                connection.Close();
            }

            return dt;
        }

        public void UpdateBillWithDiscount(string bookingRecordId)
        {
            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_UpdateBillWithDiscount";

                    cmd.Parameters.Add("@booking_record_id", SqlDbType.VarChar).Value = bookingRecordId;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
