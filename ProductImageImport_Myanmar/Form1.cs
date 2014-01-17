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

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            
            DirectoryInfo dirInfo = new DirectoryInfo(textBox1.Text);
          DataSet ds=  DataAccess.CommonSQL.ExcuteDataset("select jdrawingnumber from tgoods where jphoto is null");
            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string ntscode_drawingnumber=row["jdrawingnumber"].ToString();
                    if (Path.GetFileNameWithoutExtension(fileInfo.Name).Contains(ntscode_drawingnumber))
                    {
                        string sql = string.Format(@"update tgoods set jphoto=(select BulkColumn from Openrowset(Bulk '{0}',Single_Blob) as jphoto )
where jdrawingnumber='{1}'",fileInfo.FullName,ntscode_drawingnumber);
                        DataAccess.CommonSQL.ExcuteNoneQuery(sql);
                    }
                }
            }
            MessageBox.Show("complete");
        }
    }
}
