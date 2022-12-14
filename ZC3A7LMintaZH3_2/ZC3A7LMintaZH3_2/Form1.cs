using PackMaker;
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
using ZC3A7LMintaZH3_2.Entities;
using ZC3A7LMintaZH3_2.Enum;

namespace ZC3A7LMintaZH3_2
{
    public partial class Form1 : Form
    {
        BindingList<Child> children = new BindingList<Child>();
        SantaClausPack santaPack = new SantaClausPack();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = children;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var c = new Child();
            int userChildBehaviour = int.Parse(textBoxBehaviour.Text);
            if (c.CheckBehaviour(userChildBehaviour) == false)
            {
                MessageBox.Show("Nem megfelelő érték!");
                return;
            }
            c.Gifts=santaPack.GetGifts(userChildBehaviour);
            c.Name = textBoxName.Text;
            c.ChildBehaviour = (Behaviour)(userChildBehaviour);
            children.Add(c);
            int badChildren = (from x in children
                               where x.ChildBehaviour == Behaviour.Worst || x.ChildBehaviour == Behaviour.Bad
                               select x).Count();
            label3.Text = string.Format("Rosszak száma: {0}", badChildren);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default))
            {
                sw.WriteLine("Név;Ajándékok");
                foreach (var c in children)
                {
                    sw.Write(c.Name);
                    sw.Write(';');
                    //sw.Write(c.ChildBehaviour.ToString());
                    foreach (var g in c.Gifts)
                    {
                        sw.Write(g.Name + " ");
                    }
                    sw.WriteLine();
                    
                };
            }
            
        }
    }
}
