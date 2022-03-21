using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPISample
{
    public partial class TryBootStrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlModalTitle.Text = "由伺服器控制的 Title 訊息";
            this.ltlModalContent.Text = "由伺服器控制的內文訊息";


            string txtBox = Request.Form["testTextBox"];
            string txtArea = Request.Form["testTextArea"];

            Response.Write($"標題 {txtBox}, 內容{txtArea}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("按下下一筆");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("按下完成");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Write("按下對話方塊的完成");
        }
    }
}