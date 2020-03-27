using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class AddTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load();  ///////////////////////为什么添加4或8就自动变为桌号
            }
        }

        public void load()
        {

            DropDownList1.DataTextField = "status";
            DropDownList1.DataValueField = "Table_ID";
            Table_SatausBLL obj = new Table_SatausBLL();
            DropDownList1.DataSource = obj.GetList();
            DropDownList1.DataBind();
        }

        protected void console_Click(object sender, EventArgs e)
        {
            userName.Text = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlterTable.aspx");
        }

        protected void subbtim_Click(object sender, EventArgs e)
        {
            TableBLL obj = new TableBLL();
            int id = Convert.ToInt32(userName.Text);
            int status = Convert.ToInt32(DropDownList1.SelectedValue);
            string sql = obj.addTable(id, status);
            Response.Write(string.Format("<script>alert('{0}')</script>", sql));
        }
    }
}