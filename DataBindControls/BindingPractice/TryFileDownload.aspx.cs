using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryFileDownload : System.Web.UI.Page
    {
        private int _filePoint = 10;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            int userPoint = Convert.ToInt32(this.txtScore.Text);

            if ((userPoint - _filePoint) < 0)   // 計算積分是否充足，以下載檔案
            {
                this.ltlMsg.Text = "分數不足";
                return;
            }

            string filePathFromDB = "FileDownload\\AAA.docx";
            string relativePath = "~/" + filePathFromDB;

            string fullPath = Server.MapPath(relativePath);
            this.FileDownload(fullPath);
        }

        // Path: C:\aaa\xxxx.docx
        private void FileDownload(string path)
        {
            byte[] sourceBytes = File.ReadAllBytes(path);
            string newFileName = 
                $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{Path.GetExtension(path)}";

            this.Response.ContentType = "application/download";
            this.Response.AddHeader(
                "Content-Disposition", 
                $"attachment; filename={newFileName}");

            this.Response.Clear();
            this.Response.BinaryWrite(sourceBytes);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}