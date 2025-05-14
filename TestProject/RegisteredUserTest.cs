using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace TestProject
{
    [TestClass]
    public sealed class RegisteredUserTest
    {
        public void SetValidLoginTest()
        {
            // Arrange
            string expected = "user1234";
            string password = "ValidPass123!";
            string phoneNumber = "0991234567";
            DateTime dob = new DateTime(2000, 1, 1);

            // Act
            var user = new RegisteredUser(expected, password, phoneNumber, dob);

            // Assert
            Assert.AreEqual(expected, user.Login);

        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("user@name")]
        public void SetInvalidLoginTest(string invalidLogin)
        {
            // Arrange
            string password = "ValidPass123!";
            string phoneNumber = "0991234567";
            DateTime dob = new DateTime(2000, 1, 1);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var user = new RegisteredUser(invalidLogin, password, phoneNumber, dob);
            });
        }

        [TestMethod]
        public void SetValidPasswordTest()
        {
            // Arrange
            string expected = "a12b13c14";
            string login = "validUser";
            string phoneNumber = "0991234567";
            DateTime dob = new DateTime(2000, 1, 1);

            // Act
            var user = new RegisteredUser(login, expected, phoneNumber, dob);

            // Assert
            Assert.AreEqual(expected, user.Password);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("short")]
        [DataRow("veryveryveryveryveryveryverylongpassword123!")]
        public void SetInvalidPasswordTest(string invalidPassword)
        {
            // Arrange
            string login = "validLogin";
            string phoneNumber = "0991234567";
            DateTime dob = new DateTime(2000, 1, 1);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var user = new RegisteredUser(login, invalidPassword, phoneNumber, dob);
            });
        }

        [DataTestMethod]
        [DataRow("1800-01-01")]
        [DataRow("3000-01-01")]
        [DataRow("2100-05-14")]
        public void SetInvalidDateOfBirthTest(string dateString)
        {
            // Arrange
            string login = "validUser";
            string password = "ValidPass123!";
            string phone = "0991234567";
            DateTime invalidDob = DateTime.Parse(dateString);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var user = new RegisteredUser(login, password, phone, invalidDob);
            });
        }

        [TestMethod]
        public void SetValidDateOfBirthTest()
        {
            // Arrange
            string login = "validUser";
            string password = "ValidPass123!";
            string phone = "0991234567";
            DateTime validDob = new DateTime(1990, 5, 1);

            // Act
            var user = new RegisteredUser(login, password, phone, validDob);

            // Assert
            Assert.AreEqual(validDob, user.DateOfBirth);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("123456789")] 
        [DataRow("12345678901")] 
        [DataRow("abcdefghij")]
        [DataRow(" 0991234567 ")] 
        [DataRow("991234567")]
        public void SetInvalidPhoneNumberTest(string phone)
        {
            // Arrange
            string login = "validUser";
            string password = "ValidPass123!";
            DateTime dob = new DateTime(2000, 1, 1);

            // Act & Assert
            Assert.ThrowsException<Exception>(() =>
            {
                var user = new RegisteredUser(login, password, phone, dob);
            });
        }

        [TestMethod]
        public void SetValidPhoneNumberTest()
        {
            // Arrange
            string login = "validUser";
            string password = "ValidPass123!";
            string phone = "0991234567";
            DateTime dob = new DateTime(2000, 1, 1);

            // Act
            var user = new RegisteredUser(login, password, phone, dob);

            // Assert
            Assert.AreEqual(phone, user.PhoneNumber);
        }

    }
}
