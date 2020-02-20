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
        public ICustomerCreditCheck GetCreditCheck(String company)
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


    public class Programmer
    {
        private List<string> languages = new List<string>();

        public List<string> Languages { get => languages; set => languages = value; }

        public void AddLanguage(string language)
        {
            Languages.Add(language);
        }
    }
    public class ProgrammerTeacher : Programmer
    {
        public bool Teach(Programmer programmer, string language)
        {
            if (Languages.Contains(language))
            {
                return true;
            }
            return false;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
                  ProgrammerTeacher teacher = new ProgrammerTeacher();
                  teacher.AddLanguage("C#");

                  Programmer programmer = new Programmer();
                  teacher.Teach(programmer, "C#");

                  foreach (var language in programmer.Languages)
                      Console.WriteLine(language);
        }
    }

}
