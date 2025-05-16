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
        public static Admin AdminUser { get; } = new Admin("admin", "password", "0000000000", new DateTime(1990, 1, 1));

        public static List<RegisteredUser> Users { get; set; } = new();

        public static RegisteredUser? CurrentUser { get; set; }

        public static List<ScreeningSchedule> Schedules { get; set; } = new();
    }
}
