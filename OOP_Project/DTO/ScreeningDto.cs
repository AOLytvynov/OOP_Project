using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.DTO
{
    public class ScreeningDto
    {
        public FilmDto Film { get; set; }
        public DateTime Date { get; set; }
        public List<TicketDto> Tickets { get; set; } = new();
    }
}
