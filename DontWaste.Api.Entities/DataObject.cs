using System;
using System.ComponentModel.DataAnnotations;

namespace DontWaste.Api.Entities
{
    public class DataObject
    {
        [Key]
        public string Id { get; set; }
    }
}
