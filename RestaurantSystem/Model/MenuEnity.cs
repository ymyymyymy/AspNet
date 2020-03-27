using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MenuEnity : Menu_TypeEnity 
    {
        public string Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public int Menu_Type { get; set; }
        public float Menu_Price { get; set; }
        public string Menu_picture { get; set; }
        
        public MenuEnity() { }
        public MenuEnity(string menu_name, float menu_price, string menu_picture)
        {
            this.Menu_Name = menu_name;
            this.Menu_Price = menu_price;
            this.Menu_picture = menu_picture;
        }
        public MenuEnity(string menu_name, float menu_price, string menu_picture, string menu_id)
        {
            this.Menu_Name = menu_name;
            this.Menu_Price = menu_price;
            this.Menu_picture = menu_picture;
            this.Menu_ID = menu_id;
        }
        public MenuEnity(string menu_id, string menu_name, string type_Name, float menu_price, string menu_picture)
        {
            this.Menu_Name = menu_name;
            this.Menu_Price = menu_price;
            this.Menu_picture = menu_picture;
            this.Menu_ID = menu_id;
            this.type_Name = type_Name;
        }
    }
}
