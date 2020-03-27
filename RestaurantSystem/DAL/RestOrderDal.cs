using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using DBContext;
using System.Configuration;

namespace DAL
{
    public class RestOrderDal
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<MenuEnity> GetList(string orderid)
        {
            List<MenuEnity> list = new List<MenuEnity>();
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings.ToString());
            //con.Open();
            //StringBuilder sql = new StringBuilder();
            //sql.Append("select t3.OrderID,t2.[Menu_Name],t4.[table_id],t1.[OrderDetail_amount],t1.menu_id  ");
            //sql.Append("from OrderDetail t1 inner join Menu t2 on t1.[Menu_ID]=t2.[menu_id]  ");
            //sql.Append("inner join [Order] t3 on t3.OrderID=t1.order_id  ");
            //sql.Append("inner join [table] t4 on t3.TableID=t4.table_id  ");
            //sql.Append("where OrderID=@orderid and  Status=0");
            //SqlCommand com = new SqlCommand(sql.ToString(),con);
            //com.Parameters.Add(new SqlParameter("@orderid", orderid));
            //SqlDataReader dr = com.ExecuteReader();
            string sql = "select t3.OrderID,t2.[Menu_Name],t4.[table_id],t1.[OrderDetail_amount],t1.menu_id from OrderDetail t1 inner join Menu t2 on t1.[Menu_ID]=t2.[menu_id] inner join [Order] t3 on t3.OrderID=t1.order_id inner join [table] t4 on t3.TableID=t4.table_id where OrderID=@orderid and Status=1";
            SqlParameter[] parameters =
            {
                new SqlParameter("@orderid", orderid),
            };
            SqlDataReader dr = SQLHelper.ExecuteReader(sql.ToString(), parameters);
            while (dr.Read())
            {
                string order_id = dr[0].ToString();
                string menuname = dr[1].ToString();
                string tableid = dr[2].ToString();
                string amountOfDish = dr[3].ToString();
                string menuid = dr[4].ToString();
                MenuEnity obj = new MenuEnity(order_id, menuname, tableid, Convert.ToInt32(amountOfDish), menuid);
                list.Add(obj);
            }
            return list;
        }
        //<summary>
        //获取所有未炒的菜以及未付账的订单(OrderID)
        //</summary>
        //<returns>得到所有未炒的菜以及未付账的订单(OrderID)</returns>
        public List<OrderDetailEnity> LoadDB()
        {

            List<OrderDetailEnity> list = new List<OrderDetailEnity>();
            string sql = "select distinct t2.OrderID from OrderDetail t1 inner join [Order] t2 on t1.order_id=t2.OrderID where Status=1 and CheckStatus=2";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                OrderDetailEnity obj = new OrderDetailEnity(sdr[0].ToString());
                list.Add(obj);
            }
            return list;
        }
        /// <summary>
        /// 根据订单编号(OrderID)和菜单编号(Menuid)修改菜是否炒的状态(如果菜已经炒了则更改菜的状态为true)
        /// </summary>
        /// <param name="orderid">订单编号</param>
        /// <param name="menuid">菜单编号</param>
        /// <returns>更新状态</returns>
        public bool UpdateOrderDetail(string orderid, string menuid)
        {
            bool isok = false;
            SqlCommand com = new SqlCommand("update OrderDetail set Status=1 where order_id=@orderid and menu_id=@menuid  ");
            com.Parameters.Add(new SqlParameter("@orderid", orderid));
            com.Parameters.Add(new SqlParameter("@menuid", menuid));
            int i = com.ExecuteNonQuery();
            if (i > 0)
                isok = true;
            return isok;
        }
    }
}
