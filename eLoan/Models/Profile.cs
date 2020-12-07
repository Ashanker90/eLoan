using System;
using System.ComponentModel.DataAnnotations;
// Add for Foreign key
// https://stackoverflow.com/questions/39601623/the-type-or-namespace-name-foreignkey-could-not-be-found
using System.ComponentModel.DataAnnotations.Schema;

namespace eLoan.Models
{
    public class Profile
    {
        [Key]
        public int profile_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }

        // Foreign key   
        [Display(Name = "Address")]
        public virtual int address_id { get; set; }

        [ForeignKey("address_id")]
        public virtual Address Address { get; set; }
        
    }
}
