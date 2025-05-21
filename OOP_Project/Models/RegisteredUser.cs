using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


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
            get => _login;
            protected set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Логін не може бути порожнім.");
                if (value.Length < 5 || value.Length > 32) throw new ArgumentException("Довжина логіну повинна бути від 5 до 32 символів.");
                if (value.Any(c => !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || char.IsDigit(c) || c == '-' || c == '.' || c == '_')))
                    throw new ArgumentException("Для логіну допустимі тільки малі латинські літери, цифри та символи «-», «.», «_».");
                _login = value;
            }
        }

        public override string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Логін не може бути порожнім.");
                if (value.Length <= 5 || value.Length > 32) throw new ArgumentException("Довжина паролю повинна бути від 5 до 32 символів.");
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z0-9!@#$%^&*()_\-+=\[\]{}|\\:;""'<>,.?/~`]+$"))
                    throw new ArgumentException("Для паролю допустимі тільки великі та малі латинські літери, цифри та спеціальні символи.");
                    _password = value;
            }
        }

        public override string PhoneNumber
        {
            get => _phonenumber;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Номер телефону не може бути пустим.");
                if (value.Length != 10) throw new ArgumentException("Номер телефону повинен складатися з 10 цифр.");
                if (!value.All(char.IsDigit)) throw new ArgumentException("Номер телефону повинен містити лише цифри.");
                if (!value.StartsWith("0")) throw new ArgumentException("Номер телефону повинен починатися з '0'.");
                _phonenumber = value;
            }
        }

        public override DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                DateTime minDate = new DateTime(1900, 1, 1);
                DateTime now = DateTime.Now;

                if (value < minDate)
                    throw new ArgumentOutOfRangeException("Дата народження не може бути раніше 01.01.1900.");

                if (value >= now)
                    throw new ArgumentOutOfRangeException("Дата народження не може бути пізніше поточного моменту часу.");

                _dateOfBirth = value;
            }
        }

        public RegisteredUser(string login, string password, string phonenumber, DateTime dateOfBirth)
        {
            Login = login;
            Password = password;
            PhoneNumber = phonenumber;
            DateOfBirth = dateOfBirth;
        }
        public List<Ticket> PurchasedTickets { get; set; } = new();

        public override string GetRole() => "RegisteredUser";
    }
}
