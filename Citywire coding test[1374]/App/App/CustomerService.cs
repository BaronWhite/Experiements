using System;
using System.Collections.Generic;

namespace App
{
    public class CustomerService
    {

        public bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            ValidationResult validationResult = new ValidationResult();

            validationResult.Validate(ValidateName(firname, surname));
            validationResult.Validate(ValidateAge(dateOfBirth));
            validationResult.Validate(ValidateEmail(email));

            if (!validationResult.IsValid)
            {
                return false;
            }

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

            validationResult.Validate(ValidateCredit(customer, company));

            if (!validationResult.IsValid)            
            {
                return false;
            }

            CustomerDataAccess.AddCustomer(customer);

            return true;
        }

        public string ValidateName(string firname, string surname)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return "Customer name \"" + firname + " " + surname + "\" failed validation.";
            }
            return null;
        }

        public string ValidateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            if (age < 21)
            {
                return "Customer age \"" + age + "\" failed validation.";
            }

            return null;
        }

        public string ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                return "Customer email \"" + email + "\" failed validation.";
            }

            return null;
        }

        public string ValidateCredit(Customer customer, Company company)
        {
            var creditCheckFactory = new CreditCheckFactory();
            var creditCheck = creditCheckFactory.GetCreditCheck(company.Name);

            creditCheck.PerformCreditCheck(customer, company);

            if (customer.HasCreditLimit && customer.CreditLimit < 500)
            {
                return "Customer failed credit validation.";
            }

            return null;
        }
    }
}
