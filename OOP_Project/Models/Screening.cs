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
        private readonly List<Ticket> _tickets;

        public Film Film
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public DateTime Date 
        {
            get => throw new NotImplementedException(); 
            private set=> throw new NotImplementedException();
        }

        public IReadOnlyList<Ticket> Tickets
        {
            get => throw new NotImplementedException();
        }

        public Screening(Film film, DateTime date, List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Screening other)
        {
            throw new NotImplementedException();
            //if (other == null) return 1;
            //return this.Date.CompareTo(other.Date);
        }
    }
}
