using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Interfaces;

namespace OOP_Project.Models
{
    public class Ticket : ITicket
    {
        public Screening Screening 
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public string TicketId
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public int RowNumber
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public int SeatNumber
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public RegisteredUser? Owner 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Ticket(Screening screening, string ticketId, int rowNumber, int seatNumber)
        {
            throw new NotImplementedException();
        }

        
        public void AssignToUser(RegisteredUser user)
        {
            throw new NotImplementedException();
        }
    }
}
