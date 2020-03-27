using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ShowMenuEnity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       private string name;

       public string Name
       {
           get { return name; }
           set { name = value; }
       }
       private float price;

       public float Price
       {
           get { return price; }
           set { price = value; }
       }


       public ShowMenuEnity() { }
       public ShowMenuEnity(int id, string name, float price)
       {
           this.Id = id;
           this.Name = name;
           this.Price = price;
       }
    }
}
