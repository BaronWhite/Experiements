using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;
using System;

namespace Tests
{
    [TestClass]
    public class CustomerServiceTest
    {

        CustomerService customerService = new CustomerService();

        [TestMethod]
        public void TestValidateName_Valid()
        {
            string firname = "name";
            string surname = "name";

            Assert.IsNull(customerService.ValidateName(firname, surname));
        }

        [TestMethod]
        public void TestValidateName_InvalidFirstName()
        {
            string firnameEmpty = "";
            string firnameNull = null;
            string surname = "name";

            Assert.IsNotNull(customerService.ValidateName(firnameEmpty, surname));
            Assert.IsNotNull(customerService.ValidateName(firnameNull, surname));
        }

        [TestMethod]
        public void TestValidateName_InvalidSurName()
        {
            string firname = "name";
            string surnameEmpty = "";
            string surnameNull = null;

            Assert.IsNotNull(customerService.ValidateName(firname, surnameEmpty));
            Assert.IsNotNull(customerService.ValidateName(firname, surnameNull));
        }



        [TestMethod]
        public void TestValidateEmail_Valid()
        {
            string email = "valid@email.com";

            Assert.IsNull(customerService.ValidateEmail(email));
        }

        [TestMethod]
        public void TestValidateEmail_Invalid()
        {
            string emailNull = null;
            string emailNoAtNoDot = "invalidemailcom";
            string emailNoAt = "invalidemail.com";
            string emailNoDot = "invalid@emailcom";

            Assert.IsNotNull(customerService.ValidateEmail(null));
            Assert.IsNotNull(customerService.ValidateEmail(emailNoAtNoDot));
            Assert.IsNotNull(customerService.ValidateEmail(emailNoAt));
            Assert.IsNotNull(customerService.ValidateEmail(emailNoDot));
        }

        [TestMethod]
        public void TestValidateAge_Valid()
        {
            DateTime dateOfBirth = DateTime.Now.AddYears(-21);

            Assert.IsNull(customerService.ValidateAge(dateOfBirth));
        }

        [TestMethod]
        public void TestValidateAge_Invalid()
        {
            DateTime dateOfBirth = DateTime.Now.AddYears(-20);

            Assert.IsNotNull(customerService.ValidateAge(dateOfBirth));
        }

        [TestMethod]
        public void ValidateCredit_VeryImportantClient_Valid()
        {
        }

        [TestMethod]
        public void ValidateCredit_VeryImportantClient_Invalid()
        {
        }

        [TestMethod]
        public void ValidateCredit_ImportantClient_Valid()
        {
        }

        [TestMethod]
        public void ValidateCredit_ImportantClient_Invalid()
        {
        }

        [TestMethod]
        public void ValidateCredit_NonImportantClient_Valid()
        {
        }

        [TestMethod]
        public void ValidateCredit_NonImportantClient_Invalid()
        {
        }
    }
}
