using BLL.BusinessComponents;
using BLL.BusinessEntities;
using CoffeeApp.Customize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class ProductDashboard : UserControl
    {
        private readonly FoodService _foodService; 
        public ProductDashboard()
        {
            
            InitializeComponent();
            _foodService = new FoodService();
        }

        private void ProductDashboard_Load(object sender, EventArgs e)
        {
            LoadFood();
        }
        private void LoadFood()
        {
            List<FoodDTO> foods = _foodService.Foods();
            foreach(FoodDTO food in foods)
            {
                var card = new ProductCard(food);
                card.GetCategoryName = id => $"{id}";
                card.FoodClicked += (s, args) => MessageBox.Show($"Bạn đã chọn: {card.Food.Name}");
                card.FoodDoubleClicked += (s, args) => MessageBox.Show("Double clicked!");
                flowLayoutPanel1.Controls.Add(card);
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
