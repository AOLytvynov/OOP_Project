using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Models
{
    public class RegisteredUser : User
    {
        private string _login;
        private string _password;
        private string _phonenumber;
        private DateTime _dateOfBirth;

        public override string Login
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override string Password
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override string PhoneNumber
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        public override DateTime DateOfBirth
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public RegisteredUser(string login, string password, string phonenumber, DateTime dateOfBirth)
        {
            //Login = login;
            //Password = password;
            //PhoneNumber = phonenumber;
            //DateOfBirth = dateOfBirth;
            throw new NotImplementedException();
        }
        public List<Ticket> PurchasedTickets { get; set; } = new();

        public override string GetRole() => "RegisteredUser";
    }
}
