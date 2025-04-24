using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.BusinessEntities;
using System.Drawing.Drawing2D;
using System.IO;
using Image = System.Drawing.Image; 
namespace CoffeeApp.Customize
{
    public class ProductCard :Panel
    {
        private FoodDTO _food;
        private Image _foodImage;
        private bool _hovered = false;
        private bool _selected = false;

        private readonly Font _nameFont;
        private readonly Font _categoryFont;
        private readonly Font _priceFont;
        private readonly Font _idFont;

        public Color BorderColor { get; set; } = Color.FromArgb(230, 230, 230);
        public Color SelectedBorderColor { get; set; } = Color.FromArgb(0, 123, 255);
        public Color HoverColor { get; set; } = Color.FromArgb(250, 250, 250);
        public Color CategoryBackgroundColor { get; set; } = Color.FromArgb(240, 240, 240);
        public Color CategoryTextColor { get; set; } = Color.FromArgb(102, 102, 102);

        public string ImageFolderPath { get; set; } = "Images";

        public Func<int, string> GetCategoryName { get; set; }

        public event EventHandler FoodClicked;
        public event EventHandler FoodDoubleClicked;

        public FoodDTO Food
        {
            get => _food; 
            set
            {
                _food = value;
                Console.WriteLine($"Food được gán: Id={_food?.Id}, Image={_food?.Image}");
                LoadFoodImage();
                Invalidate(); 
            }
        }
        public bool IsSelected
        {
            get => _selected;
            set
            {
                _selected = value;
                Invalidate();
            }
        }

        public ProductCard(FoodDTO food = null)
        {
            _food = food;
            this.BackColor = Color.White;
            this.Size = new Size(200, 250);
            this.Padding = new Padding(8);
            this.Cursor = Cursors.Hand;
            this.Margin = new Padding(9);

            _nameFont = new Font("Segoe UI",11,FontStyle.Bold);
            _categoryFont = new Font("Segoe UI", 8);
            _priceFont = new Font("Segoe UI",12,FontStyle.Bold);
            _idFont = new Font("Segoe UI", 7);

            this.Paint += ProductCard_Paint;
            this.MouseEnter += ProductCard_MouseEnter;
            this.MouseLeave += ProductCard_MouseLeave;
            this.Click += ProductCard_Click;
            this.DoubleClick += ProductCard_DoubleClick;
            LoadFoodImage(); // Gọi để tải ảnh ngay khi khởi tạo
            Invalidate(); // Đảm bảo vẽ lại
        } 

        private void ProductCard_MouseEnter(object sender, EventArgs e)
        {
            _hovered = true;
            Invalidate();
        }
        private void ProductCard_MouseLeave(object sender, EventArgs e)
        {
            _hovered = false;
            Invalidate();
        }
        
        private void ProductCard_Click(object sender, EventArgs e)
        {
            FoodClicked?.Invoke(this, e);
        }
        private void ProductCard_DoubleClick(object sender, EventArgs e)
        {
            FoodDoubleClicked?.Invoke(this, e);
        }

        private void ProductCard_Paint(object sender, PaintEventArgs e)
        {
            if (_food == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Calculate dimensions
            int cardWidth = this.Width;
            int cardHeight = this.Height;
            int padding = 10;

            // Background
            if (_hovered)
            {
                g.FillRectangle(new SolidBrush(HoverColor), 0, 0, cardWidth, cardHeight);
            }

            // Border
            Color border = _selected ? SelectedBorderColor : BorderColor;
            int borderWidth = _selected ? 2 : 1;
            using (Pen borderPen = new Pen(border, borderWidth))
            {
                g.DrawRectangle(borderPen, borderWidth / 2, borderWidth / 2,
                    cardWidth - borderWidth, cardHeight - borderWidth);
            }

            // Food image
            Rectangle imageRect = new Rectangle(padding, padding, cardWidth - (padding * 2), 120);
            if (_foodImage != null)
            {
                // Draw actual image with proper scaling
                g.DrawImage(_foodImage, imageRect);
            }
            else
            {
                // Image placeholder
                g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), imageRect);

                // Food icon placeholder
                int iconSize = 40;
                int iconX = imageRect.X + (imageRect.Width - iconSize) / 2;
                int iconY = imageRect.Y + (imageRect.Height - iconSize) / 2;

                using (Font iconFont = new Font("Segoe UI Symbol", 24))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString("🍽️", iconFont, Brushes.Gray, new Rectangle(iconX, iconY, iconSize, iconSize), sf);
                }
            }

