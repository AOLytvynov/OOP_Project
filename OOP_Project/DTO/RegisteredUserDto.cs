using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace OOP_Project.DTO
{
    public class RegisteredUserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<TicketDto> PurchasedTickets { get; set; } = new();
    }

}
