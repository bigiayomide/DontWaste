using System;
using System.ComponentModel.DataAnnotations;

namespace DontWaste.Api.Entities
{
    public class DataObject
    {
        [Key]
        public int Id { get; set; }
    }
}
