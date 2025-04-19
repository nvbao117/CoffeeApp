using BLL.BusinessComponents;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoffeeApp
{
    public partial class overviewdashboard : UserControl
    {
        private readonly BillService _billService;
        public overviewdashboard()
        {
            InitializeComponent();
            if (!IsInDesignMode())
            {
                _billService = new BillService();
            }
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            var weekly = _billService.GetWeeklyRevenueOfCurrentYear();
            LoadWeeklyRevenueChart(weekly);
        }
        private void LoadRevenueChart(List<MonthlyRevenueDTO> data)
        {
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();
            chartRevenue.ChartAreas.Add(new ChartArea("MainArea"));

            var series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            foreach (var item in data)
            {
                series.Points.AddXY($"T{item.Month}", item.Revenue / 1000);
            }

            chartRevenue.Series.Add(series);

            // Tùy chỉnh thêm nếu muốn
            chartRevenue.ChartAreas[0].AxisX.Title = "Tháng";
            chartRevenue.ChartAreas[0].AxisY.Title = "Doanh thu";
            chartRevenue.Series[0].IsValueShownAsLabel = false;
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Invalidate();
        }
        private void LoadWeeklyRevenueChart(List<WeeklyRevenueDTO> data)
        {
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();
            chartRevenue.ChartAreas.Add(new ChartArea("MainArea"));

            var series = new Series("revenue week");
            series.ChartType = SeriesChartType.Column;

            foreach (var item in data)
            {
                series.Points.AddXY($"Tuần {item.Week}", item.Revenue / 1000);
            }

            chartRevenue.Series.Add(series);
            chartRevenue.ChartAreas[0].AxisX.Title = "Tuần";
            chartRevenue.ChartAreas[0].AxisY.Title = "Doanh thu";
            chartRevenue.Series[0].IsValueShownAsLabel = false;
            chartRevenue.Dock = DockStyle.Fill;
            chartRevenue.Invalidate();

        }
        private bool IsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || DesignMode;
        }
        private void btnMonthly_Click_1(object sender, EventArgs e)
        {
            var revenueData = _billService.GetMonthlyRevenueOfCurrentYear();

            LoadRevenueChart(revenueData);
        }
    }
}
