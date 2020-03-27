using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class addUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUser_PrivilegeBLL();
        }

        /// <summary>
        /// load User_Privilege by DropDownList1
        /// </summary>
        public void loadUser_PrivilegeBLL()
        {
            User_PrivilegeBLL obj = new User_PrivilegeBLL();
            DropDownList1.DataTextField = "p_name";
            DropDownList1.DataValueField = "p_id";
            DropDownList1.DataSource = obj.GetUser();
            DropDownList1.DataBind();
        }
        protected void console_Click(object sender, EventArgs e)
        {
            userName.Text = null;
            userPwd.Text = null;
            userpwtwo.Text = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void subbtim_Click(object sender, EventArgs e)
        {
            string sex = "female";
            if (male.Checked)
            {
                sex = "male";
            }
            UserInfoBLL obj = new UserInfoBLL();
            string sql = obj.adduser(userName.Text, userPwd.Text, sex, Convert.ToInt32(DropDownList1.SelectedValue));
            Response.Write(string.Format("<script>alert('{0}')</script>", sql));
        }
    }
}