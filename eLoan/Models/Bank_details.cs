using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLoan.Models
{
    public class Bank_details
    {
        [Key]
        public int bank_details_id { get; set; }
        public string bank_name { get; set; }
        public string routing_number { get; set; }
        public string account_number { get; set; }

        //// Foreign key   
        //[Display(Name = "Address")]
        //public virtual int address_id { get; set; }

        //[ForeignKey("address_id")]
        //public virtual Address Address { get; set; }

    }
}
