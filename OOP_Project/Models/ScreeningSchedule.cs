using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Interfaces;

namespace OOP_Project.Models
{
    public class ScreeningSchedule : IScreeningSchedule
    {
        private readonly List<Screening> _screenings = new();

        public IReadOnlyList<Screening> Screenings
        {
            get => throw new NotImplementedException();
        }

        public Film Film
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ScreeningSchedule() 
        { 
            throw new NotImplementedException();
        }

        public bool Add(Screening screening)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Screening screening)
        {
            throw new NotImplementedException();
        }
    }
}
