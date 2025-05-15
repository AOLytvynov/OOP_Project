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
            var screening = new Screening(film, DateTime.Today.AddDays(1).AddHours(12));
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
            Film film2 = new Film("T", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");
            var screeningSchedule = new ScreeningSchedule(film);
            var screening = new Screening(film, DateTime.Today.AddDays(1).AddHours(12));
            var screening2 = new Screening(film2, DateTime.Today.AddDays(1).AddHours(12));

            screeningSchedule.Add(screening);
            bool res;

            // Act
            res = screeningSchedule.Remove(screening2);
            var addedScreening = screeningSchedule.Screenings.FirstOrDefault(s => s == screening);


            // Assert 
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void AddScreeningWithValidTimeTest()
        {
            // Arrange
            Film film = new Film("Test", 16, 2020, "Test", "Director", "English", "Drama", 120, "USA", "Studio", "Desc");
            var schedule = new ScreeningSchedule(film);
            DateTime validTime = DateTime.Today.AddDays(1).AddHours(12);
            Screening screening = new Screening(film, validTime);

            // Act
            bool result = schedule.Add(screening);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddScreeningBeforeOpeningHoursTest()
        {
            // Arrange
            Film film = new Film("Test", 16, 2020, "Test", "Director", "English", "Drama", 120, "USA", "Studio", "Desc");
            var schedule = new ScreeningSchedule(film);
            DateTime earlyTime = DateTime.Today.AddDays(1).AddHours(7);

            // Act
            Screening screening = new Screening(film, earlyTime);
            bool result = schedule.Add(screening);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddScreeningAfterClosingHoursTest()
        {
            // Arrange
            Film film = new Film("Test", 16, 2020, "Test", "Director", "English", "Drama", 120, "USA", "Studio", "Desc");
            var schedule = new ScreeningSchedule(film);
            DateTime lateTime = DateTime.Today.AddDays(1).AddHours(21);

            // Act
            Screening screening = new Screening(film, lateTime);
            bool result = schedule.Add(screening);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddScreeningOverlappingTest()
        {
            // Arrange
            Film film = new Film("Test", 16, 2020, "Test", "Director", "English", "Drama", 120, "USA", "Studio", "Desc");
            var schedule = new ScreeningSchedule(film);
            DateTime time1 = DateTime.Today.AddDays(1).AddHours(10);
            DateTime time2 = time1.AddMinutes(60);

            // Act
            schedule.Add(new Screening(film, time1));
            bool result = schedule.Add(new Screening(film, time2));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddScreeningValidTest()
        {
            Film film = new Film("Test", 16, 2020, "Test", "Director", "English", "Drama", 120, "USA", "Studio", "Desc");
            var schedule = new ScreeningSchedule(film);

            DateTime time1 = DateTime.Today.AddDays(1).AddHours(10);
            DateTime time2 = time1.AddMinutes(135);

            schedule.Add(new Screening(film, time1));
            bool result = schedule.Add(new Screening(film, time2));

            Assert.IsTrue(result);
        }

    }
}
