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
    public partial class Admin_form : UserControl
    {
        public event Action<UserControl> LoadContentRequested;
        public Admin_form()
        {
            InitializeComponent();
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            LoadContentRequested?.Invoke(new Account_form());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            LoadContentRequested?.Invoke(new Table_form());
        }

        private void btnFood_Click(object sender, EventArgs e)
        {

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            LoadContentRequested?.Invoke(new Category_form());
        }
    }
}
