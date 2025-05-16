using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.DTO
{
    public class ScreeningScheduleDto
    {
        public FilmDto Film { get; set; }
        public List<ScreeningDto> Screenings { get; set; } = new();
    }
}
