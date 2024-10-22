using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAO {
    internal class SearchCustomerDAO
    {
        public List<Customer> FindCustomerByName(string fullName)
        {
            var customers = new List<Customer>();
            Connection db = new Connection(); // Kết nối cơ sở dữ liệu

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();
                // Truy vấn để gọi hàm fn_FindtoNameCustomer
                string query = "SELECT * FROM fn_FindtoNameCustomer(@full_name)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho truy vấn
                    command.Parameters.AddWithValue("@full_name", fullName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = reader.GetString(0),
                                FullName = reader.GetString(1),
                                Gender = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                IdentificationNumber = reader.GetString(4),
                                Nationality = reader.GetString(5),
                                Address = reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return customers;
        }
        public Customer FindCustomerById(string customerId)
        {
            Customer customer = null;
            Connection db = new Connection();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM fn_FindIDCustomer(@customer_id)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_id", customerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerId = reader.GetString(0), // Giả sử customer_id là cột đầu tiên
                                FullName = reader.GetString(1),
                                Gender = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                IdentificationNumber = reader.GetString(4),
                                Nationality = reader.GetString(5),
                                Address = reader.GetString(6)
                            };
                        }
                    }
                }
            }

            return customer;
        }
    }
}
