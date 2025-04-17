using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeApp
{
    public class UIHelper
    {
        private bool isDragging = false;
        private Point dragOffset;
        private Form targetForm;


        public UIHelper(Form form)
        {
            targetForm = form;
        }

        public void EnableDragging(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;
                control.MouseUp += Control_MouseUp;
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragOffset = e.Location;
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = targetForm.PointToScreen(new Point(e.X, e.Y));
                newLocation.Offset(-dragOffset.X, -dragOffset.Y);
                targetForm.Location = newLocation;
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
