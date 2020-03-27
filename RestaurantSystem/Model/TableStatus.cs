using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class TableStatus//TableStatusa
    {
        public int table_id { get; set; }
        public string Status { get; set; }
        public TableStatus() { }
        public TableStatus(int Table_id, string Table_status)
        {
            this.table_id = Table_id;
            this.Status = Table_status;
        }

    }
}
