using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class OrderDish2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMenutype();
                LoadMenu(4);
            }
        }
        SelectPeoTableBLL obj = new SelectPeoTableBLL();
        public void LoadMenutype()
        {
            DataList1.DataSource = obj.GetAllMenutype();
            DataList1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ViewState["menu_type"] = ((LinkButton)sender).CommandArgument;
            LoadMenu(Convert.ToInt32(ViewState["menu_type"]));
        }
        public void LoadMenu(int menu_type)
        {
            DataList2.DataSource = obj.GetAllMenu(menu_type);
            DataList2.DataBind();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            TextBox1.Text = ((ImageButton)sender).CommandArgument;
        }

    }
}
