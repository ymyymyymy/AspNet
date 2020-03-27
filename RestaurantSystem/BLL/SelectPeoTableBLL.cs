using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DBContext;
using Model;

namespace BLL
{
    public class SelectPeoTableBLL
    {
        SelectPeoTable dal = new SelectPeoTable();
        /// <summary>
        /// 加载table
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IList<TableEnity> GetAllTable(int person)
        {
            return dal.GetAllTable(person);
        }
        /// <summary>
        /// 订桌
        /// </summary>
        /// <param name="table"></param>
        /// <param name="AmountofCustomer"></param>
        /// <returns></returns>
        public int CreateOrder(string table, int AmountofCustomer)
        {
            return dal.CreateOrder(table,AmountofCustomer);
        }
        /// <summary>
        /// 获取菜品的类别
        /// </summary>
        /// <returns></returns>
        public IList<Menu_TypeEnity> GetAllMenutype()
        {
            return dal.GetAllMenutype();
        }
        /// <summary>
        /// 菜品列表
        /// </summary>
        /// <param name="Menu_Type"></param>
        /// <returns></returns>
        public IList<MenuEnity> GetAllMenu(int Menu_Type)
        {
            return dal.GetAllMenu(Menu_Type);
        }
    }
}
