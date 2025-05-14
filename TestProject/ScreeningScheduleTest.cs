using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace TestProject
{
    [TestClass]
    public sealed class ScreeningScheduleTest
    {
        [TestMethod]
        public void SetNullFilmTest()
        {
            // Arrange
            Film film = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var schedule = new ScreeningSchedule(film);
            });
        }

        [TestMethod]
        public void SetValidFilmTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            string expected = "Titanic";

            // Act
            ScreeningSchedule screeningSchedule = new ScreeningSchedule(film);
            string actual = screeningSchedule.Film.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScreeningValidAddTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screeningSchedule = new ScreeningSchedule(film);
            var screening = new Screening(film, DateTime.Now.AddDays(1));
            bool res;

            // Act
            res = screeningSchedule.Add(screening);
            var addedScreening = screeningSchedule.Screenings.FirstOrDefault(s => s == screening);


            // Assert 
            Assert.IsTrue(res);
            Assert.IsNotNull(addedScreening);
            Assert.AreEqual(screening, addedScreening);
        }

        [TestMethod]
        public void ScreeningInvalidAddTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            Film film2 = new Film("T", 16, 1997, "T", "T", "T", "T", 195, "T", "T", "T");
            var screeningSchedule = new ScreeningSchedule(film);
            var screening = new Screening(film2, DateTime.Now.AddDays(1));
            bool res;

            // Act
            res = screeningSchedule.Add(screening);
            var addedScreening = screeningSchedule.Screenings.FirstOrDefault(s => s == screening);


            // Assert 
            Assert.IsFalse(res);
            Assert.IsNull(addedScreening);
        }

        [TestMethod]
        public void ScreeningValidRemoveTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screeningSchedule = new ScreeningSchedule(film);
            var screening = new Screening(film, DateTime.Now.AddDays(1));
            screeningSchedule.Add(screening);
            bool res;

            // Act
            res = screeningSchedule.Remove(screening);
            var addedScreening = screeningSchedule.Screenings.FirstOrDefault(s => s == screening);


            // Assert 
            Assert.IsTrue(res);
            Assert.IsNull(addedScreening);
        }

        [TestMethod]
        public void ScreeningInvalidRemoveTest()
        {
            // Arrange
            Film film = new Film("Titanic", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screeningSchedule = new ScreeningSchedule(film);
            var screening = new Screening(film, DateTime.Now.AddDays(1));
            screeningSchedule.Add(screening);
            bool res;

            // Act
            res = screeningSchedule.Remove(screening);
            var addedScreening = screeningSchedule.Screenings.FirstOrDefault(s => s == screening);


            // Assert 
            Assert.IsTrue(res);
            Assert.IsNull(addedScreening);
        }
    }
}
