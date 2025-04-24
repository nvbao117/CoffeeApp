using BLL.BusinessComponents;
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

namespace CoffeeApp
{
    public partial class ReviewOrder : Form
    {
        private List<OrderItem> orderItems;
        private BillService _billService;
        public Action OnOrderPlaced { get; set; }
        public int IdTable;
        private int total =0 ; 
        public ReviewOrder(List<OrderItem> orderItems, int idTable)
        {
            InitializeComponent();
            this.orderItems = orderItems;
            this.IdTable = idTable;
            _billService = new BillService();
            load();
            
        }

        private void load()
        {
            if (orderItems.Count() != 0)
            {
                pnlEmpty.Visible = false;
                lblTotal.Visible = true;
                panel1.Visible = true;
                foreach (OrderItem item in orderItems)
                {
                    if (item != null)
                    {
                        Panel orderItemPanel = CreateOrderItemPanel(item, fllOrder.Controls.Count * 60);
                        fllOrder.Controls.Add(orderItemPanel);
                        total += item.Subtotal;
                    }
                }
                lblTotal.Text = $"${total}";
                btnOrder.Enabled = true;
            }
            else
            {
                pnlEmpty.Visible = true;
                panel1.Visible = false;
                lblTotal.Visible = false;
                btnOrder.Enabled = false;
            }
            lblConfirmTable.Text = $"Confirm order details  for table : {IdTable}";
        }
        private Panel CreateOrderItemPanel(OrderItem orderItem, int yPosition)
        {
            Panel panel = new Panel
            {
                Size = new Size(380, 60),
                Location = new Point(20, yPosition),
                BackColor = Color.Transparent,
            };
            Label nameLabel = new Label
            {
                Text = orderItem.Food.Name,
                Font = new Font("Segoe UI Semibold", 11),
                ForeColor = Color.FromArgb(121, 85, 72),
                AutoSize = true,
                Location = new Point(10, 5)
            };
            panel.Controls.Add(nameLabel);

            Label quantityLabel = new Label
            {
                Text = orderItem.Quantity.ToString(),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(121, 85, 72),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(40, 32)
            };
            
            Label subtotalLabel = new Label
            {
                Text = $"${orderItem.Subtotal:F2}",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(121, 85, 72),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(panel.Width - 80, 30)
            };
            panel.Controls.Add(subtotalLabel);
            panel.Controls.Add(quantityLabel);

            Panel separator = new Panel
            {
                Size = new Size(panel.Width, 1),
                Location = new Point(0, panel.Height - 1),
                BackColor = Color.FromArgb(240, 240, 240)
            };
            panel.Controls.Add(separator);
            panel.Paint += (s, e) => DrawRoundedBorder(panel, e); 
            return panel;
        }
        
        
        private void DrawRoundedBorder(Control control, PaintEventArgs e, int radius = 10, Color? borderColor = null)
        {
            using (var path = new GraphicsPath())
            {
                Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);

                int diameter = radius * 2;

                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                control.Region = new Region(path);

                using (Pen borderPen = new Pen(borderColor ?? Color.LightGray, 4f))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            _billService.createBill(IdTable,orderItems);
            MessageBox.Show("Order successfully");
            fllOrder.Controls.Clear();
            orderItems.Clear(); 
            OnOrderPlaced?.Invoke(); 
            
        }
    }
}