            // ID in small text at top-right corner
            string idText = $"#{_food.Id}";
            SizeF idSize = g.MeasureString(idText, _idFont);
            g.DrawString(idText, _idFont, new SolidBrush(Color.FromArgb(150, 150, 150)),
                cardWidth - padding - idSize.Width, padding);

            // Food name
            SizeF nameSize = g.MeasureString(_food.Name, _nameFont);
            // Ensure name fits or truncate with ellipsis
            using (StringFormat nameFormat = new StringFormat { Trimming = StringTrimming.EllipsisCharacter })
            {
                RectangleF nameRect = new RectangleF(padding, imageRect.Bottom + 10,
                    cardWidth - (padding * 2), nameSize.Height);
                g.DrawString(_food.Name, _nameFont, new SolidBrush(Color.FromArgb(51, 51, 51)),
                    nameRect, nameFormat);
            }

            // Category tag (if GetCategoryName is provided)
            string categoryName = GetCategoryName?.Invoke(_food.FoodCategoryId) ?? $"Category #{_food.FoodCategoryId}";
            SizeF tagSize = g.MeasureString(categoryName, _categoryFont);
            RectangleF tagRect = new RectangleF(padding, imageRect.Bottom + 40, tagSize.Width + 16, 24);

            using (GraphicsPath path = RoundedRectangle(tagRect, 12))
            {
                g.FillPath(new SolidBrush(CategoryBackgroundColor), path);
                g.DrawString(categoryName, _categoryFont, new SolidBrush(CategoryTextColor),
                    tagRect.X + 8, tagRect.Y + (tagRect.Height - tagSize.Height) / 2);
            }

            // Price
            string priceText = $"{_food.Price:#,##0} đ";
            g.DrawString(priceText, _priceFont, new SolidBrush(Color.FromArgb(51, 51, 51)),
                padding, tagRect.Bottom + 10);
        }

        private GraphicsPath RoundedRectangle(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.X + rect.Width - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.X + rect.Width - (radius * 2), rect.Y + rect.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
        public void LoadFoodImage()
        {
            Console.WriteLine("Bắt đầu LoadFoodImage");
            _foodImage?.Dispose();
            _foodImage = null;

            if (_food == null || string.IsNullOrEmpty(_food.Image))
            {
                Console.WriteLine("Food hoặc Image là null/rỗng");
                _foodImage = CoffeeApp.Properties.Resources.placeholder_product;
                Invalidate();
                return;
            }

            Console.WriteLine($"Food.Image: {_food.Image}");
            try
            {
                // 1. Đường dẫn tuyệt đối
                if (File.Exists(_food.Image))
                {
                    Console.WriteLine($"Tải đường dẫn tuyệt đối: {_food.Image}");
                    _foodImage = new Bitmap(Image.FromFile(_food.Image));
                    return;
                }

                // 2. Đường dẫn tương đối
                string relPath = Path.Combine(Application.StartupPath, "Resources", "imgProduct", _food.Image);
                Console.WriteLine($"Thử đường dẫn tương đối: {relPath}");
                if (File.Exists(relPath))
                {
                    _foodImage = new Bitmap(Image.FromFile(relPath));
                    return;
                }

                // 3. Thử các đuôi mở rộng khác
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(_food.Image);
                string basePath = Path.Combine(Application.StartupPath, "Resources", "imgProduct", fileNameWithoutExt);
                foreach (string ext in new[] { ".jpg", ".png", ".jpeg" })
                {
                    string pathWithExt = basePath + ext; // Sửa ở đây: dùng basePath thay vì relPath
                    Console.WriteLine($"Thử với đuôi mở rộng: {pathWithExt}");
                    if (File.Exists(pathWithExt))
                    {
                        _foodImage = new Bitmap(Image.FromFile(pathWithExt));
                        return;
                    }
                }

                // 4. Sử dụng ImageHelper để tải ảnh mặc định
                Console.WriteLine("Tất cả đường dẫn thất bại, sử dụng ImageHelper");
                _foodImage = ImageHelper.LoadProductImage("no-image.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tải ảnh: {ex.Message}");
                _foodImage = CoffeeApp.Properties.Resources.placeholder_product;
            }

            Console.WriteLine($"LoadFoodImage hoàn tất. Ảnh {(_foodImage == null ? "không" : "đã")} được tải.");
            Invalidate();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _nameFont?.Dispose();
                _categoryFont?.Dispose();
                _priceFont?.Dispose();
                _idFont?.Dispose();
                _foodImage?.Dispose(); 
            }
            base.Dispose(disposing);
        }
    }
}
