using System;
using System.ComponentModel.DataAnnotations;

namespace eLoan_Project.Models
{
    public class Customer
    {
        [Key]
        public int customer_ID { get; set; }
        public int application_ID { get; set; }
        public int profile_ID { get; set; }
        public int loan_ID { get; set; }

        public Customer()
        {
        }
    }
}
