using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Menu_TypeEnity
    {
        public int Type_ID { get; set; }
        public string type_Name
        {
            get;
            set;
        }


        public Menu_TypeEnity() { }
        public Menu_TypeEnity(int type_ID, string type_Name)
        {
            this.Type_ID = type_ID;
            this.type_Name = type_Name;
        }
    }
}
