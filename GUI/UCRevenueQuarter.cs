using HotelManagementSystem.DAO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem.GUI {
    public partial class UCRevenueQuarter : UserControl {
        private PlotView plotView;


        RevenueQuarterlyDAO revenueQuarterlyDAO = new RevenueQuarterlyDAO();
        public UCRevenueQuarter() {
            InitializeComponent();
        }
        public UCRevenueQuarter(int quarter, int year) {
            CreatePlot(quarter, year);
            InitializeComponent();


        }

        private void CreatePlot(int quarter, int year) {
            // Khởi tạo mô hình PlotModel
            var model = new PlotModel { Title = $"Doanh thu Quý {quarter} Năm {year}" };

            plotView = new PlotView();
            plotView.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(plotView);

            // Lấy dữ liệu từ hàm theo quý
            var revenueData = revenueQuarterlyDAO.GetRevenueData(quarter, year);

            if(revenueData.Count == 0) {
                MessageBox.Show("Không có dữ liệu cho quý này.");

            }

            // Tạo series
            var series = new LineSeries {
                Title = "Doanh thu",
                MarkerType = MarkerType.Circle
            };

            // Thêm điểm dữ liệu vào series
            foreach(var dataPoint in revenueData) {
                series.Points.Add(new DataPoint(dataPoint.Month, dataPoint.TotalRevenue)); // Sử dụng Month cho trục X
            }

            model.Series.Add(series);
            plotView.Model = model;

            // Thiết lập trục X để hiển thị theo tháng
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Tháng", Minimum = 1, Maximum = 12 });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Doanh thu" });
        }



        private void UCRevenueQuarter_Load(object sender, EventArgs e) {

        }
    }
}
