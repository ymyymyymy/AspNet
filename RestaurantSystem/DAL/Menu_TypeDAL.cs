using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DBContext;
using System.Data.SqlClient;

namespace DAL
{
    public class Menu_TypeDAL
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<Menu_TypeEnity> GetList()
        {
            List<Menu_TypeEnity> Menu = new List<Menu_TypeEnity>();
            string sql = "select Type_ID,type_Name from dbo.Menu_Type ";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                Menu_TypeEnity m = new Menu_TypeEnity(Convert.ToInt32(sdr[0]), sdr[1].ToString());

                Menu.Add(m);
            }
            return Menu;

        }
    }
}
