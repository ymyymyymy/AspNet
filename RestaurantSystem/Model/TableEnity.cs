using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class TableEnity:TableStatus
    {
        public string table_id { get; set; }
        public int table_status { get; set; }
        public TableEnity() { }
        public TableEnity(string Table_id,int Table_status)
        {
            this.table_id = Table_id;
            this.table_status = Table_status;
        }
        public TableEnity(string Table_id, string Status)
           
        {
            this.table_id = Table_id;
            this.Status = Status;
        }
    }
}
