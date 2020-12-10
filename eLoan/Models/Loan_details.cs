using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLoan.Models
{
    public class Loan_details
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int loan_details_id { get; set; }
        public float loan_amount { get; set; }
        public float balance { get; set; }
        public float interest_rate { get; set; }
        public int tenure { get; set; }
        public DateTime loan_date { get; set; }

        //// Foreign key   
        //[Display(Name = "Address")]
        //public virtual int address_id { get; set; }

        //[ForeignKey("address_id")]
        //public virtual Address Address { get; set; }

    }
}
