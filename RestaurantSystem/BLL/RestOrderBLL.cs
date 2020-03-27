using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class RestOrderBLL
    {
        RestOrderDal dal = new RestOrderDal();
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<MenuEnity> GetList(string orderid)
        {
            return dal.GetList(orderid);
        }
        //<summary>
        //获取所有未炒的菜以及未付账的订单(OrderID)
        //</summary>
        //<returns>得到所有未炒的菜以及未付账的订单(OrderID)</returns>
        public List<OrderDetailEnity> LoadDB()
        {
            return dal.LoadDB();
        }
        /// <summary>
        /// 根据订单编号(OrderID)和菜单编号(Menuid)修改菜是否炒的状态(如果菜已经炒了则更改菜的状态为true)
        /// </summary>
        /// <param name="orderid">订单编号</param>
        /// <param name="menuid">菜单编号</param>
        /// <returns>更新状态</returns>
        public bool UpdateOrderDetail(string orderid, string menuid)
        {
            return dal.UpdateOrderDetail(orderid,menuid);
        }
    }
}
