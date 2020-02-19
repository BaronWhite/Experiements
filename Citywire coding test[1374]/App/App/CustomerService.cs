using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CustomerService
    {
        public List<ValidationErrors>

        public bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {



            var companyRepository = new CompanyRepository();
            var company = companyRepository.GetById(companyId);

            var customer = new Customer
                               {
                                   Company = company,
                                   DateOfBirth = dateOfBirth,
                                   EmailAddress = email,
                                   Firstname = firname,
                                   Surname = surname
                               };

            var creditCheckFactory = new CreditCheckFactory();
            var creditCheck = creditCheckFactory.PerformCreditCheck(company.Name);

            creditCheck.PerformCreditCheck(customer, company);

            if (customer.HasCreditLimit && customer.CreditLimit < 500)
            {
                return false;
            }

            CustomerDataAccess.AddCustomer(customer);

            return true;
        }

        public bool ValidateName()
        {
                        if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }
        }

        public bool ValidateAge()
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
        }

        public bool ValidateEmail()
        {
                        if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
        }

        public bool ValidateCredit()
        {

        }
    }
}
