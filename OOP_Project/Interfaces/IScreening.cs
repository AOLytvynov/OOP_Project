using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace OOP_Project.Interfaces
{
    public interface IScreening
    {
        Film Film { get; }
        DateTime Date { get; }
        IReadOnlyList<Ticket> Tickets { get; }

        public void AddTickets(List<Ticket> tickets);
    }
}
