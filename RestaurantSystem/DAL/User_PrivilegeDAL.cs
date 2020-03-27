using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using DBContext;
using System.Data.SqlClient;

namespace DAL
{
    public class User_PrivilegeDAL
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<User_PrivilegeEnity> GetUser()
        {
            List<User_PrivilegeEnity> user = new List<User_PrivilegeEnity>();
            string sql = "select p_id,p_name from dbo.User_Privilege ";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                User_PrivilegeEnity u = new User_PrivilegeEnity(Convert.ToInt32(sdr[0]), sdr[1].ToString());

                user.Add(u);
            }
            return user;
        }
    }
}
