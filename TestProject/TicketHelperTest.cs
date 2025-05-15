using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Interfaces;
using OOP_Project.Models;

namespace TestProject
{
    [TestClass]
    public sealed class TicketHelperTest
    {
        [TestMethod]
        public void GenerateUniqueTicketId_ValidLengthTest()
        {
            // Arrange
            int length = 10;

            // Act
            string ticketId = TicketHelper.GenerateUniqueTicketId(length);

            // Assert
            Assert.AreEqual(length, ticketId.Length);
        }

        [TestMethod]
        public void GenerateUniqueTicketId_InvalidLengthTest()
        {
            //Arrange
            int invalidLength = 0;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                TicketHelper.GenerateUniqueTicketId(invalidLength);
            });
        }

        [TestMethod]
        public void GenerateTicketsForScreening_ValidInputTest()
        {
            // Arrange
            var film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screening = new Screening(film, DateTime.Now.AddDays(1));
            int rowNumber = 5;
            int seatNumber = 5;
            int numberOfTickets = 25;

            // Act
            var tickets = TicketHelper.GenerateTicketsForScreening(screening, rowNumber, seatNumber);

            // Assert
            Assert.AreEqual(numberOfTickets, tickets.Count);
        }

        [TestMethod]
        public void GenerateTicketsForScreening_NullScreeningInputTest()
        {
            // Arrange
            int rowNumber = 5;
            int seatNumber = 5;

            // Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TicketHelper.GenerateTicketsForScreening(null, rowNumber, seatNumber);
            });
        }

        [DataTestMethod]
        [DataRow(0, 5)]
        [DataRow(5, 0)]
        public void GenerateTicketsForScreening_InvalidRowAndSeatInputTest(int rowNumber, int seatNumber)
        {
            // Arrange
            var film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screening = new Screening(film, DateTime.Now.AddDays(1));

            // Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                TicketHelper.GenerateTicketsForScreening(screening, rowNumber, seatNumber);
            });
        }
    }
}
