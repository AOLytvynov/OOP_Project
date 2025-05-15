using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace TestProject
{
    [TestClass]
    public sealed class TicketTest
    {
        Film validFilm;
        Screening screening;

        [TestInitialize]
        public void Setup()
        {
            validFilm = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            screening = new(validFilm, new DateTime(2025, 7, 15, 18, 30, 0));
        }

        [TestMethod]
        public void SetTicketScreening()
        {
            //Arrange
            Ticket ticket = new Ticket(screening, "12", 1, 1);
            string expected = "Титанік";

            //Act
            string actual = ticket.Screening.Film.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignTicketToUserTest()
        {
            // Arrange
            var user = new RegisteredUser("user1234", "password", "0992542159", new DateTime(2000, 5, 13));
            var ticketId = "A1";
            var ticket = new Ticket(screening, ticketId, 5, 10);

            // Act
            ticket.AssignToUser(user);

            // Assert
            Assert.AreEqual(user, ticket.Owner);
            Assert.IsTrue(user.PurchasedTickets.Contains(ticket));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetTicketNullScreening()
        {
            //Arrange + Act
            Ticket ticket = new Ticket(null, "12", 1, 1);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTicketInvalidRowNumber()
        {
            //Arrange + Act
            Ticket ticket = new Ticket(screening, "12", -1, 1);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTicketInvalidSeatNumberTest()
        {
            //Arrange + Act
            Ticket ticket = new Ticket(screening, "12", 1, -1);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTicketInvalidIdTest()
        {
            //Arrange + Act
            Ticket ticket = new Ticket(screening, "12", 1, -1);

            //Assert
        }
    }
}
