using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.BusinessComponents; 
namespace CoffeeApp
{
    public partial class Order_form : UserControl
    {
        private readonly TableService _tableService;
        private TableFoodDTO selectedTable;
        public Order_form()
        {
            InitializeComponent();
            _tableService = new TableService();
            LoadTable();
        }

        public void LoadTable()
        {
            List<TableFoodDTO> tables = _tableService.GetAllTable();
            foreach (var table in tables)
            {
                Panel tableCard = CreateTableCard(table);
                fllTables.Controls.Add(tableCard);
            }
        }
        private Panel CreateTableCard(TableFoodDTO table)
        {
            Color bgColor = table.Status == "Trống" ? Color.FromArgb(232, 245, 233) : Color.FromArgb(255, 248, 225);
            Panel card = new Panel
            {
                Size = new Size(125, 100),
                Margin = new Padding(5),
                BackColor = bgColor,
                Tag = table,
            };
            card.Paint += (s, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10;
                    Rectangle bounds = new Rectangle(0, 0, card.Width, card.Height);

                    path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(bounds.Right - radius * 2, bounds.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(bounds.X, bounds.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);

                    path.CloseFigure();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    card.Region = new Region(path);

                    // Draw border
                    using (Pen borderPen = new Pen(Color.FromArgb(230, 230, 230), 1))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
            };
            Label numberLabel = new Label
            {
                Text = $"Table {table.Id}",
                Font = new Font("Segoe UI Semibold", 12),
                ForeColor = Color.FromArgb(121, 85, 72),
                AutoSize = true,
                Location = new Point(15, 15)
            };
            card.Controls.Add(numberLabel);

            Label statusLabel = new Label
            {
                Text = table.Status.ToString(),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(121, 85, 72),
                AutoSize = true,
                Location = new Point(15, 40)
            };
            card.Controls.Add(statusLabel);

            Label capacityLabel = new Label
            {
                Text = $"👤 2",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(121, 85, 72),
                AutoSize = true,
                Location = new Point(15, 65)
            };
            card.Controls.Add(capacityLabel);

            card.Click += (s, e) =>
            {
                selectedTable = table;
                var orderControl = new Order_drink_control(selectedTable)
                {
                    Dock = DockStyle.Fill
                };
                mainPanelOrder.Controls.Clear();
                mainPanelOrder.Controls.Add(orderControl);

                foreach (Control control in fllTables.Controls)
                {
                    if (control is Panel tablePanel)
                    {
                        tablePanel.BorderStyle = BorderStyle.None;
                    }
                }
                card.BorderStyle = BorderStyle.FixedSingle;
            };
            return card;
        }
    }
}
