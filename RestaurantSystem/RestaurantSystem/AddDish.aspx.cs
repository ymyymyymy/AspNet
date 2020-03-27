using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class AddDish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDB("cold");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Pages = 0;
            LoadDB(((LinkButton)sender).Text);
            ViewState["type"] = ((LinkButton)sender).Text;
        }

        protected void link_previous_Click(object sender, EventArgs e)
        {
            Pages--;
            LoadDB(ViewState["type"].ToString());
        }

        protected void link_next_Click(object sender, EventArgs e)
        {
            Pages++;
            LoadDB(ViewState["type"].ToString());
        }

        public int Pages
        {
            get { return Convert.ToInt32(ViewState["Pages"]); }
            set { ViewState["Pages"] = value; }
        }
        public int pagecount
        {
            get { return Convert.ToInt32(ViewState["pagecount"]); }
            set { ViewState["pagecount"] = value; }
        }


        public int PageMenu
        {
            get { return Convert.ToInt32(ViewState["PageMenu"]); }
            set { ViewState["PageMenu"] = value; }
        }
        public int pageMenuCount
        {
            get { return Convert.ToInt32(ViewState["pageMenuCount"]); }
            set { ViewState[" pageMenuCount"] = value; }
        }

        PagedDataSource pds = new PagedDataSource();
        GetableBLL bll = new GetableBLL();
        public void LoadDB(string type)
        {
            pds.DataSource = bll.getAllMenuByType(type);
            pds.AllowPaging = true;
            pds.PageSize = 9;
            pds.CurrentPageIndex = Pages;

            if (pds.IsFirstPage && pds.IsLastPage)
            {
                link_previous.Enabled = false;
                link_next.Enabled = false;
            }
            else if (pds.IsFirstPage)
            {
                link_previous.Enabled = false;
                link_next.Enabled = true;
            }
            else if (pds.IsLastPage)
            {
                link_previous.Enabled = true;
                link_next.Enabled = false;
            }
            else
            {
                link_previous.Enabled = true;
                link_next.Enabled = true;
            }

            pagecount = pds.DataSourceCount;
            lbl_page.Text = "当前是" + (pds.CurrentPageIndex + 1).ToString() + "页  共有" + pds.PageCount.ToString() + "页  ";
            DataList2.DataSource = pds;
            DataList2.DataBind();
        }
        public void LoadMenuDB()
        {
            PagedDataSource pds = new PagedDataSource();

            pds.DataSource = bll.Show(txt_number.Text);
            pds.AllowPaging = true;
            pds.PageSize = 12;
            pds.CurrentPageIndex = PageMenu;

            if (pds.IsFirstPage && pds.IsLastPage)
            {
                link_down.Enabled = false;
                link_up.Enabled = false;
            }
            else if (pds.IsFirstPage)
            {
                link_up.Enabled = false;
                link_down.Enabled = true;
            }
            else if (pds.IsLastPage)
            {
                link_up.Enabled = true;
                link_down.Enabled = false;
            }
            else
            {
                link_up.Enabled = true;
                link_down.Enabled = true;
            }
            DataList3.DataSource = pds;
            DataList3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectTable.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (bll.CheckedTable(txt_number.Text))
            {
                if (bll.CreateOrderDetails(txt_number.Text, ((ImageButton)sender).CommandArgument.ToString()) > 0)
                {
                    LoadMenuDB();
                }
            }
            else
            {
                Response.Write("<script>alert('the table is not select ！')</script>");
            }
        }

        protected void link_up_Click(object sender, EventArgs e)
        {
            PageMenu--;
            LoadMenuDB();
        }

        protected void link_down_Click(object sender, EventArgs e)
        {
            PageMenu++;
            LoadMenuDB();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (bll.CheckedTable(txt_number.Text))
            {
                if (bll.CreateOrderDetails(txt_number.Text, ((ImageButton)sender).CommandArgument.ToString()) > 0)
                {
                    LoadMenuDB();
                }
            }
            else
            {
                Response.Write("<script>alert('the table is not select ！')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (bll.CheckedTable(txt_number.Text))
            {
                LoadMenuDB();
            }
            else
            {
                Response.Write("<script>alert('wrong input！')</script>");
            }
        }
    }
}