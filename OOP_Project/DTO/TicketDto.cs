using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.DTO
{
    public class TicketDto
    {
        public string TicketId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public string? OwnerLogin { get; set; }
    }
}
