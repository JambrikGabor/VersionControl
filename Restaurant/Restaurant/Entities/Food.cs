
using Restaurant.Abstractions;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
