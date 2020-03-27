using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class AddMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadMenu_TypeBLL();
            }
        }
        /// <summary>
        /// loadMenu_Type by DropDownList1
        /// </summary>
        public void loadMenu_TypeBLL()
        {
            Menu_TypeBLL obj = new Menu_TypeBLL();
            DropDownList1.DataTextField = "type_Name";
            DropDownList1.DataValueField = "Type_ID";
            DropDownList1.DataSource = obj.GetList();
            DropDownList1.DataBind();

        }
        /// <summary>
        /// check parameter yes or no int 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool StrIsNum(string str)
        {
            char[] ch = new char[str.Length];
            ch = str.ToCharArray();
            for (int i = 0; i < str.Length;i++ )
            {
                if (ch[i] < 48 || ch[i] > 57)
                    return false;
            }
            return true;
        }
        protected void subbtim_Click(object sender, EventArgs e)
        {
            string name = userName.Text;
            string price = menuPrice.Text;
            string type = DropDownList1.SelectedItem.Text;
            int typeid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            if (StrIsNum(price))
            {
                float pricea = Convert.ToSingle(price);
                MenuBLL obj = new MenuBLL();
                string sql = obj.addMenu(name, typeid, pricea, type);
                Response.Write(string.Format("<script>alert('{0}')</script>", sql));
            }
            else
            {
                Response.Write("<script>alert('请输入正确的价格！')</script>");
            } 
        }

        protected void console_Click(object sender, EventArgs e)
        {
            userName.Text = null;
            menuPrice.Text = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("menu.aspx");
        }
    }
}