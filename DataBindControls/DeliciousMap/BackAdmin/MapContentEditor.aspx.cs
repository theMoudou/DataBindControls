using DeliciousMap.Managers;
using DeliciousMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap.BackAdmin
{
    public partial class MapContentEditor : System.Web.UI.Page
    {
        private MapContentManager _mgr = new MapContentManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckInput())  // 是否通過檢查
                return;

            //string id = this.hfID.Value.Trim();
            string name = this.txtTitle.Text.Trim();
            string body = this.txtBody.Text.Trim();
            string latitudeText = this.txtLatitude.Text.Trim();
            string longitudeText = this.txtLongitude.Text.Trim();

            float latitude;
            float longitude;

            MapContentModel model = new MapContentModel();
            model.Title = name;
            model.Body = body;

            if (float.TryParse(latitudeText, out latitude))
                model.Latitude = latitude;
            else
                model.Latitude = 0;

            if (float.TryParse(longitudeText, out longitude))
                model.Longitude = longitude;
            else
                model.Longitude = 0;

            _mgr.CreateMapContent(model);
            this.ltlMessage.Text = "儲存成功";
            this.txtTitle.Text = string.Empty;
            this.txtBody.Text = string.Empty;
            this.txtLatitude.Text = string.Empty;
            this.txtLongitude.Text = string.Empty;
        }

        public bool CheckInput()
        {
            List<string> msgList = new List<string>();

            //if(this.txtTitle.Text.Length == 0)
            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
                msgList.Add("標題為必填");

            if (string.IsNullOrWhiteSpace(this.txtBody.Text))
                msgList.Add("內文為必填");

            if (!string.IsNullOrWhiteSpace(this.txtLatitude.Text))
            {
                float latitude;
                if (!float.TryParse(this.txtLatitude.Text, out latitude))
                    msgList.Add("緯度為數字，並介於 -90~90 之間");
                else if (latitude < -90 || latitude > 90)
                    msgList.Add("緯度為數字，並介於 -90~90 之間");
            }

            if (!string.IsNullOrWhiteSpace(this.txtLongitude.Text))
            {
                float longitude;
                if (!float.TryParse(this.txtLongitude.Text, out longitude))
                    msgList.Add("經度為數字，並介於 -180~180 之間");
                else if (longitude < -180 || longitude > 180)
                    msgList.Add("經度為數字，並介於 -180~180 之間");
            }
            
            if (msgList.Count > 0)  // 如果有錯誤發生，就回傳 false ，並提示錯誤訊息
            {
                string allError = string.Join("<br/>", msgList);
                this.ltlMessage.Text = allError;
                return false;
            }
            return true;
        }
    }
}