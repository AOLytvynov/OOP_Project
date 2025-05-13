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

        public string Login
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Password
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string PhoneNumber
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        public DateTime DateOfBirth
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public List<Ticket> PurchasedTickets { get; set; } = new List<Ticket>();

        public override string GetRole() => "RegisteredUser";
    }
}
