using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
    public abstract class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public abstract string GetRole();
    }
}
