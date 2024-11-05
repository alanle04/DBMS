using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class UCService : UserControl
    {
        private string username;
        private int action = -1;

        ServiceDAO serviceDAO = new ServiceDAO();
        StaffDAO staffDAO = new StaffDAO();

        public UCService()
        {
            InitializeComponent();

        }

        public UCService(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void LoadData()
        {
            dgvService.Rows.Clear();
            DataTable dt = serviceDAO.GetAllServices();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] row = { dt.Rows[i]["service_id"].ToString(), dt.Rows[i]["service_name"].ToString(), dt.Rows[i]["price"].ToString(), dt.Rows[i]["description"].ToString(), dt.Rows[i]["manager_name"].ToString() };
                dgvService.Rows.Add(row);
            }
        }

        private void ClearInput()
        {
            txtServiceId.Text = "";
            txtServiceName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtManager.Text = "";
        }

        private void SetDataGridViewHeaders(DataGridView dgv)
        {
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã dịch vụ", Name = "ServiceID" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên dịch vụ", Name = "ServiceName" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá", Name = "Price" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô tả", Name = "Description" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người quản lý", Name = "Manager" });
        }

        private void UCService_Load(object sender, System.EventArgs e)
        {
            SetDataGridViewHeaders(dgvService);
            LoadData();
        }

        private void EnableInputForAdd(bool enable)
        {
            txtServiceId.Enabled = enable;
            txtServiceName.Enabled = enable;
            txtPrice.Enabled = enable;
            txtDescription.Enabled = enable;
        }

        private void EnableInputForUpdate(bool enable)
        {
            txtServiceId.Enabled = false;
            txtServiceName.Enabled = enable;
            txtPrice.Enabled = enable;
            txtDescription.Enabled = enable;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            string managerFullName = staffDAO.GetStaffFullNameByUsername(username);
            if (managerFullName != null)
            {
                txtManager.Text = managerFullName;
            }
            EnableInputForAdd(true);
            action = 0;
        }

        private bool IsEmpty(string text)
        {
            return text.Trim() == string.Empty;
        }

        private void AddService()
        {
            if (IsEmpty(txtServiceId.Text) || IsEmpty(txtServiceName.Text) || IsEmpty(txtPrice.Text) || IsEmpty(txtDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                int.Parse(txtPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Giá chỉ bao gồm các con số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string managerId = staffDAO.GetStaffIdByUsername(username);
            if (managerId != null)
            {
                Service service = new Service(txtServiceId.Text.Trim(), txtServiceName.Text.Trim(), int.Parse(txtPrice.Text.Trim()), txtDescription.Text.Trim(), managerId);
                try
                {
                    serviceDAO.AddService(service);
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                EnableInputForAdd(false);
                ClearInput();
                LoadData();
            }
        }

        private void UpdateService()
        {
            if (IsEmpty(txtServiceId.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (IsEmpty(txtServiceName.Text) || IsEmpty(txtPrice.Text) || IsEmpty(txtDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                int.Parse(txtPrice.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giá chỉ bao gồm các con số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string managerId = staffDAO.GetStaffIdByUsername(username);
            if (managerId != null)
            {
                Service service = new Service(txtServiceId.Text.Trim(), txtServiceName.Text.Trim(), int.Parse(txtPrice.Text.Trim()), txtDescription.Text.Trim(), managerId);
                try
                {
                    serviceDAO.UpdateService(service);
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                EnableInputForUpdate(false);
                ClearInput();
                LoadData();
            }

        }

        private void DeleteService()
        {
            if (IsEmpty(txtServiceId.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Xóa dịch vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            string managerId = staffDAO.GetStaffIdByUsername(username);
            if (managerId != null)
            {
                Service service = new Service(txtServiceId.Text.Trim(), txtServiceName.Text.Trim(), int.Parse(txtPrice.Text.Trim()), txtDescription.Text.Trim(), managerId);
                int res = serviceDAO.DeleteService(service);
                if (res == 1)
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearInput();
                LoadData();
            }
        }

        private void btnExecute_Click(object sender, System.EventArgs e)
        {
            if (action == -1)
            {
                MessageBox.Show("Vui lòng chọn chức năng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (action == 0)
            {
                AddService();
            }
            else if (action == 1)
            {
                UpdateService();
            }
            else if (action == 2)
            {
                DeleteService();
            }
            action = -1;
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvService.Rows[e.RowIndex];

                txtServiceId.Text = row.Cells["ServiceID"].Value.ToString();
                txtServiceName.Text = row.Cells["ServiceName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                txtManager.Text = row.Cells["Manager"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string managerFullName = staffDAO.GetStaffFullNameByUsername(username);
            if (managerFullName != null)
            {
                txtManager.Text = managerFullName;
            }

            EnableInputForUpdate(true);
            action = 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string managerFullName = staffDAO.GetStaffFullNameByUsername(username);
            if (managerFullName != null)
            {
                txtManager.Text = managerFullName;
            }

            EnableInputForAdd(false);
            action = 2;
        }
    }
}
