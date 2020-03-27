using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class GetableBLL
    {
        GetableDAL dal = new GetableDAL();
        /// <summary>
        /// 根据桌子类型获取所有的桌子
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<TableaEnity> GetAllTableBySeatAccount(int person)
        {
            return dal.GetAllTableBySeatAccount(person);
        }
        /// <summary>
        /// 修改点餐结束的桌子状态
        /// </summary>
        /// <param name="yeschecked"></param>
        /// <returns></returns>
        public string UpdateStatus(string yeschecked)
        {
            return dal.UpdateStatus(yeschecked);
        }
        /// <summary>
        /// 
        /// 创建点菜菜单
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="personamount"></param>
        /// <returns></returns>
        public int CreateOrder(string tableid, int personamount)
        {
            return dal.CreateOrder(tableid,personamount);
        }
        /// <summary>
        ///获取所有菜品类型
        /// </summary>
        /// <returns></returns>
        public List<Menu_TypeEnity> getAllType()
        {
            return dal.getAllType();
        }
        /// <summary>
        /// 通过菜品类型获取菜单
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<MenuEnity> getAllMenuByType(string typeName)
        {
            return dal.getAllMenuByType(typeName);
        }
        /// <summary>
        ///检查未选中的桌子号是否存在
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public bool EmptyTable(string tableid)
        {
            return dal.EmptyTable(tableid);
        }
        /// <summary>
        /// 检查选中的桌子号是否存在
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public bool CheckedTable(string tableid)
        {
            return dal.CheckedTable(tableid);
        }
        /// <summary>
        /// 向菜单详细表中插入数据
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="menu_name"></param>
        /// <returns></returns>
        public int CreateOrderDetails(string tableid, string menu_name)
        {
            return dal.CreateOrderDetails(tableid,menu_name);
        }
        /// <summary>
        /// 输入桌号显示所有点过菜品
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public List<ShowMenuEnity> Show(string tableid)
        {
            return dal.Show(tableid);
        }
         /// <summary>
        /// 所消费菜品的总价格
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public float total(string tableid)
        {
            return dal.total(tableid);
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public int submit(string tableid)
        {
            return dal.submit(tableid);
        }
        /// <summary>
        /// 换桌
        /// </summary>
        /// <param name="oldone"></param>
        /// <param name="newone"></param>
        /// <returns></returns>
        public int changeTable(string oldone, string newone)
        {
            return dal.changeTable(oldone,newone);
        }
        /// <summary>
        ///  加菜
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="menu_name"></param>
        /// <returns></returns>
        public int AddDish(string tableid, string menu_name)
        {
            return dal.AddDish(tableid,menu_name);
        }
    }
}
