using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using OOP_Project.Models;
using System.IO;

namespace OOP_Project.DTO
{
    public static class JsonStorage
    {
        private const string ScheduleFilePath = "schedules.json";
        private const string UserFilePath = "users.json";

        public static void SaveSchedules(List<ScreeningSchedule> schedules)
        {
            var dtoList = schedules.Select(s => s.ToDto()).ToList();
            var json = JsonSerializer.Serialize(dtoList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ScheduleFilePath, json);
        }

        public static List<ScreeningSchedule> LoadSchedules()
        {
            if (!File.Exists(ScheduleFilePath)) return new List<ScreeningSchedule>();
            var json = File.ReadAllText(ScheduleFilePath);
            var dtoList = JsonSerializer.Deserialize<List<ScreeningScheduleDto>>(json);
            return dtoList?.Select(d => d.FromDto()).ToList() ?? new();
        }

        public static void SaveUsers(List<RegisteredUser> users)
        {
            var dtoList = users.Select(u => u.ToDto()).ToList();
            var json = JsonSerializer.Serialize(dtoList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(UserFilePath, json);
        }
        public static List<RegisteredUser> LoadUsers()
        {
            if (!File.Exists(UserFilePath)) return new List<RegisteredUser>();
            var json = File.ReadAllText(UserFilePath);
            var dtoList = JsonSerializer.Deserialize<List<RegisteredUserDto>>(json);
            return dtoList?.Select(d => d.FromDto()).ToList() ?? new();
        }
    }
}
