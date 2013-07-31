using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Tools
{
    public partial class FrmRenameImage : Form
    {
        
        public FrmRenameImage()
        {
            InitializeComponent();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            DirectoryInfo dir = new DirectoryInfo(tbxOrginal.Text);
            
            foreach (string s in tbxConfig.Lines)
            {
                
                string[] arr = s.Split(new string[]{"---"} ,  StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length != 2)
                {
                    throw new Exception("格式有误:"+s);
                }
                string old = arr[0];
                FileInfo[] files= dir.GetFiles(old+"*",  SearchOption.AllDirectories);
                if (files.Length >= 1)
                {
                    if (files.Length > 1)
                    {
                        msg += "有" + files.Length + "个文件名称相同:" + old + ",取第一个文件"+Environment.NewLine;
                    }
                    FileInfo fi = files[0];
                    string newFileName = arr[1];
                    fi.CopyTo(tbxTarget.Text + "\\" + newFileName);
                }
                else
                {
                    msg += "没有对应的文件:" + old + Environment.NewLine;
                }
            }
            tbxMsg.Text = msg;
        }
    }
}
