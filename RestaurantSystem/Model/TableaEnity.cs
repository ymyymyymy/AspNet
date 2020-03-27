using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class TableaEnity//table
    {
        public string table_id { get; set; }
        public string table_status { get; set; }
        public TableaEnity() { }
        public TableaEnity(string Table_id,string Table_status)
        {
            this.table_id = Table_id;
            this.table_status = Table_status;
        }
    }
}
