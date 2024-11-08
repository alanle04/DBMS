using HotelManagementSystem.DAO;
using HotelManagementSystem.DBConnection;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace HotelManagementSystem.GUI {
    public partial class UCRevenueDaily : UserControl
    {
        RevenueDailyDAO revenueDAO = new RevenueDailyDAO();


        public UCRevenueDaily(int day, int month, int year)
        {
            InitializeComponent();

            labelDaily.Text = (revenueDAO.GetTotalRevenueByDate(day, month, year)).ToString();
        }

        private void UCRevenueDaily_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelDaily_Click(object sender, EventArgs e)
        {

        }

        private void btnXemChiTietDoanhThu_Click(object sender, EventArgs e)
        {


          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}