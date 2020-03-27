using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User_PrivilegeEnity
    {
        public int p_id { get; set; }
        public string p_name { get; set; }

        public User_PrivilegeEnity() { }
        public User_PrivilegeEnity(int p_id, string p_name)
        {

            this.p_id = p_id;
            this.p_name = p_name;
        }
    }
}
