using HotelManagementSystem.DAO;
using System;
using System.Windows.Forms;


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
    }
}
