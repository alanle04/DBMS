using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCRoom : UserControl {
        private string username;
       
        RoomDAO roomDAO = new RoomDAO();
        RoomTypeDAO roomTypeDAO = new RoomTypeDAO();
        StaffDAO staffDAO = new StaffDAO();
        private int action = -1;

        public UCRoom() {
            InitializeComponent();
        }

        public UCRoom(string username)
        {
            InitializeComponent();
            this.username = username;
           

        }

        private void UCRoom_Load(object sender, System.EventArgs e) {
            SetDataGridViewHeaders(dgvRoomList);
            LoadData();
        }

        private void SetDataGridViewHeaders(DataGridView dgv) {
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã phòng", Name = "RoomID" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên phòng", Name = "RoomName" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", Name = "Status" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên loại phòng", Name = "RoomTypeName" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số giường", Name = "NumberOfBed" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sức chứa", Name = "Capacity" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá", Name = "Price" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người quản lý", Name = "Manager" });
        }

        private void LoadData() {
            dgvRoomList.Rows.Clear();
            DataTable dt = RoomDAO.GetAllRooms();
            for(int i = 0; i < dt.Rows.Count; i++) {
                string[] row = { dt.Rows[i]["room_id"].ToString(), dt.Rows[i]["room_name"].ToString(), dt.Rows[i]["status"].ToString(), dt.Rows[i]["room_type_name"].ToString(), dt.Rows[i]["number_of_bed"].ToString(), dt.Rows[i]["capacity"].ToString(), dt.Rows[i]["cost_per_day"].ToString(), dt.Rows[i]["manager_name"].ToString() };
                dgvRoomList.Rows.Add(row);
            }

            dt = roomTypeDAO.GetAllRoomTypeName();
            cbRoomTypeName.DataSource = dt;
            cbRoomTypeName.DisplayMember = "Name";
            cbRoomTypeName.SelectedIndex = -1;
        }

        private void dgvRoomList_CellClick(object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex >= 0) {
                DataGridViewRow row = dgvRoomList.Rows[e.RowIndex];

                txtRoomId.Text = row.Cells["RoomID"].Value.ToString();
                txtRoomName.Text = row.Cells["RoomName"].Value.ToString();
                cbRoomTypeName.Text = row.Cells["RoomTypeName"].Value.ToString();
                txtManager.Text = row.Cells["Manager"].Value.ToString();
            }
        }

        private void EnableInputForAdd(bool enable) {
            txtRoomId.Enabled = enable;
            txtRoomName.Enabled = enable;
            cbRoomTypeName.Enabled = enable;
        }

        private void EnableInputForUpdate(bool enable) {
            txtRoomId.Enabled = false;
            txtRoomName.Enabled = enable;
            cbRoomTypeName.Enabled = enable;
        }

        private bool IsEmpty(string text) {
            return text.Trim() == string.Empty;
        }

        private void btnAdd_Click(object sender, System.EventArgs e) {
            string managerFullName = staffDAO.GetStaffFullNameByUsername(username);
            if(managerFullName != null) {
                txtManager.Text = managerFullName;
            }
            EnableInputForAdd(true);
            action = 0;
        }


        private void btnUpdate_Click(object sender, System.EventArgs e) {
            string managerFullName = staffDAO.GetStaffFullNameByUsername(username);
            if(managerFullName != null) {
                txtManager.Text = managerFullName;
            }
            EnableInputForUpdate(true);
            action = 1;
        }

        private void btnDelete_Click(object sender, System.EventArgs e) {
            string managerFullName = staffDAO.GetStaffFullNameByUsername(username);
            if(managerFullName != null) {
                txtManager.Text = managerFullName;
            }

            EnableInputForAdd(false);
            action = 2;
        }

        private void ClearInput() {
            txtRoomId.Text = "";
            txtRoomName.Text = "";
            cbRoomTypeName.SelectedIndex = -1;
            txtManager.Text = "";
        }

        private void AddRoom() {
            if(IsEmpty(txtRoomId.Text) || IsEmpty(txtRoomName.Text) || IsEmpty(cbRoomTypeName.Text)) {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string managerId = staffDAO.GetStaffIdByUsername(username);

            string roomTypeId = roomTypeDAO.GetRoomTypeIdByRoomTypeName(cbRoomTypeName.Text.Trim());
            if(managerId != null) {
                Room room = new Room(txtRoomId.Text.Trim(), txtRoomName.Text.Trim(), "", roomTypeId, managerId);
                int res = roomDAO.AddRoom(room);
                if(res == 1) {
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                EnableInputForAdd(false);
                ClearInput();
                LoadData();
            }
        }

        private void UpdateRoom() {
            if(IsEmpty(txtRoomId.Text) || IsEmpty(txtRoomName.Text) || IsEmpty(cbRoomTypeName.Text)) {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string managerId = staffDAO.GetStaffIdByUsername(username);
            string roomTypeId = roomTypeDAO.GetRoomTypeIdByRoomTypeName(cbRoomTypeName.Text.Trim());

            if(managerId != null) {
                Room room = new Room(txtRoomId.Text.Trim(), txtRoomName.Text.Trim(), "", roomTypeId, managerId);
                int res = roomDAO.UpdateRoom(room);
                if(res == 1) {
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                EnableInputForUpdate(false);
                ClearInput();
                LoadData();
            }
        }

        private void DeleteRoom() {
            if(IsEmpty(txtRoomId.Text)) {
                MessageBox.Show("Vui lòng chọn phòng để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Xóa dịch vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialogResult == DialogResult.No) {
                return;
            }

            string managerId = staffDAO.GetStaffIdByUsername(username);
            if(managerId != null) {
                int res = roomDAO.DeleteRoom(txtRoomId.Text.Trim());
                if(res == 1) {
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Xóa thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearInput();
                LoadData();
            }
        }

        private void btnExecute_Click(object sender, System.EventArgs e) {
            if(action == -1) {
                MessageBox.Show("Vui lòng chọn chức năng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(action == 0) {
                AddRoom();
            } else if(action == 1) {
                UpdateRoom();
            } else if(action == 2) {
                DeleteRoom();
            }
            action = -1;
        }

        private void dgvRoomList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
