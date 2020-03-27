using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;

namespace RestaurantSystem
{
    public partial class Login : System.Web.UI.Page
    {
        UserInfoEnity enity = new UserInfoEnity();
        UserInfoDAL dal = new UserInfoDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            if(dal.Exists2(name,pwd))
            {
                if (dal.GetByName(name) == 1)
                {
                    Response.Write("<script>alert('登录成功,权限为1');window.location.href='AdminIndex.aspx';</script>");
                }
                else if (dal.GetByName(name) == 2)
                {
                    Response.Write("<script>alert('登录成功,权限为2');window.location.href='SelectTable.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('登录成功,权限为3');window.location.href='Chef.aspx';</script>");
                }
                
            }
            else if (dal.getUser(name) < 0)
            {
                Response.Write("当前用户不存在");
            }
            else
            {
                Response.Write("密码错误");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPwd.Text = "";
        }
    }
}