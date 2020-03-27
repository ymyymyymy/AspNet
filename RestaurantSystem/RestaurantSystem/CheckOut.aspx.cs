using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class CheckOut : System.Web.UI.Page
    {
        GetableBLL bll = new GetableBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDB();
        }
        public int Pages
        {
            get { return Convert.ToInt32(ViewState["page"]); }
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
            pds.DataSource = bll.Show(txt_number.Text);
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
            DataList3.DataSource = pds;
            DataList3.DataBind();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {

            Response.Write("<script>alert('" + bll.submit(txt_number.Text) + "')</script>");
            lbl_total.Text = null;
            LoadDB();
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (bll.CheckedTable(txt_number.Text))
            {
                LoadDB();
                lbl_total.Text=bll.total(txt_number.Text).ToString();
            }
            else
            {
                LoadDB();
                Response.Write("<script>alert('the number is not exists !')</script>");
            }
        }

        protected void btn_sum_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Write("<script>alert('Your   expenditure   is " + bll.total(txt_number.Text) + "$    this   time !')</script>");

            }
            catch (Exception)
            {
                Response.Write("<script>alert('please confirm information ！')</script>");
            }
        }

        protected void link_next_Click(object sender, EventArgs e)
        {
            Pages++;
            LoadDB();
        }

        protected void link_previous_Click(object sender, EventArgs e)
        {
            Pages--;
            LoadDB();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
