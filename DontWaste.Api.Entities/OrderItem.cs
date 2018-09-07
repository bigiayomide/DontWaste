using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Entities
{
    public class OrderItem:DataObject
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
    }
}
