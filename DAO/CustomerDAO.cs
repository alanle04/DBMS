﻿using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem.DAO {
    public class CustomerDAO {

        public Customer FindCustomerByCustomerId(string customerId) {
            Customer customer = null;

            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_FindCustomer(@CustomerId)", conn);
            cmd.Parameters.Add("@CustomerId", SqlDbType.VarChar).Value = customerId;

            try {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows) {
                    while(reader.Read()) {
                        customer = new Customer() {
                            CustomerId = reader["customer_id"].ToString(),
                            FullName = reader["full_name"].ToString(),
                            IdentificationNumber = reader["identification_number"].ToString(),
                            Gender = reader["gender"].ToString(),
                            Nationality = reader["nationality"].ToString(),
                            PhoneNumber = reader["phone_number"].ToString(),
                            Address = reader["address"].ToString()
                        };
                    }
                }
                reader.Close();
            } catch(SqlException ex) {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            } finally {
                conn.Close();
            }
            return customer;
        }

        public static DataTable FindCustomersByName(string fullName) {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT * FROM dbo.fn_FindCustomerByName(@full_name)";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@full_name", SqlDbType.NVarChar, 255).Value = fullName;

                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dt);
                    }
                }

                connection.Close();
            }

            return dt;
        }


        public static DataTable GetAllCustomers() {
            DataTable dt = new DataTable();

            using(SqlConnection connection = Connection.GetConnection()) {
                connection.Open();

                string query = "SELECT * FROM dbo.vw_Customer";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }

            return dt;

        }
        public static void AddCustomer(Customer customer) {
            using(SqlConnection connection = Connection.GetConnection()) {
                using(SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "sp_AddCustomer";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@customer_id", SqlDbType.VarChar).Value = customer.CustomerId;
                    command.Parameters.Add("@full_name", SqlDbType.NVarChar).Value = customer.FullName;
                    command.Parameters.Add("@gender", SqlDbType.VarChar).Value = customer.Gender;
                    command.Parameters.Add("@identification_number", SqlDbType.VarChar).Value = customer.IdentificationNumber;
                    command.Parameters.Add("@phone_number", SqlDbType.VarChar).Value = customer.PhoneNumber;
                    command.Parameters.Add("@nationality", SqlDbType.VarChar).Value = customer.Nationality;
                    command.Parameters.Add("@address", SqlDbType.NVarChar).Value = customer.Address;

                    try {
                        connection.Open();
                        if(command.ExecuteNonQuery() > 0) {
                            MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } catch(Exception ex) {
                        MessageBox.Show("Thêm khách hàng thất bại" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } finally {
                        connection.Close();
                    }
                }

            }
        }

    }
}
