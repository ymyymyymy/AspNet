using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class TableBLL
    {
        TableDAL dal = new TableDAL();
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<TableEnity> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string addTable(int id, int status)
        {
            return dal.addTable(id,status);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="u_accounts"></param>
        /// <returns></returns>
        public string deleteTablebyIds(string u_accounts)
        {
            return dal.deleteTablebyIds(u_accounts);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteTable(string u_account)
        {
            return dal.deleteTable(u_account);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string updateTable(string id, int table_status)
        {
            return dal.updateTable(id,table_status);
        }
    }
}
