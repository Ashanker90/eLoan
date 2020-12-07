using System;
using System.ComponentModel.DataAnnotations;
// Add for Foreign key
// https://stackoverflow.com/questions/39601623/the-type-or-namespace-name-foreignkey-could-not-be-found
using System.ComponentModel.DataAnnotations.Schema;

namespace eLoan.Models
{
    public class Application
    {
        [Key]
        public int application_id { get; set; }
       
        public int last4ssn { get; set; }

        // set loan state here instead of the form
        public string loan_state { get; set; }

        public string employee_name { get; set; }
        public float monthly_salary { get; set; }
        public float rent_mortgage_expense { get; set; }
        public float additional_expense { get; set; }
        public float amount_requested { get; set; }
        public int tenure_in_months { get; set; }

        // Set this here to todays date and not in form
        public DateTime application_date { get; set; }

        // Foreign key   
        [Display(Name = "Profile")]
        public virtual int profile_id { get; set; }

        [ForeignKey("profile_id")]
        public virtual Profile Profile { get; set; }
    }
}
