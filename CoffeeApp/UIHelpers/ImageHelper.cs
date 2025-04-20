using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public static class ImageHelper
{
    public static Image LoadProductImage(string imageName)
    {
        try
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "imgProduct", imageName);

            if (File.Exists(imagePath))
                return Image.FromFile(imagePath);
        }
        catch { }

        return CoffeeApp.Properties.Resources.placeholder_product;
    }
}
