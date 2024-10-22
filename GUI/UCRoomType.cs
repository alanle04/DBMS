using HotelManagementSystem.DAO;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace HotelManagementSystem.GUI {
  
    public partial class UCRoomType : UserControl {
        private string username;
        StaffDAO staffDAO = new StaffDAO();
        public UCRoomType(string username) {
            InitializeComponent();
            this.username = username;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            String roomTypeId = txt_roomTypeId.Text;
            String roomTypeName = txt_roomTypeName.Text;
            int numberOfBeds = int.Parse(txt_numberOfBeds.Text);
            int capacity = int.Parse(txt_capacity.Text);
            int costPerDay = int.Parse(txt_costPerDay.Text);
            String managerId = staffDAO.GetStaffIdByUsername(username);

            RoomTypeDAO.AddRoomType(roomTypeId, roomTypeName, numberOfBeds, capacity, costPerDay, managerId);
            UCRoomType_Load(sender, new EventArgs());
        }

        private void UCRoomType_Load(object sender, EventArgs e)
        {
            dtgv_ListRoomType.DataSource = RoomTypeDAO.RoomTypeList();
        }

        private void dtgv_ListRoomType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dtgv_ListRoomType.DataSource;
            int index = -1;
            index = dtgv_ListRoomType.SelectedCells[0].RowIndex;
            DataRow row;
            try
            {
                row = dt.Rows[index];
            }
            catch
            {
                row = dt.Rows[0];
            }
            
            txt_roomTypeId.Text = row["ID"].ToString();
            txt_roomTypeName.Text = row["Name"].ToString();
            txt_numberOfBeds.Text = row["NumOfBed"].ToString();
            txt_capacity.Text = row["capacity"].ToString();
            txt_costPerDay.Text = row["Cost"].ToString();
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String roomTypeId = txt_roomTypeId.Text;
            String roomTypeName = txt_roomTypeName.Text;
            int numberOfBeds = int.Parse(txt_numberOfBeds.Text);
            int capacity = int.Parse(txt_capacity.Text);
            int costPerDay = int.Parse(txt_costPerDay.Text);
            String managerId = staffDAO.GetStaffIdByUsername(username);

            RoomTypeDAO.UpdateRoomType(roomTypeId, roomTypeName, numberOfBeds, capacity, costPerDay, managerId);
            UCRoomType_Load(sender, new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String roomTypeId = txt_roomTypeId.Text;
            RoomTypeDAO.DeleteRoomType(roomTypeId);
            UCRoomType_Load(sender, new EventArgs());
        }
    }
}
