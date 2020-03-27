using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class ChangeOrder : System.Web.UI.Page
    {
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
        GetableBLL bll = new GetableBLL();
        public void LoadDB()
        {

            pds.DataSource = bll.GetAllTableBySeatAccount(Convert.ToInt32(DropDownList1.SelectedValue));
            pds.AllowPaging = true;
            pds.PageSize = 60;
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
            DataList1.DataSource = pds;
            DataList1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDB();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txt_destination.Text) && !string.IsNullOrEmpty(txt_table.Text))
            {
                if (bll.CheckedTable(txt_table.Text) && bll.EmptyTable(txt_destination.Text))
                {
                    Response.Write("<script>alert('" + bll.changeTable(txt_table.Text, txt_destination.Text) + " !')</script>");
                    Response.Write("<script>alert('change table success !')</script>");
                    LoadDB();
                }
                else if (bll.EmptyTable(txt_destination.Text)==false )
                {
                    Response.Write("<script>alert('the destination is not exist !')</script>");
                }
                else if (bll.CheckedTable(txt_table.Text)==false)
                {
                    Response.Write("<script>alert('the original table  is not exist !')</script>");
                }
                else
                {
                    Response.Write("<script>alert('wrong input !')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert( 'table number is not null !')</script>");
            }
        }

        protected void link_next_Click(object sender, EventArgs e)
        {
            Pages++;
            //if (Pages ==( pds.PageCount+1))
            //{
            //    Pages = 0;
            //}

            LoadDB();

        }

        protected void link_previous_Click(object sender, EventArgs e)
        {
            Pages--;
            //if (Pages ==( pds.PageCount+1))
            //{
            //    Pages = 0;
            //}

            LoadDB();

        }
    }
}
