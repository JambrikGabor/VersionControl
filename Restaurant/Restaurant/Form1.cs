using Restaurant.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            

        }

        private void LoadXML()
        {
            var xml = new XmlDocument();
            xml.LoadXml(XMLFunction("Menu.xml"));
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
