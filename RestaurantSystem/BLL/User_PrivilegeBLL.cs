using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class User_PrivilegeBLL
    {
        User_PrivilegeDAL dal = new User_PrivilegeDAL();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<User_PrivilegeEnity> GetUser()
        {
            return dal.GetUser();
        }
    }
}
