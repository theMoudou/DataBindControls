using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace BindingPractice
{
    public partial class TablePractice1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tableBody = string.Empty;
            DataTable dt = this.GetDataTable();
            foreach(DataRow dr in dt.Rows)
            {
                string bodyText = 
                    $@"<tr>
                        <td>{dr["ID"]}</td>
                        <td>{dr["Name"]}</td>
                    </tr>";
                tableBody += bodyText;
            }
            this.ltlTableBody.Text = tableBody;
        }
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));

            DataRow dr1 = dt.NewRow();
            dr1["ID"] = "st-001";      //
            dr1["Name"] = "Moudou";    //
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["ID"] = "st-002";
            dr2["Name"] = "Will";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["ID"] = "st-003";
            dr3["Name"] = "William";
            dt.Rows.Add(dr3);

            return dt;
        }
    }
}