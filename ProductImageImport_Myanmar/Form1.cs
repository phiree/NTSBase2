using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ProductImageImport_Myanmar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string foldPath = textBox1.Text;
            if (!Directory.Exists(foldPath))
            {
                MessageBox.Show("Invalid path,please have a check");
            }
            else
            {
                new BLL().BuildBulkInsert(foldPath);
                MessageBox.Show("Complete!");
            }
        }
    }
}
