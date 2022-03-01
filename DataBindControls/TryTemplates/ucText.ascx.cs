using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class ucText : System.Web.UI.UserControl
    {
        // 中間人，負責傳遞或取得 Label 的文字
        public string Text
        {
            get { return this.lbl.Text; }
            set { this.lbl.Text = value; }
        }

        // 中間人，負責傳遞 Label 的文字
        public void SetLabelText(string txt)
        {
            this.lbl.Text = txt;
        }

        // 中間人，負責取得 Label 的文字
        public string GetLabelText()
        {
            return this.lbl.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}