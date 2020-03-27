using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using DBContext;

namespace DAL
{
    public class SelectPeoTable
    {
        /// <summary>
        /// 加载table
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IList<TableEnity> GetAllTable(int person)
        {
            List<TableEnity> table = new List<TableEnity>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@person", person)
            };
            SqlDataReader dr = SQLHelper.RunProcedure("GetAllTable", parameters);
            while (dr.Read())
            {
                TableEnity obj = new TableEnity(dr[0].ToString(), Convert.ToInt32(dr[1]));
                table.Add(obj);
            }
            return table;
        }
        /// <summary>
        /// 订桌
        /// </summary>
        /// <param name="table"></param>
        /// <param name="AmountofCustomer"></param>
        /// <returns></returns>
        public int CreateOrder(string table, int AmountofCustomer)
        {
            int i = 0;
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@table", table);
            para[1] = new SqlParameter("@AmountofCustomer", AmountofCustomer);
            return i = SQLHelper.GetScalar("createorder", para);
        }
        /// <summary>
        /// 获取菜品的类别
        /// </summary>
        /// <returns></returns>
        public IList<Menu_TypeEnity> GetAllMenutype()
        {
            List<Menu_TypeEnity> list = new List<Menu_TypeEnity>();
            string sql = "select * from dbo.Menu_Type order by Type_ID";
            SqlDataReader dr = SQLHelper.ExecuteReader(sql);
            while (dr.Read())
                {
                    Menu_TypeEnity mt = new Menu_TypeEnity(Convert.ToInt32(dr[0]), dr[1].ToString());
                    list.Add(mt);
                }
            return list;
        }
        /// <summary>
        /// 菜品列表
        /// </summary>
        /// <param name="Menu_Type"></param>
        /// <returns></returns>
        public IList<MenuEnity> GetAllMenu(int Menu_Type)
        {
            List<MenuEnity> obj = new List<MenuEnity>();
            string sql = "select Menu_Name,Menu_Type,Menu_picture, Menu_ID from dbo.Menu where Menu_Type=@Menu_Type";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Menu_Type", Menu_Type)
            };
            SqlDataReader dr = SQLHelper.ExecuteReader(sql.ToString(), parameters);
            while (dr.Read())
                {
                    MenuEnity menu = new MenuEnity(dr[0].ToString(), Convert.ToSingle(dr[1]), dr[2].ToString(), dr[3].ToString());
                    obj.Add(menu);
                }
            return obj;
        }
    }
}
