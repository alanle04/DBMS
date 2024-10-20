using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCCustomer : UserControl
    {
        public UCCustomer()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvListCustomer.DataSource = CustomerDAO.GetAllCustomers();
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
            string searchInfor = txtSearch.Text.Trim();
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
                if (searchBy == "CMND/CCCD")
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
                if (searchBy == "Mã khách")
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
                else if (searchBy == "Tên")
                {
                    DataTable customers = CustomerDAO.FindCustomersByName(searchInfor);

                    if (customers.Rows.Count > 0)
                    {
                        dgvListCustomer.DataSource = customers;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với tên đã cho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
