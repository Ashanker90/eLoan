using System;
using System.ComponentModel.DataAnnotations;

namespace eLoan_Project.Models
{
    public class Login
    {
        [Key]
        public string email_address { get; set; }
        public string password { get; set; }
        public string customer_ID { get; set; }
        public Login()
        {
        }
    }
}
