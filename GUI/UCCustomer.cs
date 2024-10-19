using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;
using HotelManagementSystem.Model;
using HotelManagementSystem.DBConnection;
using HotelManagementSystem.DAO;

namespace HotelManagementSystem
{
    public partial class UCCustomer : UserControl
    {
        Connection db = new Connection();
        SearchCustomerDAO searchCustomerDAO = new SearchCustomerDAO();
        public UCCustomer()
        {
            InitializeComponent();
            LoadCustomers();
        }
        private void LoadCustomers()
        {

            var customers = GetAllCustomers();

            // Giả sử bạn có một DataGridView tên là dgvCustomers
            dtgvCustomer.DataSource = customers;
        }
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(db.strCon))
            {
                connection.Open();
                string query = "SELECT customer_id, full_name, gender, phone_number, identification_number, nationality, address FROM vw_Customer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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

        private void UCCustomer_Load(object sender, EventArgs e)
        {

        }
      
        private void UpdateCustomerGrid(List<Customer> customers)
        {
            // Chuyển đổi danh sách khách hàng thành DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Customer ID");
            dt.Columns.Add("Full Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Phone Number");
            dt.Columns.Add("Identification Number");
            dt.Columns.Add("Nationality");
            dt.Columns.Add("Address");

            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.CustomerId, customer.FullName, customer.Gender, customer.PhoneNumber, customer.IdentificationNumber, customer.Nationality, customer.Address);
            }

            dtgvCustomer.DataSource = dt; // Cập nhật DataGridView với DataTable
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            string find = txtCustomer.Text; // Giả sử bạn có một TextBox để nhập customer_id hoặc full_name
            if (!string.IsNullOrWhiteSpace(find))
            {
                // Tìm theo ID
                var customer = searchCustomerDAO.FindCustomerById(find);

                // Tìm theo tên
                var customersByName = searchCustomerDAO.FindCustomerByName(find);

                if (customer != null)
                {
                    // Nếu tìm thấy theo ID, hiển thị thông tin khách hàng
                    UpdateCustomerGrid(new List<Customer> { customer });
                }
                else if (customersByName.Count > 0)
                {
                    // Nếu tìm thấy theo tên, hiển thị danh sách khách hàng
                    UpdateCustomerGrid(customersByName);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng " + find, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgvCustomer.DataSource = null; // Xóa dữ liệu cũ nếu không tìm thấy khách hàng
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }
    }
}
