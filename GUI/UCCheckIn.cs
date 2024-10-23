using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCCheckIn : UserControl {
        public UCCheckIn() {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvCheckInRooms.DataSource = RoomDAO.GetDepositedRooms();
        }

        private bool IsEmpty(string text)
        {
            return text.Trim() == string.Empty;
        }

        private void btnSearchByIdNumber_Click(object sender, System.EventArgs e)
        {
            string identificationNumber = txtSearchByIdNumber.Text;

            if (IsEmpty(identificationNumber))
            {
                MessageBox.Show("Vui lòng nhập số CMND/CCCD của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = RoomDAO.GetDepositedRoomsByIdNumber(identificationNumber);
                if (dt.Rows.Count > 0)
                {
                    dgvCheckInRooms.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCheckInRooms.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCheckInRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCheckInRooms.Rows[e.RowIndex];
                txtBookingRecordId.Text = row.Cells["booking_record_id"].Value.ToString();
                txtFullName.Text = row.Cells["full_name"].Value.ToString();
                txtIdNumber.Text = row.Cells["identification_number"].Value.ToString();
                txtRoomName.Text = row.Cells["room_name"].Value.ToString();
                txtRoomTypeName.Text = row.Cells["room_type_name"].Value.ToString();
                txtCheckInDate.Text = row.Cells["expected_check_in_time"].Value.ToString();
                txtCheckOutDate.Text = row.Cells["expected_check_out_time"].Value.ToString();
                txtCapacity.Text = row.Cells["capacity"].Value.ToString();
                txtPrice.Text = row.Cells["cost_per_day"].Value.ToString();
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string bookingRecordId = txtBookingRecordId.Text;

            if (IsEmpty(bookingRecordId))
            {
                MessageBox.Show("Vui lòng chọn phòng để check in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult result = MessageBox.Show("Bạn có chắc muốn nhận phòng này không?", "Xác nhận nhận phòng",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    BookingRecordDAO.UpdateBookingRecordStatus(bookingRecordId);
                    MessageBox.Show("Nhận phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhận phòng thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
