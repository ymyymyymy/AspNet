﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace RestaurantSystem
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displaypage();
            }

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
                    d.DataTextField = "P_name";
                    d.DataValueField = "P_id";
                    UserInfoBLL obj = new UserInfoBLL();
                    d.DataSource = obj.GetList();
                    d.DataBind();
                }
            }
        }

        /// <summary>
        /// Update  user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string pwd = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;                              RadioButton female = (RadioButton)this.GridView1.Rows[e.RowIndex].FindControl("RadioButton1");
            RadioButton male = (RadioButton)this.GridView1.Rows[e.RowIndex].FindControl("RadioButton2");
            string sex = "";
            if (female.Checked)
            {
                sex = "female";
            }
            else if (male.Checked)
            {
                sex = "male";
            }
            int u_privilege = Convert.ToInt32(((DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList1"))).SelectedValue);
            UserInfoBLL obj = new UserInfoBLL();
            Response.Write(" <script>alert('" + obj.updateuser(name, pwd, sex, u_privilege, id) + "')</script>");
            GridView1.EditIndex = -1;
            displaypage();

        }
        /// <summary>
        /// delete User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UserInfoBLL obj = new UserInfoBLL();
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            Response.Write(" <script>alert('" + obj.deleteuser(id) + "')</script>");
            displaypage();

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
        /// Redirect addUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("addUser.aspx");
        }

        /// <summary>
        /// delete items User
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
                    id += GridView1.DataKeys[i].Value + ",";
                    // id += this.GridView1.Rows[i].Cells[1].Text + ",";
                }
            }

            if (id == null)
            {
                Response.Write(" <script>alert('请选择要删除的行！')</script>");
            }
            else
            {
                id = id.Substring(0, id.Length - 1);
                UserInfoBLL obj = new UserInfoBLL();
                Response.Write(" <script>alert('" + obj.deleteUserbyIds(id) + "')</script>");
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
            UserInfoBLL obj = new UserInfoBLL();
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
        /// check sex is boy or girl
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public bool female(object sex)
        {
            bool result;
            if (sex.ToString().Trim() == "female")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// check sex is boy or girl
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public bool male(object sex)
        {

            bool result;
            if (sex.ToString().Trim() == "male")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Redirect adminindex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIndex.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
