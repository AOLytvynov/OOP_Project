using System.Windows;
using OOP_Project.Models;

namespace TestProject
{
    [TestClass]
    public sealed class FilmTest
    {
        [TestMethod]
        public void SetFilmValidAllTest()
        {
            //Arrange
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            //Assert + Act
            Assert.AreEqual("Титанік", film.Name);
            Assert.AreEqual(16, film.AgeRestriction);
            Assert.AreEqual(1997, film.Year);
            Assert.AreEqual("Titanic", film.OriginalTitle);
            Assert.AreEqual("James Cameron", film.Director);
            Assert.AreEqual("English", film.Language);
            Assert.AreEqual("Drama", film.Genre);
            Assert.AreEqual(195, film.Duration);
            Assert.AreEqual("USA", film.Production);
            Assert.AreEqual("Fox", film.Studio);
            Assert.AreEqual("Ship sinks", film.Description);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongNameTest()
        {
            // Arrange & Act
            Film film = new Film("", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetFilmWrongAgeRestrictionTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", -1, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetFilmWrongYearTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 12, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongOriginalTitleTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongDirectorTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongLanguageTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongGenreTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetFilmWrongDurationTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "Drama", -1, "USA", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongProductionTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "", "Fox", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongStudioTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "", "Ship sinks");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetFilmWrongDescriptionTest()
        {
            // Arrange & Act
            Film film = new Film("Титанік", 16, 1997, "Titanic", "James Cameron", "English", "Drama", 195, "USA", "Fox", "Ship sinks");

            // Assert
        }
    }
}
