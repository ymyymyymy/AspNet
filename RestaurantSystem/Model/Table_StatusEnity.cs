using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Table_StatusEnity
    {
        public int Table_ID { get; set; }
        public string status { get; set; }
       
        public Table_StatusEnity()
        { }
        public Table_StatusEnity(int id,string status)
        {
            this.Table_ID = id;
            this.status = status;
        }
    }
}
