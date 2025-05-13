using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace OOP_Project.Interfaces
{
    public interface ITicket
    {
        Screening Screening { get; }
        string TicketId { get; }
        int RowNumber { get; }
        int SeatNumber { get; }

        RegisteredUser? Owner { get; }
    }
}
