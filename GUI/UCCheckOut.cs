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
        BillDAO billDAO = new BillDAO();
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
            if (bookingRecord != null)
            {
                Customer customer = customerDAO.FindCustomerByCustomerId(bookingRecord.CustomerId);
                txtFullName.Text = customer.FullName;
                txtIdNumber.Text = customer.IdentificationNumber;
            }
            else
            {
                MessageBox.Show("Phòng chưa được sử dụng!");
                return;
            }


            txtBookingRecordId.Text = bookingRecord.BookingRecordId;
            txtRoomName.Text = room.RoomName;
            txtRoomTypeName.Text = roomType.RoomTypeName;
            txtActualCheckInDate.Text = bookingRecord.ActualCheckInTime.ToString();

            dgvRoomBill.DataSource = bookingRecordDAO.GetRoomBillByBookingRecordId(bookingRecord.BookingRecordId);
            dgvServiceBill.DataSource = serviceUsageRecordDAO.GetServiceUsageRecordByBookingRecordId(bookingRecord.BookingRecordId);
           

            //txtServiceFeeTotal.Text = serviceUsageRecordDAO.GetTotalServiceCost(bookingRecord.BookingRecordId).ToString();

            if (dgvRoomBill.Rows.Count > 0)
            {
                var totalValue = dgvRoomBill.Rows[0].Cells["total"].Value;
                var totalService = dgvServiceBill.Rows.Count > 0 ? dgvServiceBill.Rows[0].Cells["total"].Value : null;

                // Kiểm tra nếu giá trị không phải là null
                if (totalValue != null)
                {
                    decimal total = Convert.ToDecimal(totalValue);
                    // Gán tổng vào txtTotal.Text
                    txtTotal.Text = total.ToString();
                }
                else
                {
                    txtTotal.Text = string.Empty; // Nếu totalValue là null, hiển thị rỗng
                }
            }
            else
            {
                txtTotal.Text = string.Empty; // Nếu không có hàng trong dgvRoomBill, hiển thị rỗng
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
                billDAO.UpdateBillWithDiscount(txtBookingRecordId.Text.Trim());
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
