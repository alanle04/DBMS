﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    internal class ServiceUsageRecordDAO {
        public DataTable GetServiceUsageRecordByBookingRecordId(string bookingRecordId) {
            DataTable serviceUsageTable = new DataTable();

            using(SqlConnection conn = DBConnection.Connection.GetConnection()) {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetServiceUsageByBookingId(@booking_id)", conn)) {
                    cmd.Parameters.Add("@booking_id", SqlDbType.VarChar).Value = bookingRecordId;

                  
                        conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(serviceUsageTable);

                    }
                }
            }
            return serviceUsageTable;
        }
        public int GetTotalServiceCost(string bookingId) {
            int totalServiceCost = 0;

            using(SqlConnection conn = DBConnection.Connection.GetConnection()) {
                using(SqlCommand cmd = new SqlCommand("SELECT fn_GetTotalServiceCost(@booking_id)", conn)) {
                    cmd.Parameters.Add("@booking_id", SqlDbType.VarChar).Value = bookingId;


                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        if(result != DBNull.Value) {
                            totalServiceCost = Convert.ToInt32(result);
                        }
                  
                }
            }

            return totalServiceCost;
        }


    }
}
