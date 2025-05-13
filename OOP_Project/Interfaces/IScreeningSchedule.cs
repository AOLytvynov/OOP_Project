using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace OOP_Project.Interfaces
{
    public interface IScreeningSchedule
    {
        Film Film { get; }
        IReadOnlyList<Screening> Screenings { get; }
        bool Add(Screening screening);
        bool Remove(Screening screening);
    }
}
