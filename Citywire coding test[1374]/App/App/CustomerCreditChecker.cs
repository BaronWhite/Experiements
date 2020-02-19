using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public interface ICustomerCreditCheck
    {
        void PerformCreditCheck(Customer customer, Company company);
    }

    class VeryImportantClientCreditCheck : ICustomerCreditCheck
    {
        public void PerformCreditCheck(Customer customer, Company company)
        {
            // Skip credit check
            customer.HasCreditLimit = false;
        }
    }

    class ImportantClientCreditCheck : ICustomerCreditCheck
    {
        public void PerformCreditCheck(Customer customer, Company company)
        {
            // Do credit check and double credit limit
            customer.HasCreditLimit = true;
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                creditLimit = creditLimit * 2;
                customer.CreditLimit = creditLimit;
            }
        }
    }

    class NonImportantClientCreditCheck : ICustomerCreditCheck
    {
        public void PerformCreditCheck(Customer customer, Company company)
        {
            // Do credit check
            customer.HasCreditLimit = true;
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                customer.CreditLimit = creditLimit;
            }
        }
    }

    public class CreditCheckFactory
    {
        public ICustomerCreditCheck PerformCreditCheck(String company)
        {
            if (String.IsNullOrEmpty(company)) throw new Exception("No company name provided.");

            
            if (company == "VeryImportantClient")
            {
                return new VeryImportantClientCreditCheck();
            }
            else if (company == "ImportantClient")
            {
                return new ImportantClientCreditCheck();
            }
            else
            {
                return new NonImportantClientCreditCheck();
            }
        }
    }
}
