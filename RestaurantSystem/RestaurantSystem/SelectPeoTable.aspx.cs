using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RestaurantSystem
{
    public partial class SelectPeoTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDB();
            }
        }
        SelectPeoTableBLL obj = new SelectPeoTableBLL();

        public void LoadDB()
        {
            DataList1.DataSource = obj.GetAllTable(4);
            DataList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                int person = Convert.ToInt32(txt_person.Text);
                int selecttable = Convert.ToInt32(DropDownList1.SelectedValue);
                string table = null;
                if (person > selecttable)
                {
                    this.Page.RegisterStartupScript("key0", "<script>alert('请选择大一点的桌')</script>");
                }
                else
                {
                    int i = 0;
                    for (int j = 0; j < DataList1.Items.Count; j++)
                    {
                        CheckBox ckb_table = (CheckBox)DataList1.Items[j].FindControl("CheckBox1");
                        if (ckb_table.Checked)
                        {
                            i++;
                            table = ckb_table.Text;
                        }

                    }
                    if (i >= 1)
                    {
                        int message = obj.CreateOrder(table, person);
                        this.Page.RegisterStartupScript("key0", "<script>alert('" + message + "')</script>");
                    }
                    else
                    {
                        this.Page.RegisterStartupScript("key0", "<script>alert('请选择一桌')</script>");
                    }


                }
            //}
            //catch (Exception)
            //{
            //    this.Page.RegisterStartupScript("Key0", "<script>alert('输入错误')</script>");
            //    return;
            //    throw;
            //}

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int person = Convert.ToInt32(DropDownList1.SelectedValue);
            DataList1.DataSource = obj.GetAllTable(person);
            DataList1.DataBind();
        }
    }
}
