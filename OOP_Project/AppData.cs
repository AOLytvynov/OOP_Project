using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.DTO;
using OOP_Project.Models;

namespace OOP_Project
{
    public static class AppData
    {
        public static Admin AdminUser { get; set; } = new Admin("admin", "12121212", "0000000000", new DateTime(1990, 1, 1));

        public static List<RegisteredUser> Users { get; set; } = new();

        public static RegisteredUser? CurrentUser { get; set; }

        public static List<ScreeningSchedule> Schedules { get; set; } = new();

        public static void Initialize()
        {
            Schedules = JsonStorage.LoadSchedules();
            Users = JsonStorage.LoadUsers();

            // Знаходимо адміністратора серед завантажених користувачів
            var loadedAdmin = Users.FirstOrDefault(u => u.Login == "admin");

            if (loadedAdmin is Admin realAdmin)
            {
                AdminUser = realAdmin;
            }
            else if (loadedAdmin == null)
            {
                // Якщо адміністратора немає — додаємо вручну
                AdminUser = new Admin("admin", "12121212", "0000000000", new DateTime(1990, 1, 1));
                Users.Add(AdminUser);
                JsonStorage.SaveUsers(Users); // зберігаємо одразу
            }
        }
    }
}
