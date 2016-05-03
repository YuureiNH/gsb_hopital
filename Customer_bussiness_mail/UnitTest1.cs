using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customer_bussiness;
using System.Text.RegularExpressions;

namespace Customer_bussiness_TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isNotEmpty()
        {
            string mail = "nicolas";
            Customer one = new Customer();

            one.Email = mail;

            Assert.AreNotEqual("", one.Email, "mail is empty");
        }

        [TestMethod]
        public void valid_mail()
        {
            string mail = "nicolas@live.fr";
            Customer one = new Customer();

            one.Email = mail;

            bool isEmail = Regex.IsMatch(
                one.Email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                RegexOptions.IgnoreCase
            );
            Assert.IsTrue(isEmail, "mail is not valid");
        }
    }
}
