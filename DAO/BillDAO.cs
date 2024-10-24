using HotelManagementSystem.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Model;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO
{
    internal class BillDAO
    {
        public static DataTable GetBills()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_bill";

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
        public static DataTable GetDetailBills(string id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                // Sử dụng tham số hóa để tránh SQL Injection
                string query = "SELECT * FROM dbo.vw_BillDetails WHERE bill_id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @Id với giá trị là 'id'
                    command.Parameters.AddWithValue("@Id", id);

                    // Sử dụng SqlDataAdapter để điền DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }

                connection.Close();
            }

            return dt;
        }


    }
}
