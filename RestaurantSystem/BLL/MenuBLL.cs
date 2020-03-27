using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class MenuBLL
    {
        MenuDAL dal = new MenuDAL();  
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<MenuEnity> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteMenu(string id)
        {
            return dal.deleteMenuByIds(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteMenuByIds(string ids)
        {
            return dal.deleteMenuByIds(ids);
        }
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string updateMenu(string name, int type, float price, string Menu_picture, string id)
        {
            return dal.updateMenu(name,type,price,Menu_picture,id);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string addMenu(string Menu_Name, int TypeID, float Menu_Price, string Type)
        {
            return dal.addMenu(Menu_Name,TypeID,Menu_Price,Type);
        }
    }
}
