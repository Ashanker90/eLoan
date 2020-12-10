using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace eLoan.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }

        [Display(Name = "Profile")]
        public virtual int profile_id { get; set; }

        [ForeignKey("profile_id")]
        public virtual Profile Profile { get; set; }

        [Display(Name = "Application")]
        public virtual int application_id { get; set; }

        [ForeignKey("application_id")]
        public virtual Application Application { get; set; }

        [Display(Name = "Loan_details")]
        public virtual int loan_details_id { get; set; }

        [ForeignKey("loan_details_id")]
        public virtual Loan_details Loan_details { get; set; }

        [Display(Name = "Bank_details")]
        public virtual int bank_details_id { get; set; }

        [ForeignKey("bank_details_id")]
        public virtual Bank_details Bank_details { get; set; }

    }
}
