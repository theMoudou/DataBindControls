using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryMasterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Article article = ReadDBArticle();

            this.ltlTitle.Text = article.Title;
            this.ltlContent.Text = article.Content;

            this.Title = this.ltlTitle.Text;
        }

        private static Article ReadDBArticle()
        {
            Article article = new Article();
            article.Title = "測試標題";
            article.Content = "<p>123</p><p>456</p>";
            return article;
        }

        class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
        }
    }
}