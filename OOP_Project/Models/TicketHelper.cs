using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
    public static class TicketHelper
    {
        private static readonly Random _random = new();

        public static string GenerateUniqueTicketId(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Довжина має бути більшою за 0");

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[_random.Next(s.Length)])
                                        .ToArray());
        }

        public static List<Ticket> GenerateTicketsForScreening(Screening screening, int rowNumber, int seatNumber)
        {
            if (screening == null)
                throw new ArgumentNullException("Сеанс не може бути null.");

            if (rowNumber <= 0 || seatNumber <= 0)
                throw new ArgumentOutOfRangeException("Кількість рядів і місць має бути більшою за 0.");

            var tickets = new List<Ticket>();

            for (int row = 1; row <= rowNumber; row++)
            {
                for (int seat = 1; seat <= seatNumber; seat++)
                {
                    var ticket = new Ticket(screening, GenerateUniqueTicketId(20), row, seat);
                    tickets.Add(ticket);
                }
            }

            return tickets;
        }
    }
}
