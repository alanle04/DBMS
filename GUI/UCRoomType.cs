using HotelManagementSystem.DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem.GUI {
    public partial class UCRoomType : UserControl {
        private int action = -1;
        public UCRoomType() {
            InitializeComponent();
        }

        public UCRoomType(string username) {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e) {
            action = 0;
            txt_capacity.Enabled = true;
            txt_costPerDay.Enabled = true;
            txt_numberOfBeds.Enabled = true;
            txt_roomTypeId.Enabled = true;
            txt_roomTypeName.Enabled = true;
            cbManagerID.Enabled= true;

        }

        private void UCRoomType_Load(object sender, EventArgs e) {
            dtgv_ListRoomType.DataSource = RoomTypeDAO.RoomTypeList();
            cbManagerID.DataSource = StaffDAO.GetManager();
            cbManagerID.DisplayMember = "staff_id";
            txt_capacity.Enabled = false;
            txt_costPerDay.Enabled = false;
            txt_numberOfBeds.Enabled = false;
            txt_roomTypeId.Enabled = false;
            txt_roomTypeName.Enabled = false;
            cbManagerID.Enabled = false;
        }

        private void dtgv_ListRoomType_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataTable dt = new DataTable();
            dt = (DataTable)dtgv_ListRoomType.DataSource;
            int index = -1;
            index = dtgv_ListRoomType.SelectedCells[0].RowIndex;
            DataRow row;
            try {
                row = dt.Rows[index];
            } catch {
                row = dt.Rows[0];
            }

            txt_roomTypeId.Text = row["ID"].ToString();
            txt_roomTypeName.Text = row["Name"].ToString();
            txt_numberOfBeds.Text = row["NumOfBed"].ToString();
            txt_capacity.Text = row["capacity"].ToString();
            txt_costPerDay.Text = row["Cost"].ToString();
            cbManagerID.Text = row["managerId"].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            action = 1;
            txt_capacity.Enabled = true;
            txt_costPerDay.Enabled = true;
            txt_numberOfBeds.Enabled = true;
            txt_roomTypeId.Enabled = false;
            txt_roomTypeName.Enabled = true;
            cbManagerID.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            action = 2;
        }
        private void AddRoomType(object sender, EventArgs e) {
            String roomTypeId = txt_roomTypeId.Text;
            String roomTypeName = txt_roomTypeName.Text;
            int numberOfBeds = int.Parse(txt_numberOfBeds.Text);
            int capacity = int.Parse(txt_capacity.Text);
            int costPerDay = int.Parse(txt_costPerDay.Text);
            DataRowView selectedManager = cbManagerID.SelectedItem as DataRowView;

            // Lấy giá trị staff_id từ DataRowView
            String managerId = selectedManager["staff_id"].ToString();
            MessageBox.Show(managerId);


            RoomTypeDAO.AddRoomType(roomTypeId, roomTypeName, numberOfBeds, capacity, costPerDay, managerId);

            UCRoomType_Load(sender, new EventArgs());
            clear();
        }
        private void UpdateRoomType(object sender, EventArgs e) {
            String roomTypeId = txt_roomTypeId.Text;
            String roomTypeName = txt_roomTypeName.Text;
            int numberOfBeds = int.Parse(txt_numberOfBeds.Text);
            int capacity = int.Parse(txt_capacity.Text);
            int costPerDay = int.Parse(txt_costPerDay.Text);
            DataRowView selectedManager = cbManagerID.SelectedItem as DataRowView;

            // Lấy giá trị staff_id từ DataRowView
            String managerId = selectedManager["staff_id"].ToString();

            RoomTypeDAO.UpdateRoomType(roomTypeId, roomTypeName, numberOfBeds, capacity, costPerDay, managerId);
            UCRoomType_Load(sender, new EventArgs());
            clear();
        }

        private void DeleteRoomType(object sender, EventArgs e) {
            String roomTypeId = txt_roomTypeId.Text;
            RoomTypeDAO.DeleteRoomType(roomTypeId);
            UCRoomType_Load(sender, new EventArgs());
            clear();
        }

        private void clear() {
            txt_capacity.Text = "";
            txt_costPerDay.Text = "";
            txt_numberOfBeds.Text = "";
            txt_roomTypeId.Text = "";
            txt_roomTypeName.Text = "";
        }

        private void btn_excute_Click_1(object sender, EventArgs e)
        {
            if (action == -1)
            {
                MessageBox.Show("Vui lòng chọn chức năng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (action == 0)
            {
                AddRoomType(sender, e);
            }
            else if (action == 1)
            {
                UpdateRoomType(sender, e);
            }
            else if (action == 2)
            {
                DeleteRoomType(sender, e);
            }
            action = -1;
        }
    }
}
