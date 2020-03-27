using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using DBContext;

namespace DAL
{
    public class Table_StatusDAL
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Table_StatusEnity> GetList()
        {
            List<Table_StatusEnity> list = new List<Table_StatusEnity>();
            string sql = "select Status_ID,status from dbo.Table_status ";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                Table_StatusEnity m = new Table_StatusEnity(Convert.ToInt32(sdr[0]), sdr[1].ToString());
                list.Add(m);
            }
            return list;
        }
    }
}
