using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class AlterMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displaypage();
            }
        }

        public void load()
        {
            MenuBLL obj = new MenuBLL();
            GridView1.DataSource = obj.GetList();
            GridView1.DataBind();
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
            MenuBLL obj = new MenuBLL();
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

        /// <summary>
        /// Redirect frist page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Pages = 0;
            displaypage();
        }

        /// <summary>
        /// Redirect next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Pages++;
            if (Pages == Convert.ToInt32(Label3.Text))
            {
                Pages = Convert.ToInt32(Label3.Text) - 1;

            }

            displaypage();


        }

        /// <summary>
        /// Redirect previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Pages--;
            if (Pages == -1)
            {
                Pages = 0;
            }

            displaypage();



        }

        /// <summary>
        ///  Redirect last page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// delete Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MenuBLL obj = new MenuBLL();
            string id = (GridView1.DataKeys[e.RowIndex].Value).ToString();
            Response.Write(" <script>alert('" + obj.deleteMenu(id) + "')</script>");
            displaypage();
        }

        /// <summary>
        /// delete items Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MenuBLL obj = new MenuBLL();
                Response.Write(" <script>alert('" + obj.deleteMenuByIds(id) + "')</script>");
                displaypage();
            }

        }

        /// <summary>
        /// Redirect addMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMenu.aspx");
        }

        /// <summary>
        /// Editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            displaypage();
        }

        /// <summary>
        /// Updating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();

            string name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            int type = Convert.ToInt32(((DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList1"))).SelectedValue);
            string picture = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
            string price = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            // price =Convert.ToSingle(((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text);
            if (StrIsNum(price))
            {
                MenuBLL obj = new MenuBLL();
                float pricea = Convert.ToSingle(price);
                Response.Write(" <script>alert('" + obj.updateMenu(name, type, pricea, picture, id) + "')</script>");
                GridView1.EditIndex = -1;
                displaypage();
            }
            else
            {
                Response.Write(" <script>alert('请输入正确的价格！')</script>");
            }



        }

        /// <summary>
        /// Edited
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            displaypage();
        }

        /// <summary>
        ///  row Bound 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate || e.Row.RowState == DataControlRowState.Normal)
                {
                    ((LinkButton)(e.Row.Cells[6].Controls[0])).Attributes.Add("onclick", "return confirm('确认要删除“" + e.Row.Cells[2].Text + "”吗');");
                }

                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    DropDownList d = ((DropDownList)(e.Row.Cells[5].FindControl("DropDownList1")));
                    d.DataTextField = "type_Name";
                    d.DataValueField = "Type_ID";
                    Menu_TypeBLL obj = new Menu_TypeBLL();
                    d.DataSource = obj.GetList();
                    d.DataBind();
                }
            }
        }
        /// <summary>
        /// check parameter yes or on int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool StrIsNum(string str)
        {
            int i = 0, a = 0;
            char[] ste = str.ToCharArray();
            foreach (char c in ste)
            {
                try
                {
                    a = int.Parse(c.ToString());
                }
                catch
                {
                    i++;
                }
            }
            if (i == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Redirect adminindex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminindex.aspx");
        }

    }
}
