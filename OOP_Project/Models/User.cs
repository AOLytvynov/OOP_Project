using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
    public abstract class User
    {
        public abstract string Login { get; protected set; }
        public abstract string Password { get; set; }
        public abstract DateTime DateOfBirth { get; set; }
        public abstract string PhoneNumber { get; set; }
        public abstract string GetRole();
    }
}
