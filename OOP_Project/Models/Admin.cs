using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
     public class Admin : RegisteredUser
    {
        public Admin(string login, string password, string phonenumber, DateTime dateOfBirth)
        : base(login, password, phonenumber, dateOfBirth) { }

        public override string GetRole()
        {
            throw new NotImplementedException();
        }
    }
}
