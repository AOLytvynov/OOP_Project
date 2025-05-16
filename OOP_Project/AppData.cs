using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace OOP_Project
{
    public static class AppData
    {
        public static List<RegisteredUser> Users { get; set; } = new();

        public static User? CurrentUser { get; set; }

        public static List<ScreeningSchedule> Schedules { get; set; } = new();
    }
}
