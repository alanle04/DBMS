using HotelManagementSystem.DBConnection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCBill : UserControl {
        Connection db = new Connection();
        public UCBill() {
            InitializeComponent();
           
          

        }
      
        private void LoadBillDetails() {
            string sql = "SELECT * FROM vw_BillDetails";
            SqlConnection conn = DBConnection.Connection.GetConnection();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void dtgv_listBill1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCBill_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
          
          
        }

        private void txtBillId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
