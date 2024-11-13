using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCBooking : UserControl {

        private string username;
        private StaffDAO staffDAO = new StaffDAO();

        public UCBooking() {
            InitializeComponent();
            LoadData();
        }

        public UCBooking(string username) {
            InitializeComponent();
            this.username = username;
            LoadData();
        }

        private void LoadData() {
            dgvListRoom.DataSource = RoomDAO.GetAllRooms();
            cbRoomType.DataSource = RoomTypeDAO.RoomTypeList();
            cbRoomType.ValueMember = "ID";
            cbRoomType.DisplayMember = "Name";

        }

        private void btnBook_Click(object sender, System.EventArgs e) {
            if(IsEmpty(txtFullName.Text) || IsEmpty(txtIdNumber.Text) || IsEmpty(txtPhoneNumber.Text) || IsEmpty(cbGender.Text) || IsEmpty(cbNationality.Text) || IsEmpty(txtAddress.Text) || IsEmpty(txtRoomId.Text)) {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng và phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime bookingTime = DateTime.Now;
            DateTime expectedCheckInTime = dtpCheckIn.Value;
            DateTime expectedCheckOutTime = dtpCheckOut.Value;

            string status = "deposited";

            string roomId = txtRoomId.Text;
            Customer customer = new Customer(
                Guid.NewGuid().ToString(),
                txtFullName.Text,
                cbGender.Text,
                txtIdNumber.Text,
                txtPhoneNumber.Text,
                cbNationality.Text,
                txtAddress.Text
            );

            CustomerDAO.AddCustomer(customer);
            string receptionistId = staffDAO.GetStaffIdByUsername(username);


            if(IsEmpty(receptionistId)) {
                MessageBox.Show("Không tìm thấy lễ tân với tên đăng nhập đã cho", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                BookingRecordDAO.AddBookingRecord(
                    Guid.NewGuid().ToString(),
                    bookingTime,
                    status,
                    expectedCheckInTime,
                    expectedCheckOutTime,
                    null,
                    null,
                    receptionistId,
                    customer.CustomerId,
                    roomId
                );
                LoadData();
            } catch(Exception ex) {
                MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchRooms_Click(object sender, System.EventArgs e) {
            string roomTypeName = cbRoomType.Text.Trim();

            if(IsEmpty(roomTypeName)) {
                MessageBox.Show("Vui lòng chọn loại phòng để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                DataTable dt = RoomDAO.FindRoomsByRoomType(roomTypeName);
                if(dt.Rows.Count > 0) {
                    dgvListRoom.DataSource = dt;
                } else {
                    MessageBox.Show("Không tìm thấy phòng nào phù hợp với loại phòng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvListRoom.DataSource = null;
                }
            } catch(Exception ex) {
                MessageBox.Show("Lỗi khi tìm kiếm phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListRoom_CellClick(object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex >= 0) {
                DataGridViewRow row = dgvListRoom.Rows[e.RowIndex];
                txtRoomId.Text = row.Cells["room_id"].Value.ToString();
                txtRoomName.Text = row.Cells["room_name"].Value.ToString();
                txtRoomType.Text = row.Cells["room_type_name"].Value.ToString();
                txtCapacity.Text = row.Cells["capacity"].Value.ToString();
                txtPrice.Text = row.Cells["cost_per_day"].Value.ToString();
            }
        }

        private bool IsEmpty(string text) {
            return text.Trim() == string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
