using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class ServiceDAO {

        public DataTable GetAllServices() {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_Service";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }

            return dt;

        }

        public int AddService(Service service) {
            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "sp_AddService";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@service_id", SqlDbType.VarChar).Value = service.ServiceId;
                    command.Parameters.Add("@service_name", SqlDbType.NVarChar).Value = service.ServiceName;
                    command.Parameters.Add("@price", SqlDbType.Int).Value = service.Price;
                    command.Parameters.Add("@description", SqlDbType.NVarChar).Value = service.Description;
                    command.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = service.ManagerId;

                    try {
                        if(command.ExecuteNonQuery() > 0) {
                            return 1;
                        }
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }

                return 0;
            }

        }

        public int UpdateService(Service service) {
            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "sp_UpdateService";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@service_id", SqlDbType.VarChar).Value = service.ServiceId;
                    command.Parameters.Add("@service_name", SqlDbType.NVarChar).Value = service.ServiceName;
                    command.Parameters.Add("@price", SqlDbType.Int).Value = service.Price;
                    command.Parameters.Add("@description", SqlDbType.NVarChar).Value = service.Description;
                    command.Parameters.Add("@manager_id", SqlDbType.VarChar).Value = service.ManagerId;

                    try {
                        if(command.ExecuteNonQuery() > 0) {
                            return 1;
                        }
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }

                return 0;
            }
        }

        public int DeleteService(Service service) {
            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "sp_DeleteService";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@service_id", SqlDbType.VarChar).Value = service.ServiceId;

                    try {
                        if(command.ExecuteNonQuery() > 0) {
                            return 1;
                        }
                    } catch(SqlException sqlEx) {
                        MessageBox.Show(sqlEx.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }

                return 0;
            }
        }
    }
}
