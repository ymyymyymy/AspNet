using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DBContext;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class UserInfoDAL
    {
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
            string result="";
            string strSql = string.Format("insert into dbo.UserInfo(u_name,u_password,u_sex,u_privilege) values('{0}','{1}','{2}',{3})", u_name, u_password, u_sex, u_privilege);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = "add sucess";
            }
            else
            {
                result = "add wrong";

            }
            return result;
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
            bool result;
            string sql = string.Format("update dbo.UserInfo set u_name='{0}',u_password='{1}',u_sex='{2}',u_privilege={3} where u_account={4}", name, pwd, sex, u_privilege, id);
            int i = SQLHelper.ExecuteSql(sql);
            if (i > 0)
            {
                result = true;
            }
            else
            {
                result = false;

            }
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="u_account"></param>
        /// <returns></returns>
        public string deleteuser(int u_account)
        {
            string result = "";
            string strSql = string.Format("delete dbo.UserInfo where u_account={0} ", u_account);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = "delete sucess";
            }
            else
            {
                result = "delete wrong";

            }
            return result;
        }
        /// <summary>
        /// 存在用户名
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Exists2(string name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [dbo].[UserInfo] where u_name='" + name + "' and u_password='" + pwd + "'");

            return SQLHelper.Exists1(strSql.ToString());
        }
        /// <summary>
        /// 判断当前账号是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int getUser(string user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select userId from [dbo].[UserInfo] where u_name='" + user + "'");
            object obj = SQLHelper.GetSingle(strSql.ToString());//返回查询结果
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 获取一列值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetByName(string name)
        {
            int result = 0;
            string sql = "SELECT * FROM [dbo].[UserInfo] WHERE u_name='" + name + "'";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@u_name", name));
            if (reader.Read() == Convert.ToBoolean(reader["u_privilege"]))
            {
                if (reader["u_name"].ToString() == "1")
                {
                    result = 1;
                }
                else if (reader["u_name"].ToString() == "2")
                {
                    result = 2;
                }
                else
                {
                    result = 3;
                }
                reader.Close();
            }
            return result;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<UserInfoEnity> GetList()
        {
            List<UserInfoEnity> list = new List<UserInfoEnity>();
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["restaurantSys"].ToString());
            string sql = "select t1.u_account,t1.u_name,t1.u_password,t1.u_sex,t2.p_name from UserInfo t1 inner join User_Privilege t2 on t1.u_privilege = t2.p_id ";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                UserInfoEnity u = new UserInfoEnity(Convert.ToInt32(sdr[0]), sdr[1].ToString(), sdr[2].ToString(), sdr[3].ToString(), sdr[4].ToString());
                list.Add(u);
            }
            return list ;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfoEnity> GetAllNews()
        {
            string sqlAll = "select t1.u_account,t1.u_name,t1.u_password,t1.u_sex,t2.p_name from UserInfo t1 inner join User_Privilege t2 on t1.u_privilege = t2.p_id ";
            return GetNewsBySql(sqlAll);
        }
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public List<UserInfoEnity> GetNewsBySql(string safeSql)
        {
            List<UserInfoEnity> list = new List<UserInfoEnity>();
            try
            {
                DataTable table = SQLHelper.GetTable(safeSql);
                foreach (DataRow row in table.Rows)
                {
                    UserInfoEnity user = new UserInfoEnity();
                    user.u_account=(int)row["u_account"];
                    user.u_name = (string)row["u_name"];
                    user.u_password = (string)row["u_password"];
                    //user.u_privilege = (int)row["u_privilege"];
                    user.u_sex = (string)row["u_sex"];
                    list.Add(user);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public UserInfoEnity GetNews()
        {
            string sql = "SELECT * FROM [dbo].[UserInfo]";
            try
            {
                SqlDataReader reader = SQLHelper.GetReader(sql);
                if (reader.Read())
                {
                    UserInfoEnity user = new UserInfoEnity();
                    user.u_account=(int)reader["u_account"];
                    user.u_name=(string)reader["u_name"];
                    user.u_password=(string)reader["u_password"];
                    user.u_privilege = (int)reader["u_privilege"];
                    user.u_sex=(string)reader["u_sex"];
                    reader.Close();
                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 根据id删除user
        /// </summary>
        /// <param name="u_accounts"></param>
        /// <returns></returns>
        public bool deleteUserbyIds(string u_accounts)
        {

            bool result;
            string strSql = string.Format("delete dbo.UserInfo where u_account in ({0}) ", u_accounts);
            int i = SQLHelper.ExecuteSql(strSql);
            if (i > 0)
            {
                result = true;
            }
            else
            {
                result = false;

            }
            return result;
        }
        }
    }
