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
        int _rowNumber;
        int _seatNumber;
        Screening _screening;
        string _ticketId;
        RegisteredUser _owner;

        public Screening Screening 
        {
            get => _screening;
            private set
            {
                if (value == null) throw new ArgumentNullException("Сеанс не може бути null.");
                _screening = value;
            }
        }

        public string TicketId
        {
            get => _ticketId;
            private set
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentException("Унікальний код квитка не може бути порожнім або null.");
                _ticketId = value;
            }
        }

        public int Row
        {
            get => _rowNumber;
            private set
            {
                if (value <= 0) throw new ArgumentException("Ряд не може бути 0 або від'ємним.");
                _rowNumber = value;
            }
        }

        public int Seat
        {
            get => _seatNumber;
            private set
            {
                if (value <= 0) throw new ArgumentException("Номер місця не може бути 0 або від'ємним.");
                _seatNumber = value;
            }
        }

        public RegisteredUser? Owner 
        {
            get => _owner;
            set
            {
                _owner = value;
            }
        }

        public Ticket(Screening screening, string ticketId, int rowNumber, int seatNumber)
        {
            Screening = screening;
            TicketId = ticketId;
            Row = rowNumber;
            Seat = seatNumber;
        }

        public void AssignToUser(RegisteredUser user)
        {
            if (user == null) return;
            user.PurchasedTickets.Add(this);
            Owner = user;
        }
    }
}
