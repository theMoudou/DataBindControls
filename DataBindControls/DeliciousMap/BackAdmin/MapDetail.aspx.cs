using DeliciousMap.Managers;
using DeliciousMap.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap.BackAdmin
{
    public partial class MapDetail : System.Web.UI.Page
    {
        private bool _isEditMode = false;
        private MapContentManager _mgr = new MapContentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 做編輯模式或新增模式的判斷
            if (!string.IsNullOrWhiteSpace(this.Request.QueryString["ID"]))
                this._isEditMode = true;
            else
                this._isEditMode = false;


            if (this._isEditMode)
                this.InitEditMode();
            else
                this.InitCreateMode();
        }

        /// <summary> 新增模式初始化 </summary>
        private void InitCreateMode()
        {
            this.imgCoverImage.Visible = false;
            this.lblMsg.Text = "請新增資料";
        }

        /// <summary> 編輯模式初始化 </summary>
        private void InitEditMode()
        { }

        /// <summary> 欄位檢查 (格式、型別檢查、必選填、上傳) </summary>
        /// <param name="errorMsgList"></param>
        /// <returns></returns>
        private bool CheckInput(out List<string> errorMsgList)
        {
            errorMsgList = new List<string>();

            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
                errorMsgList.Add("標題為必填。");

            if (string.IsNullOrWhiteSpace(this.txtBody.Text))
                errorMsgList.Add("內文為必填。");

            if (string.IsNullOrWhiteSpace(this.txtLongitude.Text))
                errorMsgList.Add("經度為必填。");

            if (string.IsNullOrWhiteSpace(this.txtLatitude.Text))
                errorMsgList.Add("緯度為必填。");

            if (!this._isEditMode)  // 只有新增模式，才做封面圖的必填
            {
                if (!this.fuCoverImage.HasFile)
                    errorMsgList.Add("封面圖為必填。");
            }

            double temp;
            if (!double.TryParse(this.txtLongitude.Text.Trim(), out temp))
                errorMsgList.Add("經度須介於 -180~180 度，精度允許六位小數。");
            else if (temp < -180 || temp > 180)
                errorMsgList.Add("經度須介於 -180~180 度，精度允許六位小數。");

            if (!double.TryParse(this.txtLatitude.Text.Trim(), out temp))
                errorMsgList.Add("緯度須介於 -90~90 度，精度允許六位小數。");
            else if (temp < -90 || temp > 90)
                errorMsgList.Add("緯度須介於 -90~90 度，精度允許六位小數。");

            if (errorMsgList.Count > 0)
                return false;
            else
                return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> errorMsgList = new List<string>();
            if (!this.CheckInput(out errorMsgList))
            {
                this.lblMsg.Text = string.Join("<br/>", errorMsgList);
                return;
            }


            MapContentModel model = new MapContentModel()
            {
                Title = this.txtTitle.Text.Trim(),
                Body = this.txtBody.Text.Trim(),
                Longitude = Convert.ToDouble(this.txtLongitude.Text.Trim()),
                Latitude = Convert.ToDouble(this.txtLatitude.Text.Trim()),
                IsEnable = this.ckbIsEnable.Checked,
            };

            if (this.fuCoverImage.HasFile)  // 儲存檔案，並將路徑寫至 model ，以供保存
            {
                System.Threading.Thread.Sleep(3);
                Random random = new Random((int)DateTime.Now.Ticks);
                string folderPath = "~/FileDownload/MapContent/";
                string fileName =
                    DateTime.Now.ToString("yyyyMMdd_HHmmss_FFFFFF") +
                    "_" + random.Next(10000).ToString("0000") +
                    Path.GetExtension(this.fuCoverImage.FileName);

                folderPath = HostingEnvironment.MapPath(folderPath);

                if (!Directory.Exists(folderPath))  // 假如資料夾不存在，先建立
                    Directory.CreateDirectory(folderPath);

                string newFilePath = Path.Combine(folderPath, fileName);
                this.fuCoverImage.SaveAs(newFilePath);

                model.CoverImage = "/FileDownload/MapContent/" + fileName;
            }

            // 取得登入者
            AccountModel account = new AccountManager().GetCurrentUser();

            // 儲存
            this._mgr.CreateMapContent(model, account.ID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // 跳回前頁
        }
    }
}