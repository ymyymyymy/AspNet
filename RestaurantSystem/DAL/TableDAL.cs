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
    public class TableDAL
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<TableEnity> GetList()
        {
            List<TableEnity> list = new List<TableEnity>();
            string sql = "select table_id,status from dbo.[table] t inner join dbo.Table_status ts on t.table_status =ts.Status_ID ";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                TableEnity m = new TableEnity(sdr["table_id"].ToString(),sdr[1].ToString());
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string addTable(int id, int status)
        {
            string result = "";
            string strSql = string.Format("insert into [table](table_id,table_status) values(dbo.table_id({0}),{1})", id, status);
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
        /// 批量删除
        /// </summary>
        /// <param name="u_accounts"></param>
        /// <returns></returns>
        public string deleteTablebyIds(string u_accounts)
        {
            string result = "";
            string strSql = string.Format("delete dbo.[table] where table_id in ({0}) ", u_accounts);
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
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteTable(string u_account)
        {
            string result = "";
            string strSql = string.Format("delete dbo.[table] where table_id ='{0}' ", u_account);
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
        public string updateTable(string id, int table_status)
        {
            string result = "";
            string strSql = string.Format("update dbo.[table] set table_status={0} where table_id='{1}'", table_status, id);
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
