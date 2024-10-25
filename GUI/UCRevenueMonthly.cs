using HotelManagementSystem.DAO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Windows.Forms;



namespace HotelManagementSystem.GUI {
    public partial class UCRevenueMonthly : UserControl
    {
        private PlotView plotView;
        RevenueMonthlyDAO revenueDAO = new RevenueMonthlyDAO();
        public UCRevenueMonthly()
        {
            InitializeComponent();
        }

        public UCRevenueMonthly(int month, int year)
        {
            CreatePlot(month, year);
            InitializeComponent();
        }
        private void CreatePlot(int month, int year)
        {
            plotView = new PlotView();
            plotView.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(plotView);

            var model = new PlotModel { Title = $"Doanh thu cho tháng {month}" };

            // Lấy dữ liệu từ hàm
            var revenueData = revenueDAO. GetRevenueDataMonth(month, year);

            if (revenueData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho tháng này.");
            }

            // Tạo series
            var series = new LineSeries
            {
                Title = "Doanh thu",
                MarkerType = MarkerType.Circle
            };

            // Thêm điểm dữ liệu vào series
            foreach (var dataPoint in revenueData)
            {

                series.Points.Add(new DataPoint(dataPoint.Day, dataPoint.TotalRevenue)); // Sử dụng Day cho trục X
            }

            model.Series.Add(series);
            plotView.Model = model;

            // Thiết lập trục X để hiển thị theo ngày
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Ngày", Minimum = 1, Maximum = 31 });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Doanh thu" });
        }

        private void UCRevenueMonthly_Load(object sender, EventArgs e)
        {

        }
       
    }
}
