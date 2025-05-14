using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace TestProject
{
    [TestClass]
    public sealed class ScreeningTest
    {

        [TestMethod]
        public void SortListScreeningsTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            var screening1 = new Screening(film, new DateTime(2025, 7, 15, 20, 0, 0));
            var screening2 = new Screening(film, new DateTime(2025, 7, 15, 18, 0, 0));
            var screening3 = new Screening(film, new DateTime(2025, 7, 15, 19, 0, 0));

            var screenings = new List<Screening> { screening1, screening2, screening3 };

            // Act
            screenings.Sort();

            // Assert
            Assert.AreEqual(screening2, screenings[0]);
            Assert.AreEqual(screening3, screenings[1]);
            Assert.AreEqual(screening1, screenings[2]);
        }

        [TestMethod]
        public void SetScreeningWithValidDataTest()
        {
            // Arrange
            var film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screeningDate = new DateTime(2025, 7, 15, 18, 30, 0);

            // Act
            var screening = new Screening(film, screeningDate);

            // Assert
            Assert.AreEqual(film, screening.Film);
            Assert.AreEqual(screeningDate, screening.Date);
            Assert.IsNotNull(screening.Tickets);
            Assert.AreEqual(0, screening.Tickets.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetScreeningNullFilmTest()
        {
            // Arrange
            Film nullFilm = null;
            var screeningDate = new DateTime(2025, 7, 15, 18, 30, 0);

            // Act
            var screening = new Screening(nullFilm, screeningDate);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetScreeningPastDateTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var pastDate = DateTime.Now.AddMinutes(-10);

            // Act
            var screening = new Screening(film, pastDate);

            // Assert
        }

        [TestMethod]
        public void AddTickets_ValidTicketsTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screening = new Screening(film, new DateTime(2025, 7, 15, 20, 0, 0));
            var ticket1 = new Ticket(screening, "T1", 1, 1);
            var ticket2 = new Ticket(screening, "T2", 1, 2);
            var ticket3 = new Ticket(screening, "T3", 2, 1);
            var tickets = new List<Ticket> { ticket1, ticket2, ticket3 };

            // Act
            screening.AddTickets(tickets);

            // Assert
            Assert.AreEqual(3, screening.Tickets.Count);
            Assert.IsTrue(screening.Tickets.Contains(ticket1));
            Assert.IsTrue(screening.Tickets.Contains(ticket2));
            Assert.IsTrue(screening.Tickets.Contains(ticket3));
        }
    }
}
