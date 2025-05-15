using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
    public class Film : IEquatable<Film>
    {
        string _name;
        int _ageRestriction;
        int _year;
        string _originalTitle;
        string _director;
        string _language;
        string _genre;
        int _duration;
        string _production;
        string _studio;
        string _description;
        
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Ім'я не може бути пустим.");
                _name = value;
            }
        }

        public int AgeRestriction
        {
            get => _ageRestriction;
            set
            {
                if (!(value >= 0 && value <= 100)) throw new ArgumentOutOfRangeException("Вікові обмеження не можуть бути менше 0 або більше 100.");
                _ageRestriction = value;  
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (!(value >= 1900)) throw new ArgumentOutOfRangeException("Рік створення фільму не може бути раніше 1900.");
                _year = value;
            }
        }

        public string OriginalTitle
        {
            get => _originalTitle;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Оригінальна назва не може бути пуста.");
                _originalTitle = value;
            }
        }

        public string Director
        {
            get => _director;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Ім'я режисера не може бути пустим.");
                _director = value;
            }
        }

        public string Language
        {
            get => _language;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Мова не може бути пуста.");
                _language = value;
            }
        }

        public string Genre
        {
            get => _genre;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Жанр не може бути пустим.");
                _genre = value;
            }
        }

        public int Duration
        {
            get => _duration;
            set
            {
                if (!(value > 0)) throw new ArgumentOutOfRangeException("Тривалість не може бути 0 або менше.");
                _duration = value;
            }
        }

        public string Production
        {
            get => _production;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Виробництво не може бути пустим.");
                _production = value;
            }
        }

        public string Studio
        {
            get => _studio;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Назва студії не може бути пуста.");
                _studio = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Опис не може бути пустим.");
                _description = value;
            }
        }

        public Film(string name, int ageRestriction, int year, string originalTitle, string director, string language, string genre, int duration, string production, string studio, string description)
        {
            Name = name;
            AgeRestriction = ageRestriction;
            Year = year;
            OriginalTitle = originalTitle;
            Director = director;
            Language = language;
            Genre = genre;
            Duration = duration;
            Production = production;
            Studio = studio;
            Description = description;
        }

        public bool Equals(Film other)
        {
            if (other is null)
                return false;

            return Name == other.Name &&
                   AgeRestriction == other.AgeRestriction &&
                   Year == other.Year &&
                   OriginalTitle == other.OriginalTitle &&
                   Director == other.Director &&
                   Language == other.Language &&
                   Genre == other.Genre &&
                   Duration == other.Duration &&
                   Production == other.Production &&
                   Studio == other.Studio && Description == other.Description;
        }

        public static bool operator ==(Film left, Film right)
        {
            return EqualityComparer<Film>.Default.Equals(left, right);
        }

        public static bool operator !=(Film left, Film right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                HashCode.Combine(Name, AgeRestriction, Year),
                HashCode.Combine(OriginalTitle, Director, Language),
                HashCode.Combine(Genre, Duration, Production),
                HashCode.Combine(Studio, Description)
            );
        }

    }
}
