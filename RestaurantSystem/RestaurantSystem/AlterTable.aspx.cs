using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                displaypage();
            }
        }

        PagedDataSource pds = new PagedDataSource();
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
        /// <summary>
        /// page
        /// </summary>
        public void displaypage()
        {
            TableBLL obj = new TableBLL();
            pds.DataSource = obj.GetList();
            pds.AllowPaging = true;
            pds.PageSize = 5;
            pds.CurrentPageIndex = Pages;
            Label4.Text = pds.DataSourceCount.ToString();
            pagecount = pds.DataSourceCount;
            Label2.Text = (pds.CurrentPageIndex + 1).ToString();
            Label3.Text = pds.PageCount.ToString();
            GridView1.DataSource = pds;
            GridView1.DataBind();
        }

        public void getall()
        {
            for (int i = 0; i < GridView1.Rows.Count-1;i++ )
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                cbox.Checked = true;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string id = null;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)(GridView1.Rows[i].FindControl("CheckBox1"))).Checked)
                {
                    id += "'" + GridView1.DataKeys[i].Value + "'" + ",";

                }
            }

            if (id == null)
            {
               Response.Write(" <script>alert('请选择要删除的行！')</script>");
            }
            else
            {
                id = id.Substring(0, id.Length - 1);
                TableBLL obj = new TableBLL();
                Response.Write(" <script>alert('" + obj.deleteTablebyIds(id) + "')</script>");
                displaypage();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIndex.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTable.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Pages = 0;
            displaypage();
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Pages--;
            if (Pages == -1)
            {
                Pages = 0;
            }

            displaypage();
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Pages++;
            if (Pages == Convert.ToInt32(Label3.Text))
            {
                Pages = Convert.ToInt32(Label3.Text) - 1;
            }
            displaypage();
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (pagecount % 5 == 0)
            {
                Pages = (pagecount / 5) - 1;
            }
            else
            {
                Pages = (pagecount / 5);
            }
            displaypage();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableBLL obj = new TableBLL();
            string id = (GridView1.DataKeys[e.RowIndex].Value).ToString();
            Response.Write(" <script>alert('" + obj.deleteTable(id) + "')</script>");
            displaypage();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            displaypage();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate || e.Row.RowState == DataControlRowState.Normal)
                {
                    ((LinkButton)(e.Row.Cells[3].Controls[0])).Attributes.Add("onclick", "return confirm('确认要删除“" + e.Row.Cells[1].Text + "”吗');");
                }
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    DropDownList d = ((DropDownList)(e.Row.Cells[2].FindControl("DropDownList1")));
                    d.DataTextField = "status";
                    d.DataValueField = "Table_ID";
                    Table_SatausBLL obj = new Table_SatausBLL();
                    d.DataSource = obj.GetList();
                    d.DataBind();
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            displaypage();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TableBLL obj = new TableBLL();
            int status = Convert.ToInt32(((DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList1"))).SelectedValue);
            string id = (GridView1.DataKeys[e.RowIndex].Value).ToString();
            Response.Write(" <script>alert('" + obj.updateTable(id,status) + "')</script>");
            GridView1.EditIndex = -1;
            displaypage();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}