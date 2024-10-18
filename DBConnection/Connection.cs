using HotelManagementSystem.Properties;
using System;
using System.Data.SqlClient;

namespace HotelManagementSystem.DBConnection {
    public class Connection {
        static string strCon = Settings.Default.connectionString;
        static SqlConnection sqlcon = null;

        public static SqlConnection GetConnection() {
            if(sqlcon == null || sqlcon.State == System.Data.ConnectionState.Closed || sqlcon.State == System.Data.ConnectionState.Broken) {
                sqlcon = new SqlConnection(strCon);
            }
            return sqlcon;
        }

        public static void CloseConnection() {
            if(sqlcon != null && sqlcon.State == System.Data.ConnectionState.Open) {
                sqlcon.Close();
            }
        }
    }
}
