using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class SelectTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadDB();
            }
        }
        public int Pages
        {
            get { return Convert.ToInt32(ViewState["page"]);}
            set { ViewState["page"] = value; }
        }
        public int pagecount
        {
            get { return Convert.ToInt32(ViewState["pagecount"]); }
            set { ViewState["pagecount"] = value; }
        }
        PagedDataSource pds = new PagedDataSource();
        public void LoadDB()
        {
            GetableBLL bll = new GetableBLL();
            pds.DataSource = bll.GetAllTableBySeatAccount(Convert.ToInt32(DropDownList1.SelectedValue));
            pds.AllowPaging = true;
            pds.PageSize = 60;
            pds.CurrentPageIndex = Pages;//////////////
            if (pds.IsFirstPage && pds.IsLastPage)
            {
                link_previous.Enabled = false;//////////
                link_next.Enabled = false;
            }
            else if (pds.IsFirstPage)
            {
                link_previous.Enabled = false;
                link_next.Enabled = true;
            }
            else
            {
                link_previous.Enabled = true;
                link_next.Enabled = false;
            }
            pagecount = pds.DataSourceCount;
            label_Page.Text = "当前是" + (pds.CurrentPageIndex + 1).ToString() + "页  共有" + pds.PageCount.ToString() + "页  ";
            DataList1.DataSource = pds;
            DataList1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDB();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string yesstr = null;
            string str = null;
            foreach(DataListItem item in this.DataList1.Items)
            {
                CheckBox ck = (CheckBox)item.FindControl("CheckBox1");
                if(ck.Checked)
                {
                    yesstr += "'" + ck.Text.ToString() + "',";
                    str = ck.Text.ToString();
                }
            }
            Session["tableid"]=str;
            GetableBLL bll=new GetableBLL();
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(txt_account.Text))
            {
                string result = bll.UpdateStatus(yesstr.Substring(0, Convert.ToInt32(yesstr.Length) - 1));
                Response.Write("<script>alert('" + result + "')</script>");
                LoadDB();
                bll.CreateOrder(str, Convert.ToInt32(txt_account.Text));
                Response.Redirect("OrderDish.aspx");
            }
            else
            {
                Response.Write("<script>alert('please select table and person amount first！')</script>");
            }
        }

        protected void link_previous_Click(object sender, EventArgs e)
        {
            Pages--;
            LoadDB();
        }

        protected void link_next_Click(object sender, EventArgs e)
        {
            Pages++;
            LoadDB();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}