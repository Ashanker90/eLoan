using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLoan.Models;

namespace eLoan.Data
{
    public class SeedTestData
    {
        //Class to seed the database with neccessary test data
        private eLoanContext context;

        

        Address testAddress = new Address { address_id = 12345, street = "Waffles Blvd.", city = "Breakfast Metropolis", state = "IL", country = "United States", zip_code = "54321" };
        Application testApplication = new Application { application_id = 67890, last4ssn = 2020, loan_state = "in_progress", employee_name = "Sam", monthly_salary = 12000, rent_mortgage_expense = 6500, additional_expense = 10000, amount_requested = 5000, tenure_in_months = 36, application_date = DateTime.Today};
        
        Profile testProfile = new Profile { profile_id = 11111, first_name = "IH", last_name = "OP", email = "IHoP@gmail.com", phone_number = "123-456-7890" };
        Bank testBank = new Bank { };
    }
}
