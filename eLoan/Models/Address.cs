using System;
using System.ComponentModel.DataAnnotations;

namespace eLoan.Models
{
    public class Address
    {
        [Key]
        public int address_id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip_code { get; set; }
    }
}
