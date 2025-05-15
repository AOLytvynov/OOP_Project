using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Interfaces;

namespace OOP_Project.Models
{
    public class Screening : IScreening, IComparable<Screening>
    {
        Film _film;
        DateTime _date;
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public Film Film
        {
            get => _film;
            private set
            {
                if (value == null) throw new ArgumentNullException("Фільм не може бути null.");
                _film = value;
            }
        }

        public DateTime Date 
        {
            get => _date;
            private set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("Дата сеансу не може бути в минулому.");
                _date = value;
            }
        }

        public IReadOnlyList<Ticket> Tickets => _tickets;

        public void AddTickets(List<Ticket> tickets)
        {
            if (tickets == null) throw new ArgumentNullException("Список квитків не може бути null.");
            _tickets.AddRange(tickets);
        }

        public Screening(Film film, DateTime date)
        {
            Film = film;
            Date = date;
        }

        public int CompareTo(Screening other)
        {
            if (other == null) return 1;
            return this.Date.CompareTo(other.Date);
        }
    }
}
