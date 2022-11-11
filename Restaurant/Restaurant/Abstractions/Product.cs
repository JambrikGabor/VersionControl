using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Enitities
{
    public abstract class Product : Button
    {
        public Product()
        {
            Width = 150;
            Height = 50;
        }
        public string _foodname;
        public string Title 
        { 
            get { return _foodname; } 
            set 
            {
                _foodname = value;
                Text = Title; } 
        }
        private int calorynumber;
        public int Calories 
        {
            get 
            {
                return calorynumber;
            } 
            set 
            {
                calorynumber = value;
                Display();
            } 
        }
        protected abstract void Display();
    }
}
