using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DontWaste.Api.Entities
{
    public class Dish :DataObject
    {
        public string dish_name { get; set; }
        public string description { get; set; }
        [DataType(DataType.Currency)]
        public decimal price { get; set; }
        public Category Categories { get; set; }
    }
}
