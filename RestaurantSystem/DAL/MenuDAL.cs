using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DBContext;
using System.Data.SqlClient;

namespace DAL
{
    public class MenuDAL
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<MenuEnity> GetList()
        {
            List<MenuEnity> list = new List<MenuEnity>();
            string sql = "select Menu_ID,Menu_Name,type_Name,Menu_Price,Menu_picture from dbo.Menu m inner join dbo.Menu_Type mt on m.Menu_Type =mt.Type_ID";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                MenuEnity m = new MenuEnity(sdr[0].ToString(), sdr[1].ToString(), sdr[2].ToString(), Convert.ToSingle(sdr[3]), sdr[4].ToString());
                list.Add(m);
            }
            return list;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string addMenu(string Menu_Name, int TypeID, float Menu_Price, string Type)
        {
            string result = "";
            string strSql = string.Format("insert into Menu(Menu_ID,Menu_Name,Menu_Type,Menu_Price,Menu_picture)values (dbo.CreateMenu_ID('{0}'),'{1}',{2},{3},dbo.CreateMenu_ID('{4}'))", Type, Menu_Name, TypeID, Menu_Price, Type);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = "add sucess";
            }
            else
            {
                result = "add wrong";

            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteMenu(string id)
        {
            string result = "";
            string strSql = string.Format("delete dbo.Menu where Menu_ID='{0}' ", id);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = "delete sucess";
            }
            else
            {
                result = "delete wrong";

            }
            return result;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteMenuByIds(string ids)
        {
            string result = "";
            string strSql = string.Format("delete dbo.Menu where Menu_ID in ({0}) ", ids);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = "delete sucess";
            }
            else
            {
                result = "delete wrong";

            }
            return result;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string updateMenu(string name, int type, float price, string Menu_picture, string id)
        {
            string result = "";
            string strSql = string.Format(" update dbo.Menu set Menu_Name='{0}' ,Menu_Type={1},Menu_Price={2},Menu_picture='{3}' where Menu_ID='{4}'", name, type, price, Menu_picture, id);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = "update sucess";
            }
            else
            {
                result = "update wrong";

            }
            return result;
        }
    }
}
