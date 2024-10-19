using HotelManagementSystem.DBConnection;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    public class StaffDAO {

        public string GetStaffIdByUsername(string username) {
            string staffId = null;

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();
                
                string query = "SELECT dbo.fn_GetStaffIdByUsername(@username)";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@username", username);


                    var objectId = command.ExecuteScalar();
                    if(objectId != null) {
                        staffId = objectId.ToString();
                    }
                }

                connection.Close();
            }


            return staffId;
        }

        public string GetStaffFullNameByUsername(string username) {
            string staffFullName = null;

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();
                string query = "SELECT dbo.fn_GetStaffFullNameByUsername(@username)";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@username", username);


                    var objectId = command.ExecuteScalar();
                    if(objectId != null) {
                        staffFullName = objectId.ToString();
                    }
                }

                connection.Close();
            }


            return staffFullName;
        }

    }
}
