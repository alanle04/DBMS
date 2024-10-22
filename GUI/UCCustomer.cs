using HotelManagementSystem.DAO;
using HotelManagementSystem.DBConnection;
using HotelManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCCustomer : UserControl
    {
        Connection db = new Connection();
        SearchCustomerDAO searchCustomerDAO = new SearchCustomerDAO();
        public UCCustomer()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvListCustomer.DataSource = CustomerDAO.GetAllCustomers();
            cbSearch.SelectedIndex = -1; 
        }

        private void dgvListCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListCustomer.Rows[e.RowIndex];

                txtFullName.Text = row.Cells["full_name"].Value.ToString();
                txtGender.Text = row.Cells["gender"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["phone_number"].Value.ToString();
                txtIdNumber.Text = row.Cells["identification_number"].Value.ToString();
                txtNationality.Text = row.Cells["nationality"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
            }
        }

        private bool IsEmpty(string text)
        {
            return text.Trim() == string.Empty;
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            string searchBy = cbSearch.Text.Trim();
            string searchInfor = txtCustomer.Text.Trim();


            if (IsEmpty(searchBy))
            {
                MessageBox.Show("Vui lòng chọn hình thức tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (IsEmpty(searchInfor))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cbSearch.SelectedIndex == 0)
                {
                    Customer customer = CustomerDAO.FindCustomerByIDNumber(searchInfor);
                    if (customer != null)
                    {
                        txtFullName.Text = customer.FullName;
                        txtIdNumber.Text = customer.IdentificationNumber;
                        txtGender.Text = customer.Gender;
                        txtNationality.Text = customer.Nationality;
                        txtPhoneNumber.Text = customer.PhoneNumber;
                        txtAddress.Text = customer.Address;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (cbSearch.SelectedIndex == 1)
                {
                    Customer customer = CustomerDAO.FindCustomerByCustomerId(searchInfor);
                    if (customer != null)
                    {
                        txtFullName.Text = customer.FullName;
                        txtIdNumber.Text = customer.IdentificationNumber;
                        txtGender.Text = customer.Gender;
                        txtNationality.Text = customer.Nationality;
                        txtPhoneNumber.Text = customer.PhoneNumber;
                        txtAddress.Text = customer.Address;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (cbSearch.SelectedIndex == 2)
                {
                    Customer customer = CustomerDAO.FindCustomersByName(searchInfor);
                    if (customer != null)
                    {
                        txtFullName.Text = customer.FullName;
                        txtIdNumber.Text = customer.IdentificationNumber;
                        txtGender.Text = customer.Gender;
                        txtNationality.Text = customer.Nationality;
                        txtPhoneNumber.Text = customer.PhoneNumber;
                        txtAddress.Text = customer.Address;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCustomers()
        {

            var customers = CustomerDAO.GetAllCustomers();

            // Giả sử bạn có một DataGridView tên là dgvCustomers
            dgvListCustomer.DataSource = customers;
        }
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            using (SqlConnection connection = Connection.GetConnection())
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

            dgvListCustomer.DataSource = dt; // Cập nhật DataGridView với DataTable
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
                    dgvListCustomer.DataSource = null; // Xóa dữ liệu cũ nếu không tìm thấy khách hàng
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
