using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
    public class Film
    {
        public string Name
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int AgeRestriction
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Year
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string OriginalTitle
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Director
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Language
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Genre
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Duration
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Production
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Studio
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Description
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Film(string name, int ageRestriction, int year, string originalTitle, string director, string language, string genre, int duration, string production, string studio, string description)
        {
            //Name = name;
            //AgeRestriction = ageRestriction;
            //Year = year;
            //OriginalTitle = originalTitle;
            //Director = director;
            //Language = language;
            //Genre = genre;
            //Duration = duration;
            //Production = production;
            //Studio = studio;
            //Description = description;
            throw new NotImplementedException();
        }

        public bool Equals(Film other)
        {
            //if (other is null)
            //    return false;

            //return Name == other.Name &&
            //       AgeRestriction == other.AgeRestriction &&
            //       Year == other.Year &&
            //       OriginalTitle == other.OriginalTitle &&
            //       Director == other.Director &&
            //       Language == other.Language &&
            //       Genre == other.Genre &&
            //       Duration == other.Duration &&
            //       Production == other.Production &&
            //       Studio == other.Studio && Description == other.Description;
            throw new NotImplementedException();
        }

        public static bool operator ==(Film left, Film right)
        {
            //return EqualityComparer<Film>.Default.Equals(left, right);
            throw new NotImplementedException();
        }

        public static bool operator !=(Film left, Film right)
        {
            //return !(left == right);
            throw new NotImplementedException();
        }
    }
}
