using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class Menu_TypeBLL
    {
        Menu_TypeDAL dal = new Menu_TypeDAL();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<Menu_TypeEnity> GetList()
        {
            return dal.GetList();
        }
    }
}
