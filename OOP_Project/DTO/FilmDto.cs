using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.DTO
{
    public class FilmDto
    {
        public string Name { get; set; }
        public int AgeRestriction { get; set; }
        public int Year { get; set; }
        public string OriginalTitle { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Production { get; set; }
        public string Studio { get; set; }
        public string Description { get; set; }
    }
}
