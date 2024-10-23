using HotelManagementSystem.DBConnection;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCBill : UserControl {
        public UCBill() {
            InitializeComponent();
            LoadBillDetails();

        }
        private void LoadBillDetails() {
            string sql = "SELECT * FROM vw_BillDetails";
            SqlConnection conn = Connection.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgv_listBill1.DataSource= dt;
        }

        private void dtgv_listBill1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_listBill1.Rows[e.RowIndex];
                txt_roomfee.Text = row.Cells["room_fee"].Value.ToString();
                txt_servicefee.Text = row.Cells["service_fee"].Value.ToString();
                txt_additionfee.Text = row.Cells["additional_fee"].Value.ToString();
                txt_total.Text = row.Cells["total"].Value.ToString();
                txt_paymethod.Text = row.Cells["payment_method"].Value.ToString();
                txtBillId.Text = row.Cells["bill_id"].Value.ToString();
                txtCusname.Text = row.Cells["customer_name"].Value.ToString();
                txt_staff.Text = row.Cells["staff_name"].Value.ToString();
            }
        }
    }
}
