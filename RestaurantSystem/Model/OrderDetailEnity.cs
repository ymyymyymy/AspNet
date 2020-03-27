using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetailEnity
    {
        public int OrderDetail_id { get; set; }
        public string order_id { get; set; }
        public string menu_id { get; set; }
        public int OrderDetail_amount { get; set; }
        public byte status { get; set; }
        public OrderDetailEnity()
        {
    }
        public OrderDetailEnity(string order_id)
            : this()
        {
            this.order_id= order_id;
        }
        public OrderDetailEnity(string orderid, string menuid, int amount)
        {
            this.order_id = orderid;
            this.menu_id = menuid;
            this.OrderDetail_amount = amount;
        }
    }
}
