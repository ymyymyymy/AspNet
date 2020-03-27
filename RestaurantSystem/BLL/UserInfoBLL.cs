using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using DBContext;
using System.Data;

namespace BLL
{
    public  class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        /// <summary>
        /// 存在用户名
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Exists2(string name, string pwd)
        {
            return dal.Exists2(name,pwd);
        }
        /// <summary>
        /// 判断当前账号是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int getUser(string user)
        {
            return dal.getUser(user);
        }
        /// <summary>
        /// 获取一列值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetByName(string name)
        {
            return dal.GetByName(name);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfoEnity> GetAllNews()
        {
            return dal.GetAllNews();
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<UserInfoEnity> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public List<UserInfoEnity> GetNewsBySql(string safeSql)
        {
            return dal.GetNewsBySql(safeSql);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public UserInfoEnity GetNews()
        {
            return dal.GetNews();
        }
        /// <summary>
        /// 根据id删除user
        /// </summary>
        /// <param name="u_accounts"></param>
        /// <returns></returns>
        public bool deleteUserbyIds(string u_accounts)
        {
            return dal.deleteUserbyIds(u_accounts);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u_name"></param>
        /// <param name="u_password"></param>
        /// <param name="u_sex"></param>
        /// <param name="u_privilege"></param>
        /// <returns></returns>
        public string adduser(string u_name, string u_password, string u_sex, int u_privilege)
        {
            return dal.adduser(u_name,u_password,u_sex,u_privilege);
        }
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="sex"></param>
        /// <param name="u_privilege"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updateuser(string name, string pwd, string sex, int u_privilege, int id)
        {
            return dal.updateuser(name,pwd,sex,u_privilege,id);
        }
         /// <summary>
        /// 删除
        /// </summary>
        /// <param name="u_account"></param>
        /// <returns></returns>
        public string deleteuser(int u_account)
        {
            return dal.deleteuser(u_account);
        }
    }
}

