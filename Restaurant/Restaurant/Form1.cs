using Restaurant.Abstractions;
using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Restaurant
{
    public partial class Form1 : Form
    {
        List<Product> _products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            LoadXML();
            ShowProducts();

        }

        private void ShowProducts()
        {
            //_products = (from x in _products orderby x.Title select x).ToList();
            _products = _products.OrderBy(x => x.Title).ToList();

            for (int i = 0; i < _products.Count; i++)
            {
                _products[i].Location = new Point(5, 50 * i + 10);
                this.Controls.Add(_products[i]);
            }
        }

        private void LoadXML()
        {
            var xml = new XmlDocument();
            string prePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string path = Path.Combine(prePath, "Menu.xml");
            xml.LoadXml(XMLFunction(path));

            XmlNodeList nl = xml.DocumentElement.ChildNodes;
            foreach (XmlElement node in nl)
            {
                string type = node.SelectSingleNode("type").InnerText;
                string name = node.SelectSingleNode("name").InnerText;
                string description = node.SelectSingleNode("description").InnerText;
                string calories = node.SelectSingleNode("calories").InnerText;
                
                if (type == "food")
                {
                    Food f = new Food();
                    f.Title = name;
                    f.Calories = int.Parse(calories);
                    f.Description = description;

                    _products.Add(f);
                }
                else
                {
                    Drink d = new Drink();
                    d.Title = name;
                    d.Calories = int.Parse(calories);

                    _products.Add(d);
                }

            }
        }

        private string XMLFunction(string filename)
        {
            using (var sr = new StreamReader(filename,Encoding.Default))
            {
                var xml = sr.ReadToEnd();
                return xml;
            }
            
            
        }
    }
}
