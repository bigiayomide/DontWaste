using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Entities
{
    public class Order : DataObject
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public AppUser User { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItems {get;set;}
    }
}
