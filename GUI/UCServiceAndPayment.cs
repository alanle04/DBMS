using HotelManagementSystem.DAO;
using HotelManagementSystem.Model;
using System.Data;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelManagementSystem {
    public partial class UCServiceAndPayment : UserControl
    {
        string username = "";
        public UCServiceAndPayment(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btn_bookService_Click(object sender, System.EventArgs e)
        {
            StaffDAO staffdao = new StaffDAO();
            string staffId = staffdao.GetStaffIdByUsername(username);

            DateTime usageTime = DateTime.Now;

            int quantity = int.Parse(txt_quantity.Text);

            string serviceId = "";
            DataRowView dr = (DataRowView)cb_ServiceType.SelectedItem;
            if (dr != null)
            {
                serviceId = dr["service_id"].ToString();
            }

            string serviceUsageId = serviceId + usageTime.Date.ToString();

            string bookingRecordId = BookingServiceDAO.GetBookingRecordIdByRoomID(txt_roomId.Text);

            BookingServiceDAO.BookingService(serviceUsageId, usageTime, quantity, bookingRecordId, staffId, serviceId);

            btn_searchByRoom_Click(sender, e);  

        }

        private void UCServiceAndPayment_Load(object sender, EventArgs e)
        {
            ServiceDAO serdao = new ServiceDAO();
            DataTable dt = serdao.GetAllServices();
            cb_ServiceType.DataSource = dt;
            cb_ServiceType.DisplayMember = "service_name";
            cb_ServiceType.ValueMember = "service_id";

        }

        private void cb_ServiceType_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)cb_ServiceType.SelectedItem;
            if (dr != null)
            {
                txt_price.Text = dr["price"].ToString();
            }

        }

        private void btn_searchByRoom_Click(object sender, EventArgs e)
        {
            dtgv_bill.DataSource = BookingServiceDAO.GetBillInfoByRoomId(txt_roomId.Text);
            dtgv_serviceUsage.DataSource = BookingServiceDAO.GetServiceUsageInfoByRoomId(txt_roomId.Text);
        }
    }
}
