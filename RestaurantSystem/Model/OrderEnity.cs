using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class OrderEnity
    {
        public string OrderID { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime CheckTime { get; set; }
        public string TableID { get; set; }
        public int AmountofCustomer { get; set; }
        public int CheckStatus { get; set; }
        public OrderEnity() { }

        public OrderEnity(string tableid, int person_amount, int check, DateTime ordertime) 
        {
            this.TableID = tableid;
            this.AmountofCustomer = person_amount;
            this.CheckStatus = check;
            this.OrderTime = ordertime;
        }
    }
}
