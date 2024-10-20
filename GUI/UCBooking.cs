using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;
using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;

namespace HotelManagementSystem {
    public partial class UCBooking : UserControl {

        private string username;
        private StaffDAO staffDAO = new StaffDAO();

        public UCBooking()
        {
            InitializeComponent();
            LoadData();
        }

        public UCBooking(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadData();
        }

        private void LoadData()
        {
            dgvListRoom.DataSource = RoomDAO.GetAllRooms();
        }

        private void btnBook_Click(object sender, System.EventArgs e)
        {
            if (IsEmpty(txtCustomerId.Text) || IsEmpty(txtRoomId.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng và phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime bookingTime = DateTime.Now;
            DateTime expectedCheckInTime = dtpCheckIn.Value;
            DateTime expectedCheckOutTime = dtpCheckOut.Value;

            string status = "deposited";

            string customerId = txtCustomerId.Text;
            string roomId = txtRoomId.Text;

            string receptionistId = staffDAO.GetStaffIdByUsername(username);

            if (IsEmpty(receptionistId))
            {
                MessageBox.Show("Không tìm thấy lễ tân với tên đăng nhập đã cho", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                BookingRecordDAO.AddBookingRecord(
                    Guid.NewGuid().ToString(),
                    bookingTime,
                    status,
                    expectedCheckInTime,
                    expectedCheckOutTime,
                    null,
                    null,
                    receptionistId,
                    customerId,
                    roomId
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchRooms_Click(object sender, System.EventArgs e)
        {
            string roomTypeName = cbRoomType.Text.Trim();

            if (IsEmpty(roomTypeName))
            {
                MessageBox.Show("Vui lòng chọn loại phòng để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = RoomDAO.FindRoomsByRoomType(roomTypeName);
                if (dt.Rows.Count > 0)
                {
                    dgvListRoom.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng nào phù hợp với loại phòng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvListRoom.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListRoom.Rows[e.RowIndex];
                txtRoomId.Text = row.Cells["room_id"].Value.ToString();
                txtRoomName.Text = row.Cells["room_name"].Value.ToString();
                txtRoomType.Text = row.Cells["room_type_name"].Value.ToString();
                txtCapacity.Text = row.Cells["capacity"].Value.ToString();
                txtPrice.Text = row.Cells["cost_per_day"].Value.ToString();
            }
        }

        private bool IsEmpty(string text)
        {
            return text.Trim() == string.Empty;
        }

        private void btnSearchByIdNumber_Click(object sender, EventArgs e)
        {
            string identificationNumber = txtSearchByIdNumber.Text.Trim();

            if (IsEmpty(identificationNumber))
            {
                MessageBox.Show("Vui lòng nhập số CMND/CCCD của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Customer customer = CustomerDAO.FindCustomerByIDNumber(identificationNumber);
                if (customer != null)
                {
                    txtCustomerId.Text = customer.CustomerId;
                    txtFullName.Text = customer.FullName;
                    txtIdNumber.Text = customer.IdentificationNumber;
                    cbGender.Text = customer.Gender;
                    cbNationality.Text = customer.Nationality;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtAddress.Text = customer.Address;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
