using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class UserInfoEnity
    {
         public int u_account { get; set; }
         public string u_password { get; set; }
         public string u_name { get; set; }
         public string u_sex { get; set; }
         public int u_privilege { get; set; }

         private string p_name;
         public string P_name
         {
             get { return p_name; }
             set { p_name = value; }
         }

         public UserInfoEnity()
         {
         }
         public UserInfoEnity(int u_account, string u_name, string u_password, string u_sex, string p_name)
        {
           this.u_account = u_account;
           this.u_name=u_name;
           this.u_password=u_password;
           this.u_sex=u_sex;
           this.P_name = p_name;
        }
    }
    
}
