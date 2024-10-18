using HotelManagementSystem.Properties;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace HotelManagementSystem.DBConnection {
    public class Connection {
        string strCon = @"Data Source=DESKTOP-EBUN5JD;Initial Catalog=hotel_management;Persist Security Info=True;User ID=sa;Password=1234567890";
        public SqlConnection sqlcon = null;
        public SqlConnection getConnection()
        {
             if (sqlcon == null)
            {
                sqlcon = new SqlConnection(strCon);
              }
            return sqlcon;
        }

        public void openConnection()
        {
            try
            {
                if (sqlcon == null)
                {
                    sqlcon = new SqlConnection(strCon);
                }
                sqlcon = new SqlConnection(strCon);
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void closeConnection() {
            if (sqlcon != null && sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
               
            }
           
        }

    }
}
