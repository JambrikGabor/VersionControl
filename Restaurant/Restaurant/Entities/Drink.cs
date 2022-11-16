
using Restaurant.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Drink : Product
    {
        protected override void Display()
        {
            
            BackColor = Color.LightBlue;
        }
    }
}
