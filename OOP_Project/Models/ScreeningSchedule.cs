using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Interfaces;

namespace OOP_Project.Models
{
    public class ScreeningSchedule : IScreeningSchedule
    {
        private readonly List<Screening> _screenings = new();
        Film _film;

        public IReadOnlyList<Screening> Screenings
        {
            get => _screenings;
        }

        public Film Film
        {
            get => _film;
            set
            {
                if(value == null) throw new ArgumentNullException("Фільм не може бути null.");
                _film = value;
            }
        }

        public ScreeningSchedule(Film film) 
        { 
            Film = film;
        }

        public bool Add(Screening screening)
        {
            if (screening == null) return false;
            if (screening.Film != Film) return false;
            var startTime = screening.Date;
            var endTime = startTime.AddMinutes(screening.Film.Duration + 15);

            if (startTime.TimeOfDay < TimeSpan.FromHours(9) ||
                startTime.TimeOfDay > TimeSpan.FromHours(19))
                return false;

            foreach (var existing in _screenings)
            {
                var existingStart = existing.Date;
                var existingEnd = existingStart.AddMinutes(existing.Film.Duration + 15);

                bool overlaps = startTime < existingEnd && endTime > existingStart;
                if (overlaps)
                    return false;
            }
            _screenings.Add(screening);
            return true;
        }

        public bool Remove(Screening screening)
        {
            return _screenings.Remove(screening);
        }
    }
}
