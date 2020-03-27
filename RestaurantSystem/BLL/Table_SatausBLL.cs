using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class Table_SatausBLL
    {
        Table_StatusDAL dal = new Table_StatusDAL();
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Table_StatusEnity> GetList()
        {
            return dal.GetList();
        }
    }
}
