using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace RestaurantSystem
{
    public partial class Chef : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
                //LoadDB();
            RestOrderBLL obj = new RestOrderBLL();
            foreach (OrderDetailEnity x in obj.LoadDB())
            {
                DropDownList1.Items.Add(x.order_id);
                LoadMenuDB(x.order_id);
            }
               
        }
        /// <summary>
        /// 接收所有未炒并且未付账的订单编号
        /// </summary>
        public void LoadDB()
        {
            RestOrderBLL obj = new RestOrderBLL();
            foreach (OrderDetailEnity x in obj.LoadDB())
            {
                DropDownList1.Items.Add(x.order_id);
                LoadMenuDB(x.order_id);
            }
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

        /// <summary>
        /// 根据订单编号查找所有将要炒的菜的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            RestOrderBLL bll = new RestOrderBLL();
            if (string.IsNullOrEmpty(DropDownList1.Text))
            {
                Response.Write("<script language=\"javascript\">alert('There are no dishes to stir ！')</script>");
            }
            else
            {
                LoadMenuDB(DropDownList1.SelectedItem.Text);
            }
        }
        /// <summary>
        /// 提交菜已经炒的信息
        /// </summary>
        /// <param name="sender">触发该事件的对象</param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string orderid = ((GridViewRow)(((DataControlFieldCell)(((Button)sender).Parent)).Parent)).Cells[0].Text;
                string memuid = ((GridViewRow)(((DataControlFieldCell)(((Button)sender).Parent)).Parent)).Cells[1].Text;
                string menuname = ((GridViewRow)(((DataControlFieldCell)(((Button)sender).Parent)).Parent)).Cells[2].Text;
                RestOrderBLL updatebll = new RestOrderBLL();
                bool message = updatebll.UpdateOrderDetail(orderid, memuid);
                Response.Write("<script language=\"javascript\">alert('" + menuname + message + "')</script>");
            }
        }
        /// <summary>
        /// 声明分页数据源
        /// </summary>
        PagedDataSource pds = new PagedDataSource();
        /// <summary>
        /// 根据订单编号对数据进行分页
        /// </summary>
        /// <param name="orderid">订单编号</param>
        public void LoadMenuDB(string orderid)
        {
            this.GridView1.Columns.Clear();
            RestOrderBLL bll = new RestOrderBLL();
            pds.DataSource = bll.GetList(orderid);
            pds.AllowPaging = true;
            pds.PageSize = 5;
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
            GridView1.DataSource = pds;
            GridView1.DataBind();

        }

        protected void link_previous_Click(object sender, EventArgs e)
        {
            Pages--;
            LoadMenuDB(DropDownList1.SelectedItem.Text);
        }

        protected void link_next_Click(object sender, EventArgs e)
        {
            Pages++;
            LoadMenuDB(DropDownList1.SelectedItem.Text);
        }
        /// <summary>
        /// 退出Chef系统，回到登录页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
