using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DBContext;
using Model;

namespace DAL
{
    public class GetableDAL
    {
        /// <summary>
        /// 根据桌子类型获取所有的桌子
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<TableaEnity> GetAllTableBySeatAccount(int person)
        {
            List<TableaEnity> list = new List<TableaEnity>();
            string sql = "";
            if(person==4)
            {
                sql = "select * from dbo.[table] where table_id like 'A%' and table_status=1";
            }
            if (person == 8)
                sql = "select * from dbo.[table] where table_id like 'B%' and table_status=1";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                TableaEnity t = new TableaEnity();
                t.table_id = sdr[0].ToString();
                t.table_status = sdr[1].ToString();
                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// 修改点餐结束的桌子状态
        /// </summary>
        /// <param name="yeschecked"></param>
        /// <returns></returns>
        public string UpdateStatus(string yeschecked)
        {
            string result = "";
            //string strSql = "update dbo.[table] set table_status=2 where table_id in (" + yeschecked + ")";
            string strSql = string.Format("update dbo.[table] set table_status=2 where table_id in ({0})", yeschecked);
            int num1 = SQLHelper.ExecuteSql(strSql);
             if (num1 > 0)
            {
                result = "order table sucess!";
            }
            else
            {
                result = "order table  fail！";

            }
            return result;
        }
        /// <summary>
        /// 
        /// 创建点菜菜单
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="personamount"></param>
        /// <returns></returns>
        public int CreateOrder(string tableid, int personamount)
        {
            string strSql = "insert into dbo.[Order](OrderID,OrderTime,TableID,AmountofCustomer,CheckStatus) values(dbo.getOrderID(),getdate(),@TableID,@AmountofCustomer,2)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@TableID", tableid),
                new SqlParameter("@AmountofCustomer", personamount)
            };
            int i = SQLHelper.ExecuteSql(strSql.ToString(), parameters);
            return i;
        }
        /// <summary>
        ///获取所有菜品类型
        /// </summary>
        /// <returns></returns>
        public List<Menu_TypeEnity> getAllType()
        {
            List<Menu_TypeEnity> list_menuType = new List<Menu_TypeEnity>();
            string strSql = "select * from Menu_Type";
            SqlDataReader sdr = SQLHelper.ExecuteReader(strSql);
            while (sdr.Read())
            {
                Menu_TypeEnity mt = new Menu_TypeEnity();
                mt.Type_ID = Convert.ToInt32(sdr[0]);
                mt.type_Name = sdr[1].ToString();
                list_menuType.Add(mt);
            }
            return list_menuType;
        }
        /// <summary>
        /// 通过菜品类型获取菜单
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<MenuEnity> getAllMenuByType(string typeName)
        {
            List<MenuEnity> list_menu = new List<MenuEnity>();
            string strSql = "select Menu_Name,Menu_Price,Menu_picture from dbo.Menu inner join  dbo.Menu_Type on Type_ID = Menu_Type where  type_Name = @typeName";
            SqlParameter[] parameters =
            {
                new SqlParameter("@typeName", typeName)
            };
            SqlDataReader sdr = SQLHelper.ExecuteReader(strSql.ToString(), parameters);
            while (sdr.Read())
            {

                MenuEnity m = new MenuEnity(sdr[0].ToString(), Convert.ToSingle(sdr[1]), sdr[2].ToString());
                list_menu.Add(m);
            }
            return list_menu;
        }
        /// <summary>
        ///检查未选中的桌子号是否存在
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        //public int EmptyTable1(string tableid)
        //{

        //    string strSql = "select count(*) from [table] where table_id=@tableid and table_status=1";
        //    SqlParameter[] parameters =
        //    {
        //        new SqlParameter("@tableid",tableid)
        //    };
        //    int i = (int)SQLHelper.ExecuteSql(strSql.ToString(), parameters);
        //    return i;
        //}
        public bool EmptyTable(string tableid)
        {

            string strSql = "select count(*) from [table] where table_id=@tableid and table_status=1";
            SqlParameter[] parameters =
            {
                new SqlParameter("@tableid",tableid)
            };
            return SQLHelper.Exists(strSql.ToString(),parameters);
           
        }
        /// <summary>
        /// 检查选中的桌子号是否存在
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public bool CheckedTable(string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from [table] where table_id=@tableid and table_status=2");
            SqlParameter[] parameters =
            {
                new SqlParameter("@tableid",tableid)
            };
            return SQLHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 向菜单详细表中插入数据
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="menu_name"></param>
        /// <returns></returns>
        public int CreateOrderDetails(string tableid, string menu_name)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@tableid",tableid),
                 new SqlParameter("@menu_name",menu_name)
            };
            int i = SQLHelper.GetScalar("proc_OrderDetail", parameters);
            return i;
        }
        /// <summary>
        /// 输入桌号显示所有点过菜品
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public List<ShowMenuEnity> Show(string tableid)
        {
            List<ShowMenuEnity> list = new List<ShowMenuEnity>();

            SqlDataReader dr = SQLHelper.RunProcedure("proc_showMenu", new SqlParameter[] { new SqlParameter("@tableid", tableid) });
            while (dr.Read())
            {
                ShowMenuEnity sm = new ShowMenuEnity(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToSingle(dr[2]));
                list.Add(sm);
            }
            return list;
        }
        /// <summary>
        /// 所消费菜品的总价格
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public float total(string tableid)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@tableid",tableid)
            };
            float sum = Convert.ToSingle(SQLHelper.GetScalar("proc_total", parameters));
            return sum;
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public int submit(string tableid)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@tableid",tableid)
            };
            int i = SQLHelper.GetScalar("proc_submit",parameters);
            return i;
        }
        /// <summary>
        /// 换桌
        /// </summary>
        /// <param name="oldone"></param>
        /// <param name="newone"></param>
        /// <returns></returns>
        public int changeTable(string oldone, string newone)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@firstid", oldone),
                new SqlParameter("@lastid", newone)
            };
            int i = SQLHelper.GetScalar("proc_changeTable",parameters);
            return i;
        }
        /// <summary>
        ///  加菜
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="menu_name"></param>
        /// <returns></returns>
        public int AddDish(string tableid, string menu_name)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@tableid", tableid),
                new SqlParameter("@menu_name", menu_name)
            };
            int i = SQLHelper.GetScalar("proc_AddDish",parameters);
            return i;
        }
    }
}
