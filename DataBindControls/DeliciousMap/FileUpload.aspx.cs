using DeliciousMap.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap
{
    public partial class FileUpload : System.Web.UI.Page
    {
        // 目前編到幾號
        private static int _fileNumber = 1;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string GetSavePath()
        {
            string folder = "~/FileDownload";
            //string folderPath = Server.MapPath(folder);
            string folderPath = System.Web.Hosting.HostingEnvironment.MapPath(folder);
            return folderPath;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.FileUpload[] fuArr = { this.FileUpload1, this.FileUpload2, this.FileUpload3, this.FileUpload4 };
            Label[] lblArr = { this.lblMsg, this.lblMsg2, this.lblMsg3, this.lblMsg4 };
            // 檢查檔案上傳是否正確
            bool isChecked = true;
            for (int i = 0; i < fuArr.Length; i++)
            {
                System.Web.UI.WebControls.FileUpload fu = fuArr[i];
                Label lbl = lblArr[i];

                List<string> msgList;
                if (!this.ValidFileUpload(fu, out msgList))
                {
                    lbl.Text = string.Join("<br/>", msgList);
                    isChecked = false;
                }
            }
            if (!isChecked) // 任何一筆檢查失敗，就停止
                return;
            for (var i = 0; i < fuArr.Length; i++)
            {
                System.Web.UI.WebControls.FileUpload fu = fuArr[i];

                string fileName = fu.FileName;
                string saveFolderPath = this.GetSavePath();
                string newFileName = GetNewFileName(fileName);
                string newFilePath = System.IO.Path.Combine(saveFolderPath, newFileName);
                fu.SaveAs(newFilePath);
            }
        }

        private string GetNewFileName(string fileName)
        {
            // 使用流水號
            //string newFileName = 
            //    _fileNumber.ToString("000000") +
            //    System.IO.Path.GetExtension(fileName);
            //_fileNumber += 1;

            //// 使用 guid 法
            //string newFileName =
            //    (Guid.NewGuid()).ToString() +
            //    System.IO.Path.GetExtension(fileName);

            System.Threading.Thread.Sleep(3);
            Random random = new Random((int)DateTime.Now.Ticks);

            // 使用當下時間法
            string newFileName =
                DateTime.Now.ToString("yyyyMMddHHmmssFFFFFF") + "_" +
                random.Next(10000).ToString("0000") +
                System.IO.Path.GetExtension(fileName);

            return newFileName;
        }

        /// <summary> 檢查檔案上傳是否正確 (容量 / 副檔名) </summary>
        /// <param name="fileUpload"></param>
        /// <param name="errorMsgList"></param>
        /// <returns></returns>
        private bool ValidFileUpload(System.Web.UI.WebControls.FileUpload fileUpload, out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // 檢查是否有上傳檔案
            if (!fileUpload.HasFile)
                msgList.Add("需上傳檔案");

            string fileName = fileUpload.FileName;
            // 檢查檔案副檔名是否符合規範
            if (!FileHelper.ValidImageExtension(fileName))
            {
                string fileExts = string.Join(", ", FileHelper.ImageFileExtArr);
                msgList.Add("必須是 " + fileExts + " 檔案格式");
            }

            // 檢查檔案容量是否符合規範
            byte[] fileContent = fileUpload.FileBytes;
            if (!FileHelper.ValidFileLength(fileContent))
            {
                msgList.Add("檔案容量必須是 " + FileHelper.UploadMB + "MB 以內");
            }

            errorMsgList = msgList;
            if (errorMsgList.Count > 0)
                return false;
            else
                return true;
        }
    }
}