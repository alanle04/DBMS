using HotelManagementSystem.DAO;
using HotelManagementSystem.DBConnection;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelManagementSystem {
    public partial class UCBill : UserControl {
        Connection db = new Connection();
        
        public UCBill() {
            InitializeComponent();
            LoadBillDetails();

        }
        private void LoadBillDetails() {
            dtgv_listBill.DataSource = BillDAO.GetBills();
        }

        private void button1_Click(object sender, EventArgs e) {
          
        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }

        private void dtgv_listBill1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgv_listBill.Rows[e.RowIndex];

                txtMaHD.Text = row.Cells["bill_id"].Value.ToString();
               
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dtgvDetailBill.DataSource = BillDAO.GetDetailBills(txtMaHD.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
