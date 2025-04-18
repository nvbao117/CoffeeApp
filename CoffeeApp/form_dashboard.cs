﻿using BLL.BusinessComponents;
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
    public partial class form_dashboard : UserControl
    {
        private readonly TableService _tableService; 
        private readonly EmployeeService _employeeService;
        private readonly BillService _billService;
        public form_dashboard()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _tableService = new TableService();
            _billService = new BillService();
        }

        private void form_dashboard_Load(object sender, EventArgs e)
        {
            
        }
        public void LoadDashboardData()
        {
            lblTable.Text = _tableService.getCountTableAvailable().ToString();
            lblCountStaff.Text = _employeeService.getCountEmployee().ToString();
            lblTodayRevenue.Text = _billService.getTodayRevenue().ToString();
            lblTotalRevenue.Text = _billService.getMonthRevenue().ToString();
        }
    }
}
