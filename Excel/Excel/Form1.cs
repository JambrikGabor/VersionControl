using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel2 = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Excel
{
    
    public partial class Form1 : Form
    {
        RealEstateEntities1 context = new RealEstateEntities1();
        List<Flat> Flats;
        Excel2.Application xlApp;
        Excel2.Workbook xlWB;
        Excel2.Worksheet xlSheet;


        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();       
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel2.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                //CreateTable();
                xlApp.Visible = true;
                xlWB.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;


            }
            
        }

        
    }
}
