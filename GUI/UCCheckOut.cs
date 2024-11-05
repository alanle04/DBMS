using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagementSystem.GUI {
    public partial class UCCheckOut : UserControl {
        RoomDAO roomDAO = new RoomDAO();
        RoomTypeDAO roomTypeDAO = new RoomTypeDAO();
        BookingRecordDAO bookingRecordDAO = new BookingRecordDAO();
        CustomerDAO customerDAO = new CustomerDAO();
        ServiceUsageRecordDAO serviceUsageRecordDAO = new ServiceUsageRecordDAO();

        public UCCheckOut() {
            InitializeComponent();
        }
        private void LoadData(string roomName) {

            Room room = roomDAO.GetRoomByRoomName(roomName);
            if(room == null) {
                MessageBox.Show("Phòng này không tồn tại. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            RoomType roomType = roomTypeDAO.GetRoomTypeById(room.RoomTypeId);
            BookingRecord bookingRecord = bookingRecordDAO.GetBookingRecordByRoomIdToCheckOut(room.RoomId);
            Customer customer = customerDAO.FindCustomerByCustomerId(bookingRecord.CustomerId);

            txtBookingRecordId.Text = bookingRecord.BookingRecordId;
            txtFullName.Text = customer.FullName;
            txtIdNumber.Text = customer.IdentificationNumber;
            txtRoomName.Text = room.RoomName;
            txtRoomTypeName.Text = roomType.RoomTypeName;
            txtActualCheckInDate.Text = bookingRecord.ActualCheckInTime.ToString();

            //txtServiceFeeTotal.Text = serviceUsageRecordDAO.GetTotalServiceCost(bookingRecord.BookingRecordId).ToString();


            dgvRoomBill.DataSource = bookingRecordDAO.GetRoomBillByRoomId(bookingRecord.BookingRecordId);
            dgvServiceBill.DataSource = serviceUsageRecordDAO.GetServiceUsageRecordByBookingRecordId(bookingRecord.BookingRecordId);

            if(dgvRoomBill.Rows.Count > 0) {
                var totalValue = dgvRoomBill.Rows[0].Cells["total"].Value;

                txtTotal.Text = totalValue != null ? totalValue.ToString() : string.Empty;
            }
        }
        private bool IsEmpty(string text) {
            return text.Trim() == string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string roomName = txtSearchRoomName.Text;
            Room room = null;
            if(IsEmpty(roomName)) {
                MessageBox.Show("Vui lòng nhập tên phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try {
             
                LoadData(roomName);
            } catch(Exception ex) {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn trả phòng không?", "Xác nhận trả phòng",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes) {
                BookingRecordDAO.CheckOutRoom(txtBookingRecordId.Text.Trim());
                BookingRecordDAO.UpdateOverCheckOutFee(txtBookingRecordId.Text.Trim());
                LoadData(txtRoomName.Text.Trim());   
            }
        }

        private void btnPay_Click(object sender, EventArgs e) {
            Room room = roomDAO.GetRoomByRoomName(txtRoomName.Text.Trim());
            BookingRecord bookingRecord = bookingRecordDAO.GetBookingRecordByRoomIdToCheckOut(room.RoomId);
            Customer customer = customerDAO.FindCustomerByCustomerId(bookingRecord.CustomerId);
            string billid = BookingRecordDAO.GetBillIdByCustomerId(customer.CustomerId);
            string payMethod = "/";
            if (cbPaymentMethod.SelectedItem != null)
            {
                payMethod = cbPaymentMethod.SelectedItem.ToString();
            }
            BookingRecordDAO.AddPayMethod(billid, payMethod);
            if (cbPaymentMethod.SelectedItem != null)
            {
                BookingRecordDAO.UpdateStatusRoomBookingRecordAfterPay(txtBookingRecordId.Text.Trim());
            }
        }

        private void dgvRoomBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvServiceBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
