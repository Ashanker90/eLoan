using System;
using System.ComponentModel.DataAnnotations;

namespace eLoan_Project.Models
{
    public class Bank
    {
        [Key]
        public int bank_ID { get; set; }
        public int customer_ID { get; set; }
        public string bank_name { get; set; }
        //int array because routing numbers are always a specific length (9) and error checking will be easier if the length can be bounded
        public int routing_number { get; set; }
        public double account_number { get; set; }

        public Bank()
        {
        }
    }
}
