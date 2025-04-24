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
using System.Windows.Documents;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Order_drink_control : UserControl
    {
        private readonly CategoryService _category;
        private readonly FoodService _foodService;
        private readonly BillService _billService; 

        private TableFoodDTO currentTable;
        private List<FoodDTO> menuFoods;
        private List<OrderItem> currentOrder;
        private int selectedCategory = 0;


        public Order_drink_control(TableFoodDTO table)
        {
            InitializeComponent();
            currentTable = table;
            _category = new CategoryService();
            _foodService = new FoodService();
            _billService = new BillService();
            currentOrder = new List<OrderItem>();
            
            LoadForm();
            CategoryLoad();
        }

        public void LoadForm()
        {
            lblTitle.Text = "Order for table " + currentTable.Id;
            menuFoods = _foodService.Foods();
            UpdateMenuItems();
        }
        private void CategoryLoad()
        {
            List<FoodCategoryDTO> categories = _category.GetAll();
            AddCategoryButton("All", 0);
            foreach (var category in categories)
            {
                AddCategoryButton(category.Name, category.Id);
            }
        }
        
        private void AddCategoryButton(string name ,int id)
        {
            var btn = new Button
            {
                Text = name,
                Tag = id,
                Size = new Size(100, 30),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand,
                Margin = new Padding(5),
                BackColor = id == 0 ? Color.FromArgb(216, 172, 124) : Color.FromArgb(255, 235, 205),
                ForeColor = id == 0 ? Color.White : Color.FromArgb(121, 85, 72)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Paint += (s, e) => {
                Button btna = (Button)s;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 8;
                    Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);

                    path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(bounds.Right - radius * 2, bounds.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(bounds.X, bounds.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);

                    path.CloseFigure();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    btn.Region = new Region(path);
                }
            };
            btn.Click += (s, e) =>
            {
                selectedCategory = (int)((Button)s).Tag;
                UpdateMenuItems();
            };
            fllCategory.Controls.Add(btn);
        }

        private void UpdateMenuItems()
        {
            fllmenuItems.Controls.Clear();

            var filteredItems = selectedCategory == 0 ? menuFoods : menuFoods.Where(f => f.FoodCategoryId == selectedCategory).ToList();

            foreach(var item in filteredItems)
            {
                fllmenuItems.Controls.Add(CreateMenuItemCard(item));
            }
            fllmenuItems.VerticalScroll.Value = 0;
            fllmenuItems.PerformLayout(); 
        }

        private Panel CreateMenuItemCard(FoodDTO food)
        {
            Panel card = new Panel
            {
                Size = new Size(320, 70),
                BackColor = Color.White,
                Margin = new Padding(5),
                Tag = food
            };

            card.Paint += (s, e) => DrawRoundedBorder(card, e);
            card.Controls.Add(new Label
            {
                Text = food.Name,
                Font = new Font("Segoe UI Semibold", 11),
                Location = new Point(80,15),
                AutoSize = true,
                ForeColor = Color.FromArgb(121, 85, 72)
            });
            card.Controls.Add(new Label
            {
                Text = $"${food.Price}",
                Font = new Font("Segoe UI", 11),
                Location = new Point(80, 40),
                AutoSize = true,
                ForeColor = Color.FromArgb(121, 85, 72)
            });

            var addButton = new Button
            {
                Text = "+",
                Size = new Size(30, 30),
                Location = new Point(card.Width - 45, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 248, 225),
                ForeColor = Color.FromArgb(216, 172, 124),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            addButton.Paint += (s,e) => DrawCircle(addButton, e);
            addButton.Click += (s,e) => AddToOrder(food);

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(15, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            if (food.Image != null)
            {
                pictureBox.Image = Image.FromFile(food.Image);
            }

            card.Controls.Add(pictureBox);
            card.Controls.Add(addButton);
            return card;
        }
        private void AddToOrder(FoodDTO food)
        {
            var existing = currentOrder.FirstOrDefault(x => x.Food.Id == food.Id);
            if(existing != null)
            {
                existing.Quantity++;
                existing.Subtotal = (int)(existing.Food.Price * existing.Quantity);
            }
            else
            {
                currentOrder.Add(new OrderItem
                {
                    Food = food,
                    Quantity = 1,
                    Subtotal = (int)food.Price
                });
            }
            UpdateOrderSummary();
            emptyOrderPanel.Visible = false;
            orderItemsPanel.Visible = true;
        }
        private void UpdateOrderSummary()
        {
            emptyOrderPanel.Visible = currentOrder.Count == 0;
            orderItemsPanel.Visible = currentOrder.Count > 0;

            if (currentOrder.Count > 0)
            {
                // Clear existing items
                orderItemsPanel.Controls.Clear();

                // Add order items
                int yPos = 10;
                decimal total = 0;

                foreach (var orderItem in currentOrder)
                {
                    Panel itemPanel = CreateOrderItemPanel(orderItem, yPos);
                    orderItemsPanel.Controls.Add(itemPanel);
                    yPos += 70;

                    total += orderItem.Subtotal;
                }

                totalLabel.Text = $"🛒 Review Order (${total:F2})";
            }
            else
            {
                totalLabel.Text = "🛒 Review Order ($0.00)";
            }
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

            Button decreaseButton = new Button
            {
                Text = "-",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(121, 85, 72),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(25, 25),
                Location = new Point(10, 30),
                Cursor = Cursors.Hand
            };
            decreaseButton.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 230);

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

            decreaseButton.Click += (s, e) => {
                if (orderItem.Quantity > 1)
                {
                    orderItem.Quantity--;
                    orderItem.Subtotal = (int)(orderItem.Food.Price * orderItem.Quantity);
                    quantityLabel.Text = orderItem.Quantity.ToString();
                    subtotalLabel.Text = $"${orderItem.Subtotal:F2}";
                    UpdateOrderSummary();
                }
                else
                {
                    currentOrder.Remove(orderItem);
                    UpdateOrderSummary();
                }
            };
            panel.Controls.Add(decreaseButton);


            Button increaseButton = new Button
            {
                Text = "+",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(121, 85, 72),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(25, 25),
                Location = new Point(60, 30),
                Cursor = Cursors.Hand
            };
            increaseButton.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 230);

            increaseButton.Click += (s, e) => {
                orderItem.Quantity++;
                orderItem.Subtotal = (int)(orderItem.Food.Price * orderItem.Quantity);
                quantityLabel.Text = orderItem.Quantity.ToString();
                subtotalLabel.Text = $"${orderItem.Subtotal:F2}";
                UpdateOrderSummary();
            };
            panel.Controls.Add(increaseButton);

            Button deleteButton = new Button
            {
                Text = "×",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 100, 100),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(25, 25),
                Location = new Point(panel.Width - 30, 5),
                Cursor = Cursors.Hand
            };
            deleteButton.FlatAppearance.BorderSize = 0;


            deleteButton.Click += (s, e) => {
                currentOrder.Remove(orderItem);
                UpdateOrderSummary();
            };
            panel.Controls.Add(deleteButton);

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
        
        private void FilterMenuItems(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                UpdateMenuItems();
                return;
            }

            fllmenuItems.Controls.Clear();

            var filteredItems = menuFoods.Where(item =>
                item.Name.ToLower().Contains(searchText.ToLower()) &&
                (selectedCategory == 0 || item.FoodCategoryId == selectedCategory)).ToList();

            foreach (var item in filteredItems)
            {
                Panel itemCard = CreateMenuItemCard(item);
                fllmenuItems.Controls.Add(itemCard);
            }
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
        private void DrawCircle(Control control, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
                path.AddEllipse(bounds);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                control.Region = new Region(path);
            }
        }

        private void btnReviewOrder_Click(object sender, EventArgs e)
        {
            var reviewOrder = new ReviewOrder(currentOrder,currentTable.Id);
            reviewOrder.OnOrderPlaced = () =>
            {
                currentOrder.Clear();
                orderItemsPanel.Controls.Clear();
                UpdateOrderSummary();
            };
            reviewOrder.ShowDialog();
        }
    }
}
