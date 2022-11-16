
using Restaurant.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Entities
{
    class Food : Product
    {
        protected override void Display()
        {
            
            if (Calories<=750)
            {
                BackColor = Color.LightGreen;
            }
            else if (Calories<=1000)
            {
                BackColor = Color.LightYellow;
            }
            else
            {
                BackColor = Color.Salmon;
            }
            
            
        }
        public string Description { get; set; }

        public Food()
        {
            Click += Food_Click;
        }

        private void Food_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Title.ToString() + "" + Description.ToString());
        }
    }
}
