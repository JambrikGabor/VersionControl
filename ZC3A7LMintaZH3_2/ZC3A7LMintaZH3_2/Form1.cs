using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZC3A7LMintaZH3_2.Entities2;

namespace ZC3A7LMintaZH3_2
{
    public partial class Form1 : Form
    {
        BindingList<Child> children = new BindingList<Child>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = children;
        }
    }
}
