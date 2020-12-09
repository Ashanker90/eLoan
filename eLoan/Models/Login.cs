using System;
using System.ComponentModel.DataAnnotations;

namespace eLoan.Models
{
    public class Login
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
        public string customer_ID { get; set; }
        public Login()
        {
        }
    }
}
