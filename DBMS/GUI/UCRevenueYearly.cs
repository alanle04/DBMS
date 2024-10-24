using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using HotelManagementSystem.DAO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace HotelManagementSystem.GUI
{
    public partial class UCRevenueYearly : UserControl
    {
        private PlotView plotView;
        private PlotModel model;
        RevenueYearly re = new RevenueYearly();
        public UCRevenueYearly()
        {
            InitializeComponent();
        }

        public UCRevenueYearly(int year)
        {
            CreatePlot(year);
            InitializeComponent();
           
        }

        private void CreatePlot(int year)
        {
            model = new PlotModel { Title = $"Doanh thu năm {year}" };
            plotView = new PlotView { Dock = DockStyle.Fill };
            this.Controls.Clear();
            this.Controls.Add(plotView);

            // Lấy dữ liệu doanh thu từ hàm
            var revenueData = re.GetRevenueData(year);

            if (revenueData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cho năm này.");
                
            }

            // Tạo series cho biểu đồ
            var series = new LineSeries // Sử dụng LineSeries để vẽ biểu đồ đường
            {
                Title = "Doanh thu",
                MarkerType = MarkerType.Circle // Thêm marker cho các điểm
            };

            // Thêm dữ liệu vào series
            foreach (var dataPoint in revenueData)
            {
                // Sử dụng Month cho trục X, và TotalRevenue cho trục Y
                series.Points.Add(new DataPoint(dataPoint.Month, (double)dataPoint.TotalRevenue));
            }

            model.Series.Add(series);

            // Thiết lập trục X và Y
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Tháng",
                Minimum = 1,
                Maximum = 12
            });

            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Tổng doanh thu",
                Minimum = 0
            });

            plotView.Model = model; // Gán mô hình cho plotView
        }

      

        private void UCRevenueYearly_Load(object sender, EventArgs e)
        {
            // Có thể thêm mã khởi tạo nếu cần
        }
    }
}
