using HotelManagementSystem.DBConnection;
using HotelManagementSystem.GUI;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCDashboard : UserControl {
        public UCDashboard() {

            InitializeComponent();

        }


        private void panel2_Paint(object sender, PaintEventArgs e) {

        }


        private void pictureBox1_Click(object sender, EventArgs e) {


        }
        private bool IsValidMonthYearInput(string input, out int month, out int year) {
            // Khởi tạo giá trị đầu ra
            month = 0;
            year = 0;

            string[] parts = input.Split('-');

            if(parts.Length != 2) return false;

            if(int.TryParse(parts[0], out month) && month >= 1 && month <= 12) {
                if(int.TryParse(parts[1], out year) && year >= 2000) 
                {
                    return true; // Đầu vào hợp lệ
                }
            }

            return false; // Đầu vào không hợp lệ
        }

        private void btnShowRevenue_Click(object sender, EventArgs e) {
            string input = txtMonthly.Text;

            // Kiểm tra định dạng
            if(!IsValidMonthYearInput(input, out int month, out int year)) {
                MessageBox.Show("Đầu vào không hợp lệ. Vui lòng nhập theo định dạng 'MM-YYYY' (ví dụ: 02-2022).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Xóa giá trị trong textbox hoặc đặt lại giá trị mặc định nếu cần
                txtMonthly.Clear();
            } else {


                panel2.Controls.Clear(); // Xóa các điều khiển cũ (nếu cần)
                UCRevenueMonthly ucRevenueMonthly = new UCRevenueMonthly(month, year);
                ucRevenueMonthly.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian có sẵn
                panel2.Controls.Add(ucRevenueMonthly); // Thêm User Control vào Panel
            }
        }

        private void dtpkMonth_ValueChanged(object sender, EventArgs e) {

        }


        private void btnRevenueQuarterly_Click(object sender, EventArgs e) {



            // Lấy giá trị từ textbox
            string input = txtQuarter.Text;

            // Kiểm tra định dạng
            if(!IsValidQuarterInput(input, out int quarter, out int year)) {
                MessageBox.Show("Đầu vào không hợp lệ. Vui lòng nhập theo định dạng 'Quý-Năm' (ví dụ: 1-2021).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Xóa giá trị trong textbox hoặc đặt lại giá trị mặc định nếu cần
                txtQuarter.Clear();
            } else {
                panel2.Controls.Clear(); // Xóa các điều khiển cũ (nếu cần)
                UCRevenueQuarter ucRevenueQuarter = new UCRevenueQuarter(quarter, year);
                ucRevenueQuarter.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian có sẵn
                panel2.Controls.Add(ucRevenueQuarter); // Thêm User Control vào Panel
            }
        }
        private bool IsValidDayMonthYearInput(string input, out int day, out int month, out int year) {
            // Khởi tạo giá trị đầu ra
            day = 0;
            month = 0;
            year = 0;

            // Tách chuỗi theo dấu '-' để lấy ngày, tháng và năm
            string[] parts = input.Split('-');

            // Kiểm tra nếu có đúng 3 phần
            if(parts.Length != 3) return false;

            // Kiểm tra ngày
            if(int.TryParse(parts[0], out day) && day >= 1 && day <= 31) {
                // Kiểm tra tháng
                if(int.TryParse(parts[1], out month) && month >= 1 && month <= 12) {
                    // Kiểm tra năm
                    if(int.TryParse(parts[2], out year) && year >= 2000) // Kiểm tra năm lớn hơn hoặc bằng 2000
                    {
                        // Kiểm tra ngày hợp lệ trong tháng
                        return IsValidDate(day, month, year);
                    }
                }
            }

            return false; // Đầu vào không hợp lệ
        }

        private void btnRevenueDaily_Click(object sender, EventArgs e) {
            // Lấy giá trị từ textbox
            string input = txtDaily.Text;

            // Kiểm tra định dạng
            if(!IsValidDayMonthYearInput(input, out int day, out int month, out int year)) {
                MessageBox.Show("Đầu vào không hợp lệ. Vui lòng nhập theo định dạng 'Ngày-Tháng-Năm' (ví dụ: 15-02-2022).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Xóa giá trị trong textbox hoặc đặt lại giá trị mặc định nếu cần
                txtDaily.Clear();
            } else {
                panel2.Controls.Clear();
                UCRevenueDaily ucRevenueDaily = new UCRevenueDaily(day, month, year);
                ucRevenueDaily.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian có sẵn
                panel2.Controls.Add(ucRevenueDaily); // Thêm User Control vào Panel
            }
        }

        private void labelDaily_Click(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e) {

        }
        private bool IsValidQuarterInput(string input, out int quarter, out int year) {
            quarter = 0;
            year = 0;

            // Tách chuỗi theo dấu '-'
            string[] parts = input.Split('-');

            // Kiểm tra số lượng phần tử
            if(parts.Length != 2)
                return false;

            // Kiểm tra và phân tích quý
            if(!int.TryParse(parts[0], out quarter) || quarter < 1 || quarter > 4)
                return false;

            // Kiểm tra và phân tích năm
            if(!int.TryParse(parts[1], out year) || year < 1900 || year > DateTime.Now.Year)
                return false;

            return true;
        }

        private void txtMonthly_TextChanged(object sender, EventArgs e) {

        }

        private bool IsValidMonthYearInput(string input) {
            // Tách chuỗi theo dấu '-' để lấy tháng và năm
            string[] parts = input.Split('-');

            // Kiểm tra nếu có đúng 2 phần
            if(parts.Length != 2) return false;

            // Kiểm tra tháng
            if(int.TryParse(parts[0], out int month) && month >= 1 && month <= 12) {
                // Kiểm tra năm
                if(int.TryParse(parts[1], out int year) && year >= 2000) // Kiểm tra năm lớn hơn hoặc bằng 2000
                {
                    return true; // Đầu vào hợp lệ
                }
            }

            return false; // Đầu vào không hợp lệ
        }

        private void txtDaily_TextChanged(object sender, EventArgs e) {

        }

        private bool IsValidDayMonthYearInput(string input) {
            // Tách chuỗi theo dấu '-' để lấy ngày, tháng và năm
            string[] parts = input.Split('-');

            // Kiểm tra nếu có đúng 3 phần
            if(parts.Length != 3) return false;

            // Kiểm tra ngày
            if(int.TryParse(parts[0], out int day) && day >= 1 && day <= 31) {
                // Kiểm tra tháng
                if(int.TryParse(parts[1], out int month) && month >= 1 && month <= 12) {
                    // Kiểm tra năm
                    if(int.TryParse(parts[2], out int year) && year >= 2000) // Kiểm tra năm lớn hơn hoặc bằng 2000
                    {
                        // Kiểm tra ngày hợp lệ trong tháng
                        return IsValidDate(day, month, year);
                    }
                }
            }

            return false; // Đầu vào không hợp lệ
        }

        private bool IsValidDate(int day, int month, int year) {
            // Kiểm tra số ngày hợp lệ trong từng tháng
            if(month == 2) // Tháng 2
            {
                if(IsLeapYear(year))
                    return day <= 29; // Năm nhuận
                else
                    return day <= 28; // Năm không nhuận
            } else if(month == 4 || month == 6 || month == 9 || month == 11) // Các tháng có 30 ngày
              {
                return day <= 30;
            } else // Các tháng còn lại có 31 ngày
              {
                return day <= 31;
            }
        }

        private bool IsLeapYear(int year) {
            // Kiểm tra năm nhuận
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        private void btnYear_Click(object sender, EventArgs e) {
            // Lấy giá trị từ TextBox (giả sử bạn có một TextBox tên là txtYear)
            string input = txtYear.Text;

            // Kiểm tra xem đầu vào có phải là số nguyên hay không
            if(int.TryParse(input, out int year)) {
                // Kiểm tra năm hợp lệ, ví dụ: năm từ 1900 đến năm hiện tại
                int currentYear = DateTime.Now.Year;
                if(year <= currentYear) {
                    panel2.Controls.Clear(); // Xóa các điều khiển cũ (nếu cần)
                    // Khởi tạo và thêm UCRevenueYearly
                    UCRevenueYearly ucRevenueYearly = new UCRevenueYearly(year);
                    ucRevenueYearly.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian có sẵn

                    // Giả sử bạn có một Panel tên là panelContainer để chứa các điều khiển

                    panel2.Controls.Add(ucRevenueYearly); // Thêm User Control vào Panel
                } else {
                    MessageBox.Show("Năm không hợp lệ. Vui lòng nhập vào năm không được lớn hơn năm hiện tại " + currentYear + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYear.Clear(); // Xóa giá trị trong TextBox
                }
            } else {
                MessageBox.Show("Đầu vào không hợp lệ. Vui lòng nhập một năm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Clear(); // Xóa giá trị trong TextBox
            }
        }

        private void btnXemChiTietDoanhThu_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection connection = Connection.GetConnection())
                {
                    connection.Open();

                    string query = "sp_AdvancedRevenueAnalysis"; // Tên của thủ tục lưu trữ

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@endDate", dateTimePicker2.Value);

                        // Sử dụng SqlDataAdapter để đổ dữ liệu vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Đặt DataTable làm nguồn dữ liệu cho dataGridView1
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
