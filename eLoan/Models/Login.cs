using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLoan.Models
{
    public class Login
    {
        [Key]
        public string email { get; set; }

        public string password { get; set; }

        // Foreign key   
        [Display(Name = "Customer")]
        public virtual int customer_id { get; set; }

        [ForeignKey("customer_id")]
        public virtual Customer Customer { get; set; }
    }
}
